// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:c
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
// Copyright (c) 2006-2008 Jonathan Pobst (monkey@jpobst.com)
//
// Author:
//	Jonathan Pobst	monkey@jpobst.com
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MoMA.Analyzer;

namespace MoMA
{
	public partial class MainForm : Form
	{
		private WizardStep current_step;
		private AssemblyAnalyzer aa;
		private string image_directory;
		
		private Image success_image;
		private Image failed_image;
		private string report_filename;
		private string submit_filename;
		
		private FileDefinition async_definitions;
		private ListViewItem[] async_assemblies;
		
		public MainForm ()
		{
			InitializeComponent ();

			image_directory = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Resources");
			LoadImages ();
			
			ResetForm ();
			SetupForm (WizardStep.Introduction);
			SetupMonoVersion ();

			aa = new AssemblyAnalyzer ();
		}

		#region Properties
		public string ReportFileName {
			get {
				if (string.IsNullOrEmpty (report_filename))
					report_filename = Path.Combine (GetDefaultReportFolder(), "output.html");

				return report_filename;
			}
			set { report_filename = value; }
		}

		public string SubmitFileName {
			get {
				if (string.IsNullOrEmpty (submit_filename))
					submit_filename = Path.Combine (GetDefaultReportFolder (), "submit.xml");

				return submit_filename;
			}
			set { submit_filename = value; }
		}
		#endregion

		#region Public Methods
		public void AddAssembly (string path)
		{
			if (!ListContainsAssembly (Path.GetFileName (path))) {
				ListViewItem lvi = new ListViewItem (Path.GetFileName (path));
				lvi.Tag = path;

				AssemblyListView.Items.Add (lvi);
			}
		}

		public void AnalyzeNoGui ()
		{
			string msg = VerifyValidAssemblies ();
			
			if (!string.IsNullOrEmpty (msg))
				Console.WriteLine (msg);
				
			async_definitions = (FileDefinition)MonoVersionCombo.SelectedItem;
			async_assemblies = (ListViewItem[])new ArrayList (AssemblyListView.Items).ToArray (typeof (ListViewItem));

			ScanningCompletedEventArgs e = AnalyzeAssemblies ();
		}
		#endregion
		
		#region Private Methods
		private void ResetForm ()
		{
			ResultsDetailLink.Visible = false;

			Step1Panel.Visible = false;
			Step2Panel.Visible = false;
			Step3Panel.Visible = false;
			Step4Panel.Visible = false;
			Step5Panel.Visible = false;
		}

		private void SetupForm (WizardStep step)
		{
			switch (step) {
				case WizardStep.Introduction:
					Step1Panel.Visible = true;
					break;
				case WizardStep.ChooseAssemblies:
					Step2Panel.Visible = true;
					break;
				case WizardStep.ViewResults:
					NextButton.Text = "Next";
					
					if (ResultsText.Text.StartsWith ("There"))
						ResultsDetailLink.Visible = true;
						
					Step3Panel.Visible = true;
					break;
				case WizardStep.SubmitResults:
					NextButton.Text = "Next";
					Step4Panel.Visible = true;
					DescriptionComboBox.Focus ();
					break;
				case WizardStep.WhatsNext:
					NextButton.Text = "Close";
					Step5Panel.Visible = true;
					break;
			}

			StepLabel.Text = String.Format ("Step {0} of 5", (int)step);
			current_step = step;
		}

		private void NextButton_Click (object sender, EventArgs e)
		{
			switch (current_step) {
				case WizardStep.Introduction:
					ResetForm ();
					SetupForm (WizardStep.ChooseAssemblies);
					break;
				case WizardStep.ChooseAssemblies:
					string msg = VerifyValidAssemblies ();
					
					if (!string.IsNullOrEmpty (msg))
						MessageBox.Show (msg);
					
					if (AssemblyListView.Items.Count == 0) {
						MessageBox.Show ("Please choose at least one assembly to analyze.");
						return;
					}
					if (MonoVersionCombo.Items.Count == 0) {
						MessageBox.Show ("No definition files could be found.  Please try to download the latest definition file.");
						return;
					}
					
					ScanningLabel.Visible = true;
					ScanningSpinner.Visible = true;
					NextButton.Enabled = false;
					BackButton.Enabled = false;
					
					async_definitions = (FileDefinition)MonoVersionCombo.SelectedItem;
					async_assemblies = (ListViewItem[])new ArrayList (AssemblyListView.Items).ToArray (typeof (ListViewItem));
					
					BackgroundWorker bw = new BackgroundWorker();
					bw.DoWork += new DoWorkEventHandler (bw_DoWork);
					bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler (bw_RunWorkerCompleted);
					bw.RunWorkerAsync ();
					
					return;
				case WizardStep.ViewResults:
					ResetForm ();
					SetupForm (WizardStep.SubmitResults);
					break;
				case WizardStep.SubmitResults:
					ResetForm ();
					SetupForm (WizardStep.WhatsNext);
					break;
				case WizardStep.WhatsNext:
					Application.Exit ();
					break;
			}

			BackButton.Enabled = true;
		}

