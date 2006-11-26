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

		public MainForm ()
		{
			InitializeComponent ();

			ResetForm ();
			SetupForm (WizardStep.Introduction);
		}

		private void ResetForm ()
		{
			IntroductionLabel.Visible = false;

			AssemblyAddButton.Visible = false;
			AssemblyListView.Visible = false;
			AssemblyRemoveButton.Visible = false;
			AssemblyLabel.Visible = false;
			AssemblyInstructions.Visible = false;

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
					if (AssemblyListView.Items.Count == 0)
					{
						MessageBox.Show ("Please choose at least one assembly to analyze.");
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

			if (ofd.ShowDialog () == DialogResult.OK) {
				foreach (string s in ofd.FileNames) {
					ListViewItem lvi = new ListViewItem (System.IO.Path.GetFileName (s));
					lvi.Tag = s;

					AssemblyListView.Items.Add (lvi);
				}
			}
		}

		private void AssemblyRemoveButton_Click (object sender, EventArgs e)
		{
			if (AssemblyListView.SelectedItems.Count > 0)
				AssemblyListView.Items.Remove (AssemblyListView.SelectedItems[0]);
		}

		private void AnalyzeAssemblies ()
		{
			AssemblyAnalyzer aa = new AssemblyAnalyzer ();

			// Keep total counts for all assemblies for summary screen
			int monotodocount = 0;
			int notimplementedcount = 0;
			int pinvokecount = 0;
			int missingcount = 0;

			string todo_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "monotodo.txt");
			string nie_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "exception.txt");
			string missing_defs = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "missing.txt");
			
			// Load the definition files
			aa.LoadDefinitions (todo_defs, nie_defs, missing_defs);
			
			// Scan user's assemblies for P/Invokes
			foreach (ListViewItem lvi in AssemblyListView.Items)
				aa.ScanAssemblyForPInvokes ((string)lvi.Tag);
				
			// Start the results reports
			if (!Directory.Exists (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports")))
				Directory.CreateDirectory (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports"));
			
			string output_path = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports");		
			XhtmlTextWriter report = aa.BeginHtmlReport (new FileStream (Path.Combine (output_path, "output.html"), FileMode.Create));
			StreamWriter submit_report = aa.BeginTextReport (new FileStream (Path.Combine (output_path, "submit.txt"), FileMode.Create));
			
			// Scan user's assemblies for issues
			foreach (ListViewItem lvi in AssemblyListView.Items)
			{
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
				aa.NotImplementedExceptionResults.Clear  ();
				aa.PInvokeResults.Clear ();
			}
			
			// Finish up the reports
			aa.FinishHtmlReport (report);
			aa.FinishTextReport (submit_report);

			// Update the summary screen
			UpdateResultsSummary (monotodocount, notimplementedcount, pinvokecount, missingcount);
			
			// Enable the report submission button
			SubmitReportButton.Enabled = true;
		}

		private void UpdateResultsSummary (int monotodocount, int notimplementedcount, int pinvokecount, int missingcount)
		{
			if (monotodocount == 0) {
				MonoTodoResultsImage.Image = MoMA.Properties.Resources.button_ok;
				MonoTodoResultsLabel.Text = "No methods marked with [MonoTodo] are called.";
			}
			else {
				MonoTodoResultsImage.Image = MoMA.Properties.Resources.dialog_warning;
				MonoTodoResultsLabel.Text = String.Format ("Methods called marked with [MonoTodo]: {0}", monotodocount);
			}

			if (notimplementedcount == 0) {
				NotImplementedResultsImage.Image = MoMA.Properties.Resources.button_ok;
				NotImplementedResultsLabel.Text = "No methods that throw NotImplementedException are called.";
			}
			else {
				NotImplementedResultsImage.Image = MoMA.Properties.Resources.dialog_warning;
				NotImplementedResultsLabel.Text = String.Format ("Methods called that throw NotImplementedException: {0}", notimplementedcount);
			}

			if (pinvokecount == 0) {
				PInvokesResultsImage.Image = MoMA.Properties.Resources.button_ok;
				PInvokesResultsLabel.Text = "No P/Invokes are called.";
			}
			else {
				PInvokesResultsImage.Image = MoMA.Properties.Resources.dialog_warning;
				PInvokesResultsLabel.Text = String.Format ("P/Invokes called: {0}", pinvokecount);
			}

			if (missingcount == 0) {
				MissingResultsImage.Image = MoMA.Properties.Resources.button_ok;
				MissingResultsLabel.Text = "All methods called exist in Mono.";
			}
			else {
				MissingResultsImage.Image = MoMA.Properties.Resources.dialog_warning;
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
			System.Diagnostics.Process.Start (Path.Combine (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports"), "output.html"));
		}

		private void ProjectLink_LinkClicked (object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start ("http://www.mono-project.com/");
		}

		private void ViewReportButton_Click (object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start (Path.Combine (Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports"), "submit.txt"));
		}

		private void SubmitReportButton_Click (object sender, EventArgs e)
		{
			SubmitReportButton.Enabled = false;
			
			string output_path = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Reports");
			StreamReader sr = new StreamReader (new FileStream (Path.Combine (output_path, "submit.txt"), FileMode.Open));
			
			string results = sr.ReadToEnd ();
			
			MoMAWebServices.MoMASubmit ws = new MoMA.MoMAWebServices.MoMASubmit ();
			
			if (ws.SubmitResults (results))	
				MessageBox.Show ("Results successfully submitted.  Thanks!");
			else
				MessageBox.Show ("Result submission failed.  Please try again later.");
		}
		
		private void VerifyValidAssemblies ()
		{
			List<ListViewItem> invalid_assemblies = new List<ListViewItem> ();

			foreach (ListViewItem lvi in AssemblyListView.Items)
				if (!AssemblyAnalyzer.IsValidAssembly ((string)lvi.Tag))
					invalid_assemblies.Add (lvi);

			string msg = "The following are not valid .Net assemblies and will not be scanned:\n";

			foreach (ListViewItem lvi in invalid_assemblies)
			{
				msg += string.Format ("{0}\n", lvi.Text);
				AssemblyListView.Items.Remove (lvi);
			}
			
			if (invalid_assemblies.Count > 0)
				MessageBox.Show (msg);
		}
	}
}