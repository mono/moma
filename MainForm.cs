using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Web.UI;
using System.IO;
using MoMA.Analyzer;

namespace MoMA
{
	public partial class MainForm : Form
	{
		private WizardStep current_step;
		private AssemblyAnalyzer aa;
		private string loaded_definitions;
		private string image_directory;
		
		private Image success_image;
		private Image failed_image;
		private string report_filename;
		private string submit_filename;
		
		public MainForm ()
		{
			InitializeComponent ();

			image_directory = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Resources");
			LoadImages ();
			
			// Process.Start doesn't work on Unix, so we'll just hide the link
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				ProjectLink.Visible = false;
				
			ResetForm ();
			SetupForm (WizardStep.Introduction);
			SetupMonoVersion ();
			aa = new AssemblyAnalyzer ();
		}

		public void AddAssembly (string path)
		{
			if (!ListContainsAssembly (Path.GetFileName (path))) {
				ListViewItem lvi = new ListViewItem (Path.GetFileName (path));
				lvi.Tag = path;

				AssemblyListView.Items.Add (lvi);
			}
		}

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
					submit_filename = Path.Combine (GetDefaultReportFolder (), "submit.txt");

				return submit_filename;
			}
			set { submit_filename = value; }
		}

		private void ResetForm ()
		{
			IntroductionLabel.Visible = false;

			AssemblyAddButton.Visible = false;
			AssemblyListView.Visible = false;
			AssemblyRemoveButton.Visible = false;
			AssemblyLabel.Visible = false;
			AssemblyInstructions.Visible = false;
			CheckUpdateLink.Visible = false;
			MonoVersionCombo.Visible = false;
			MonoVersionLabel.Visible = false;

			AnalysisResultsLabel.Visible = false;
			MonoTodoResultsImage.Visible = false;
			MonoTodoResultsLabel.Visible = false;
			NotImplementedResultsImage.Visible = false;
			NotImplementedResultsLabel.Visible = false;
			PInvokesResultsImage.Visible = false;
			PInvokesResultsLabel.Visible = false;
			MissingResultsImage.Visible = false;
			MissingResultsLabel.Visible = false;
			ResultsDetailLink.Visible = false;
			ResultsText.Visible = false;

			SubmitInstructions.Visible = false;
			SubmitLabel.Visible = false;
			SubmitReportButton.Visible = false;
			ViewReportButton.Visible = false;
			OptionalGroupBox.Visible = false;
		}

		private void SetupForm (WizardStep step)
		{
			switch (step) {
				case WizardStep.Introduction:
					IntroductionLabel.Visible = true;
					break;
				case WizardStep.ChooseAssemblies:
					AssemblyAddButton.Visible = true;
					AssemblyListView.Visible = true;
					AssemblyRemoveButton.Visible = true;
					AssemblyLabel.Visible = true;
					AssemblyInstructions.Visible = true;
					CheckUpdateLink.Visible = true;
					MonoVersionCombo.Visible = true;
					MonoVersionLabel.Visible = true;
					break;
				case WizardStep.ViewResults:
					AnalysisResultsLabel.Visible = true;
					MonoTodoResultsImage.Visible = true;
					MonoTodoResultsLabel.Visible = true;
					NotImplementedResultsImage.Visible = true;
					NotImplementedResultsLabel.Visible = true;
					PInvokesResultsImage.Visible = true;
					PInvokesResultsLabel.Visible = true;
					MissingResultsImage.Visible = true;
					MissingResultsLabel.Visible = true;
					ResultsText.Visible = true;
					NextButton.Text = "Next";
					if (ResultsText.Text.StartsWith ("There"))
						ResultsDetailLink.Visible = true;
					break;
				case WizardStep.SubmitResults:
					SubmitInstructions.Visible = true;
					SubmitLabel.Visible = true;
					SubmitReportButton.Visible = true;
					ViewReportButton.Visible = true;
					NextButton.Text = "Close";
					OptionalGroupBox.Visible = true;
					OptionalNameBox.Focus ();
					break;
			}

			StepLabel.Text = String.Format ("Step {0} of 4", (int)step);
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
					VerifyValidAssemblies ();
					if (AssemblyListView.Items.Count == 0) {
						MessageBox.Show ("Please choose at least one assembly to analyze.");
						return;
					}
					if (MonoVersionCombo.Items.Count == 0) {
						MessageBox.Show ("No definition files could be found.  Please try to download the latest definition file.");
						return;
					}
					AnalyzeAssemblies ();
					ResetForm ();
					SetupForm (WizardStep.ViewResults);
					break;
				case WizardStep.ViewResults:
					ResetForm ();
					SetupForm (WizardStep.SubmitResults);
					break;
				case WizardStep.SubmitResults:
					Application.Exit ();
					break;
			}

			BackButton.Enabled = true;
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

		public void AnalyzeAssemblies ()
		{
			// Keep total counts for all assemblies for summary screen
			int monotodocount = 0;
			int notimplementedcount = 0;
			int pinvokecount = 0;
			int missingcount = 0;

			string todo_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "monotodo.txt");
			string nie_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "exception.txt");
			string missing_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "missing.txt");

			// Load the definition files
			FileDefinition definitions = (FileDefinition)MonoVersionCombo.SelectedItem;

			if (definitions.FileName != loaded_definitions) {
				aa.LoadDefinitions (definitions.FileName);
				loaded_definitions = definitions.FileName;
			}

			// Scan user's assemblies for P/Invokes
			foreach (ListViewItem lvi in AssemblyListView.Items)
				aa.ScanAssemblyForPInvokes ((string)lvi.Tag);

			// Start the results reports
			EnsureOutputDirectory (this.ReportFileName);
			EnsureOutputDirectory (this.SubmitFileName);
			
			XhtmlTextWriter report = aa.BeginHtmlReport (new FileStream (this.ReportFileName, FileMode.Create));
			StreamWriter submit_report = aa.BeginTextReport (new FileStream (this.SubmitFileName, FileMode.Create));

			// Scan user's assemblies for issues
			foreach (ListViewItem lvi in AssemblyListView.Items) {
				aa.AnalyzeAssembly ((string)lvi.Tag);

				report.WriteFullBeginTag ("h2");
				report.WriteEncodedText (Path.GetFileName ((string)lvi.Tag));
				report.WriteEndTag ("h2");

				aa.AddResultsToHtmlReport (report);
				aa.AddResultsToTextReport (submit_report);

				monotodocount += aa.MonoTodoResults.Count;
				notimplementedcount += aa.NotImplementedExceptionResults.Count;
				pinvokecount += aa.PInvokeResults.Count;
				missingcount += aa.MissingMethodResults.Count;

				aa.MissingMethodResults.Clear ();
				aa.MonoTodoResults.Clear ();
				aa.NotImplementedExceptionResults.Clear ();
				aa.PInvokeResults.Clear ();
			}

			// Finish up the reports
			aa.FinishHtmlReport (report);
			
			if (monotodocount + notimplementedcount + pinvokecount + missingcount == 0)
				submit_report.WriteLine ("No Issues Found!");
				
			aa.FinishTextReport (submit_report);

			// Update the summary screen
			UpdateResultsSummary (monotodocount, notimplementedcount, pinvokecount, missingcount);

			// Enable the report submission button
			SubmitReportButton.Enabled = true;
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
				MessageBox.Show (string.Format("The detail report can be viewed here:\n{0}", this.ReportFileName));
			}
		}

		private void ProjectLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.mono-project.com/");
		}

		private void ViewReportButton_Click (object sender, EventArgs e)
		{
			try {	        
				System.Diagnostics.Process.Start (SubmitFileName);	
			}
			catch (Exception) {
				MessageBox.Show (string.Format ("The report that will be submitted can be viewed here:\n{0}", SubmitFileName));
			}
		}

		private void SubmitReportButton_Click (object sender, EventArgs e)
		{
			SubmitReportButton.Enabled = false;

			try {
				using (StreamReader sr = new StreamReader (SubmitFileName)) {
					string results = sr.ReadToEnd ();

					if (AssemblyAnalyzer.SubmitResults (results, (MonoVersionCombo.Items[0] as FileDefinition).Version, OptionalNameBox.Text, OptionalEmailBox.Text, OptionalOrganizationBox.Text, OptionalHomePageBox.Text, OptionalCommentsBox.Text))
						MessageBox.Show ("Results successfully submitted.  Thanks!");
					else
						MessageBox.Show ("Result submission failed.  Please try again later.");
				}
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("Result submission failed (Exception={0}).", ex.ToString ()));
			}
		}

		private void VerifyValidAssemblies ()
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

			if (invalid_assemblies.Count > 0)
				MessageBox.Show (msg);
		}

		private void SetupMonoVersion ()
		{
			MonoVersionCombo.Items.Clear ();

			// Unix-y people may have downloaded definitions to their user folder
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				foreach (FileDefinition fd in DefinitionHandler.FindAvailableVersions (Path.Combine (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "moma"), "Definitions")))
					MonoVersionCombo.Items.Add (fd);
			foreach (FileDefinition fd in DefinitionHandler.FindAvailableVersions (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Definitions")))
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
				pictureBox1.Image = Image.FromFile (Path.Combine (image_directory, "monkey.png"));
				AssemblyAddButton.Image = Image.FromFile (Path.Combine (image_directory, "list-add.png"));
				AssemblyRemoveButton.Image = Image.FromFile (Path.Combine (image_directory, "list-remove.png"));
				success_image = Image.FromFile (Path.Combine (image_directory, "button_ok.png"));
				failed_image = Image.FromFile (Path.Combine (image_directory, "dialog-warning.png"));
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("There was an error loading resources for MoMA, please try downloading a new copy.\nError: {0}", ex.ToString ()));
			}
		}

		private static void EnsureOutputDirectory (string path)
		{
			if (!Directory.Exists (Path.GetDirectoryName (path)))
				Directory.CreateDirectory (Path.GetDirectoryName (path));
		}

		private static string GetDefaultReportFolder ()
		{
			// Unix-y people generally can't write to where the executable is
			if (Environment.OSVersion.Platform == PlatformID.Unix)
				return Path.Combine (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "moma"), "Reports");
			else
				return Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports");
		}
	}
}