		private void bw_RunWorkerCompleted (object sender, RunWorkerCompletedEventArgs e)
		{
			ScanningCompletedEventArgs ar = (ScanningCompletedEventArgs)e.Result;
			
			// Update the summary screen
			UpdateResultsSummary (ar.MonoTodoTotal, ar.NotImplementedExceptionTotal, ar.PInvokeTotal, ar.MissingMethodTotal);

			// Enable the report submission button
			SubmitReportButton.Enabled = true;

			ScanningLabel.Visible = false;
			ScanningSpinner.Visible = false;
			NextButton.Enabled = true;
			BackButton.Enabled = true;
			
			ResetForm ();
			SetupForm (WizardStep.ViewResults);
		}
		
		private void bw_DoWork (object sender, DoWorkEventArgs e)
		{
			e.Result = AnalyzeAssemblies ();
		}

		private void BackButton_Click (object sender, EventArgs e)
		{
			switch (current_step) {
				case WizardStep.Introduction:
					ResetForm ();
					SetupForm (WizardStep.ChooseAssemblies);
					break;
				case WizardStep.ChooseAssemblies:
					BackButton.Enabled = false;
					ResetForm ();
					SetupForm (WizardStep.Introduction);
					break;
				case WizardStep.ViewResults:
					ResetForm ();
					SetupForm (WizardStep.ChooseAssemblies);
					break;
				case WizardStep.SubmitResults:
					ResetForm ();
					SetupForm (WizardStep.ViewResults);
					break;
				case WizardStep.WhatsNext:
					ResetForm ();
					SetupForm (WizardStep.SubmitResults);
					break;
			}
		}

		private void AssemblyAddButton_Click (object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog ();
			ofd.Multiselect = true;
			ofd.Filter = "Assemblies (*.exe, *.dll)|*.exe; *.dll|All Files (*.*)|*.*";

			if (ofd.ShowDialog () == DialogResult.OK)
				foreach (string s in ofd.FileNames)
					AddAssembly (s);
		}

		private bool ListContainsAssembly (string file)
		{
			foreach (ListViewItem lvi in AssemblyListView.Items)
				if (lvi.Text == file)
					return true;

			return false;
		}

		private void AssemblyRemoveButton_Click (object sender, EventArgs e)
		{
			if (AssemblyListView.SelectedItems.Count > 0) {
				ListView.SelectedListViewItemCollection list = AssemblyListView.SelectedItems;

				foreach (ListViewItem lvi in list)
					AssemblyListView.Items.Remove (lvi);
			}
		}

		private ScanningCompletedEventArgs AnalyzeAssemblies ()
		{
			// Make sure the images, css, and js for our html repor are there
			EnsureReportMedia (Path.GetDirectoryName (this.ReportFileName));
			
			// Setup the reports
			aa.WriteHtmlReport = true;
			aa.HtmlReportPath = this.ReportFileName;
			
			aa.WriteXmlReport = true;
			aa.XmlReportPath = this.SubmitFileName;
			
			// Setup the AssemblyAnalyzer
			aa.Definitions = async_definitions;
			aa.Assemblies.Clear ();
			
			// Add user's assemblies
			foreach (ListViewItem lvi in async_assemblies)
				aa.Assemblies.Add ((string)lvi.Tag);
				
			// Go!
			return aa.Analyze ();
		}

		private void UpdateResultsSummary (int monotodocount, int notimplementedcount, int pinvokecount, int missingcount)
		{
			if (monotodocount == 0) {
				MonoTodoResultsImage.Image = success_image;
				MonoTodoResultsLabel.Text = "No methods marked with [MonoTodo] are called.";
			}
			else {
				MonoTodoResultsImage.Image = failed_image;
				MonoTodoResultsLabel.Text = String.Format ("Methods called marked with [MonoTodo]: {0}", monotodocount);
			}

			if (notimplementedcount == 0) {
				NotImplementedResultsImage.Image = success_image;
				NotImplementedResultsLabel.Text = "No methods that throw NotImplementedException are called.";
			}
			else {
				NotImplementedResultsImage.Image = failed_image;
				NotImplementedResultsLabel.Text = String.Format ("Methods called that throw NotImplementedException: {0}", notimplementedcount);
			}

			if (pinvokecount == 0) {
				PInvokesResultsImage.Image = success_image;
				PInvokesResultsLabel.Text = "No P/Invokes are called.";
			}
			else {
				PInvokesResultsImage.Image = failed_image;
				PInvokesResultsLabel.Text = String.Format ("P/Invokes called: {0}", pinvokecount);
			}

			if (missingcount == 0) {
				MissingResultsImage.Image = success_image;
				MissingResultsLabel.Text = "All methods called exist in Mono.";
			}
			else {
				MissingResultsImage.Image = failed_image;
				MissingResultsLabel.Text = String.Format ("Methods that are still missing in Mono: {0}", missingcount);
			}

			if (monotodocount + notimplementedcount + pinvokecount + missingcount == 0)
				ResultsText.Text = "Congratulations!  No potential issues were detected in the selected assemblies.  The only thing left to do is to try running them on Mono and see what happens.";
			else {
				ResultsText.Text = "There were potential issues detected in the selected assemblies.  A report detailing each issue has been created.";
				ResultsDetailLink.Visible = true;
			}
		}

		private void ResultsDetailLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				System.Diagnostics.Process.Start (this.ReportFileName);
			}
			catch (Exception) {
				MessageBox.Show (string.Format ("The detail report can be viewed here:\n{0}", this.ReportFileName));
			}
		}

		private void ProjectLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.mono-project.com/");
		}

		private void SubmitReportButton_Click (object sender, EventArgs e)
		{
			SubmitReportButton.Enabled = false;

			try {
				if (aa.SubmitResults (OptionalNameBox.Text, OptionalEmailBox.Text, OptionalOrganizationBox.Text, OptionalHomePageBox.Text, OptionalCommentsBox.Text, DescriptionComboBox.Text))
					MessageBox.Show ("Results successfully submitted.  Thanks!");
				else
					MessageBox.Show ("Result submission failed.  Please try again later.");
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("Result submission failed (Exception={0}).", ex.ToString ()));
			}
		}

		private string VerifyValidAssemblies ()
		{
			List<ListViewItem> invalid_assemblies = new List<ListViewItem> ();

			foreach (ListViewItem lvi in AssemblyListView.Items)
				if (!AssemblyAnalyzer.IsValidAssembly ((string)lvi.Tag))
					invalid_assemblies.Add (lvi);

			string msg = "The following are not valid .Net assemblies and will not be scanned:\n";

			foreach (ListViewItem lvi in invalid_assemblies) {
				msg += string.Format ("{0}\n", lvi.Text);
				AssemblyListView.Items.Remove (lvi);
			}
			
			if (invalid_assemblies.Count == 0)
				return string.Empty;
				
			return msg;
		}

		private void SetupMonoVersion ()
		{
			MonoVersionCombo.Items.Clear ();

			List<FileDefinition> versions = new List<FileDefinition> ();
			
			// Unix-y people may have downloaded definitions to their user folder
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				versions.AddRange (DefinitionHandler.FindAvailableVersions (Path.Combine (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "moma"), "Definitions")));
				
			versions.AddRange (DefinitionHandler.FindAvailableVersions (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Definitions")));

			versions.Sort ();
			
			foreach (FileDefinition fd in versions)
				MonoVersionCombo.Items.Add (fd);

			if (MonoVersionCombo.Items.Count > 0)
				MonoVersionCombo.SelectedIndex = 0;
		}

		private void CheckUpdateLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			FileDefinition fd = DefinitionHandler.CheckLatestVersionFromInternet ();
			
			if (MonoVersionCombo.Items.Count == 0 || fd.Date > (MonoVersionCombo.Items[0] as FileDefinition).Date) {
				DefinitionDownloader dd = new DefinitionDownloader ();
				dd.LoadDefinitionFile (fd);
				if (dd.ShowDialog () == DialogResult.OK)
					SetupMonoVersion ();
			}
			else
				MessageBox.Show (string.Format ("You have the most recent version: {0}", (MonoVersionCombo.Items[0] as FileDefinition).Version));
		}
		
		private void LoadImages ()
		{
			try {
				this.BackgroundImage = Image.FromFile (Path.Combine (image_directory, "monoback.png"));
				DirectoryAddButton.Image = Image.FromFile (Path.Combine (image_directory, "list-directory.png"));
				AssemblyAddButton.Image = Image.FromFile (Path.Combine (image_directory, "list-add.png"));
				AssemblyRemoveButton.Image = Image.FromFile (Path.Combine (image_directory, "list-remove.png"));
				success_image = Image.FromFile (Path.Combine (image_directory, "button_ok.png"));
				failed_image = Image.FromFile (Path.Combine (image_directory, "dialog-warning.png"));
				ScanningSpinner.Image = Image.FromFile (Path.Combine (image_directory, "spinner.gif"));
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("There was an error loading resources for MoMA, please try downloading a new copy.\nError: {0}", ex.ToString ()));
			}
		}

		private void DirectoryAddButton_Click (object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog ();
			fbd.Description = "Choose the directory that contains the assemblies to scan.";
			fbd.ShowNewFolderButton = false;
			
			if (fbd.ShowDialog () != DialogResult.OK)
				return;

			AssemblyListView.BeginUpdate ();
			
			ScanForAssemblies (fbd.SelectedPath);
			
			AssemblyListView.EndUpdate ();
		}
		
		private void ScanForAssemblies (string path)
		{
			foreach (string file in Directory.GetFiles (path, "*.dll"))
				AddAssembly (file);
			foreach (string file in Directory.GetFiles (path, "*.exe"))
				AddAssembly (file);
				
			foreach (string directory in Directory.GetDirectories (path))
				ScanForAssemblies (directory);
		}

		private void DownloadMonoButton_Click (object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.go-mono.com/mono-downloads/download.html");
		}

		private void DownloadMonoDevelopButton_Click (object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.monodevelop.com/");
		}

		private void GettingStartedButton_Click (object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.mono-project.com/Start");
		}
		#endregion

		#region Static Methods
		private static void EnsureOutputDirectory (string path)
		{
			if (!Directory.Exists (Path.GetDirectoryName (path)))
				Directory.CreateDirectory (Path.GetDirectoryName (path));
		}

		private static void EnsureReportMedia (string reports_path)
		{
			try {
				string media_path = Path.Combine (reports_path, "Media");
				string source_path = Path.Combine (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports"), "Media");

				if (!Directory.Exists (media_path))
					Directory.CreateDirectory (media_path);

				if (!File.Exists (Path.Combine (media_path, "moma.css")))
					File.Copy (Path.Combine (source_path, "moma.css"), Path.Combine (media_path, "moma.css"));
				if (!File.Exists (Path.Combine (media_path, "moma.js")))
					File.Copy (Path.Combine (source_path, "moma.js"), Path.Combine (media_path, "moma.js"));
				if (!File.Exists (Path.Combine (media_path, "fail.png")))
					File.Copy (Path.Combine (source_path, "fail.png"), Path.Combine (media_path, "fail.png"));
				if (!File.Exists (Path.Combine (media_path, "pass.png")))
					File.Copy (Path.Combine (source_path, "pass.png"), Path.Combine (media_path, "pass.png"));
				if (!File.Exists (Path.Combine (media_path, "plus.png")))
					File.Copy (Path.Combine (source_path, "plus.png"), Path.Combine (media_path, "plus.png"));
				if (!File.Exists (Path.Combine (media_path, "minus.png")))
					File.Copy (Path.Combine (source_path, "minus.png"), Path.Combine (media_path, "minus.png"));
			} catch {
			}
		}

		private static string GetDefaultReportFolder ()
		{
			// Unix-y people generally can't write to where the executable is
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				return Path.Combine (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "moma"), "Reports");
			else
				return Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports");
		}
		#endregion
	}
}
