namespace MoMA
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			this.components = new System.ComponentModel.Container ();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (MainForm));
			this.NextButton = new System.Windows.Forms.Button ();
			this.BackButton = new System.Windows.Forms.Button ();
			this.StepLabel = new System.Windows.Forms.Label ();
			this.IntroductionLabel = new System.Windows.Forms.Label ();
			this.AssemblyLabel = new System.Windows.Forms.Label ();
			this.AssemblyAddButton = new System.Windows.Forms.Button ();
			this.AssemblyRemoveButton = new System.Windows.Forms.Button ();
			this.AssemblyListView = new System.Windows.Forms.ListView ();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader ();
			this.MonoTodoResultsLabel = new System.Windows.Forms.Label ();
			this.AnalysisResultsLabel = new System.Windows.Forms.Label ();
			this.NotImplementedResultsLabel = new System.Windows.Forms.Label ();
			this.PInvokesResultsLabel = new System.Windows.Forms.Label ();
			this.AssemblyInstructions = new System.Windows.Forms.Label ();
			this.MissingResultsLabel = new System.Windows.Forms.Label ();
			this.ResultsText = new System.Windows.Forms.Label ();
			this.ResultsDetailLink = new System.Windows.Forms.LinkLabel ();
			this.ProjectLink = new System.Windows.Forms.LinkLabel ();
			this.SubmitLabel = new System.Windows.Forms.Label ();
			this.SubmitInstructions = new System.Windows.Forms.Label ();
			this.SubmitReportButton = new System.Windows.Forms.Button ();
			this.label2 = new System.Windows.Forms.Label ();
			this.MonoVersionCombo = new System.Windows.Forms.ComboBox ();
			this.MonoVersionLabel = new System.Windows.Forms.Label ();
			this.CheckUpdateLink = new System.Windows.Forms.LinkLabel ();
			this.DirectoryAddButton = new System.Windows.Forms.Button ();
			this.toolTip1 = new System.Windows.Forms.ToolTip (this.components);
			this.WhatsNextLabel = new System.Windows.Forms.Label ();
			this.Step1Panel = new System.Windows.Forms.Panel ();
			this.Step4Panel = new System.Windows.Forms.Panel ();
			this.label4 = new System.Windows.Forms.Label ();
			this.DescriptionComboBox = new System.Windows.Forms.ComboBox ();
			this.label3 = new System.Windows.Forms.Label ();
			this.OptionalHomePageBox = new System.Windows.Forms.TextBox ();
			this.OptionalOrganizationBox = new System.Windows.Forms.TextBox ();
			this.OptionalCommentsBox = new System.Windows.Forms.TextBox ();
			this.label1 = new System.Windows.Forms.Label ();
			this.OptionalEmailBox = new System.Windows.Forms.TextBox ();
			this.label8 = new System.Windows.Forms.Label ();
			this.OptionalNameBox = new System.Windows.Forms.TextBox ();
			this.label9 = new System.Windows.Forms.Label ();
			this.label11 = new System.Windows.Forms.Label ();
			this.label10 = new System.Windows.Forms.Label ();
			this.Step3Panel = new System.Windows.Forms.Panel ();
			this.MonoTodoResultsImage = new System.Windows.Forms.PictureBox ();
			this.NotImplementedResultsImage = new System.Windows.Forms.PictureBox ();
			this.PInvokesResultsImage = new System.Windows.Forms.PictureBox ();
			this.MissingResultsImage = new System.Windows.Forms.PictureBox ();
			this.Step2Panel = new System.Windows.Forms.Panel ();
			this.ScanningSpinner = new System.Windows.Forms.PictureBox ();
			this.ScanningLabel = new System.Windows.Forms.Label ();
			this.Step5Panel = new System.Windows.Forms.Panel ();
			this.GettingStartedButton = new MoMA.WhatsNextButton ();
			this.DownloadMonoButton = new MoMA.WhatsNextButton ();
			this.DownloadMonoDevelopButton = new MoMA.WhatsNextButton ();
			this.Step1Panel.SuspendLayout ();
			this.Step4Panel.SuspendLayout ();
			this.Step3Panel.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.MonoTodoResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.NotImplementedResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.PInvokesResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.MissingResultsImage)).BeginInit ();
			this.Step2Panel.SuspendLayout ();
			((System.ComponentModel.ISupportInitialize)(this.ScanningSpinner)).BeginInit ();
			this.Step5Panel.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// NextButton
			// 
			this.NextButton.Location = new System.Drawing.Point (621, 429);
			this.NextButton.Name = "NextButton";
			this.NextButton.Size = new System.Drawing.Size (86, 30);
			this.NextButton.TabIndex = 1;
			this.NextButton.Text = "Next";
			this.NextButton.UseVisualStyleBackColor = true;
			this.NextButton.Click += new System.EventHandler (this.NextButton_Click);
			// 
			// BackButton
			// 
			this.BackButton.Enabled = false;
			this.BackButton.Location = new System.Drawing.Point (529, 429);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size (86, 30);
			this.BackButton.TabIndex = 2;
			this.BackButton.Text = "Back";
			this.BackButton.UseVisualStyleBackColor = true;
			this.BackButton.Click += new System.EventHandler (this.BackButton_Click);
			// 
			// StepLabel
			// 
			this.StepLabel.BackColor = System.Drawing.Color.Transparent;
			this.StepLabel.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StepLabel.Location = new System.Drawing.Point (279, 429);
			this.StepLabel.Name = "StepLabel";
			this.StepLabel.Size = new System.Drawing.Size (101, 14);
			this.StepLabel.TabIndex = 4;
			this.StepLabel.Text = "Step 1 of 5";
			this.StepLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// IntroductionLabel
			// 
			this.IntroductionLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntroductionLabel.Location = new System.Drawing.Point (34, 27);
			this.IntroductionLabel.Name = "IntroductionLabel";
			this.IntroductionLabel.Size = new System.Drawing.Size (530, 202);
			this.IntroductionLabel.TabIndex = 5;
			this.IntroductionLabel.Text = resources.GetString ("IntroductionLabel.Text");
			// 
			// AssemblyLabel
			// 
			this.AssemblyLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AssemblyLabel.Location = new System.Drawing.Point (70, 21);
			this.AssemblyLabel.Name = "AssemblyLabel";
			this.AssemblyLabel.Size = new System.Drawing.Size (416, 20);
			this.AssemblyLabel.TabIndex = 6;
			this.AssemblyLabel.Text = "Choose the assemblies to analyze:";
			// 
			// AssemblyAddButton
			// 
			this.AssemblyAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AssemblyAddButton.Location = new System.Drawing.Point (488, 84);
			this.AssemblyAddButton.Name = "AssemblyAddButton";
			this.AssemblyAddButton.Size = new System.Drawing.Size (30, 30);
			this.AssemblyAddButton.TabIndex = 8;
			this.AssemblyAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip (this.AssemblyAddButton, "Add Assembly");
			this.AssemblyAddButton.UseVisualStyleBackColor = true;
			this.AssemblyAddButton.Click += new System.EventHandler (this.AssemblyAddButton_Click);
			// 
			// AssemblyRemoveButton
			// 
			this.AssemblyRemoveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.AssemblyRemoveButton.Location = new System.Drawing.Point (488, 120);
			this.AssemblyRemoveButton.Name = "AssemblyRemoveButton";
			this.AssemblyRemoveButton.Size = new System.Drawing.Size (30, 30);
			this.AssemblyRemoveButton.TabIndex = 9;
			this.AssemblyRemoveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip (this.AssemblyRemoveButton, "Remove Assembly");
			this.AssemblyRemoveButton.UseVisualStyleBackColor = true;
			this.AssemblyRemoveButton.Click += new System.EventHandler (this.AssemblyRemoveButton_Click);
			// 
			// AssemblyListView
			// 
			this.AssemblyListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.AssemblyListView.FullRowSelect = true;
			this.AssemblyListView.Location = new System.Drawing.Point (70, 49);
			this.AssemblyListView.Name = "AssemblyListView";
			this.AssemblyListView.Size = new System.Drawing.Size (413, 145);
			this.AssemblyListView.TabIndex = 10;
			this.AssemblyListView.UseCompatibleStateImageBehavior = false;
			this.AssemblyListView.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Assembly";
			this.columnHeader1.Width = 409;
			// 
			// MonoTodoResultsLabel
			// 
			this.MonoTodoResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MonoTodoResultsLabel.Location = new System.Drawing.Point (117, 135);
			this.MonoTodoResultsLabel.Name = "MonoTodoResultsLabel";
			this.MonoTodoResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.MonoTodoResultsLabel.TabIndex = 12;
			this.MonoTodoResultsLabel.Text = "Methods marked with [MonoTodo] called: 0";
			// 
			// AnalysisResultsLabel
			// 
			this.AnalysisResultsLabel.Font = new System.Drawing.Font ("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AnalysisResultsLabel.Location = new System.Drawing.Point (39, 13);
			this.AnalysisResultsLabel.Name = "AnalysisResultsLabel";
			this.AnalysisResultsLabel.Size = new System.Drawing.Size (416, 20);
			this.AnalysisResultsLabel.TabIndex = 14;
			this.AnalysisResultsLabel.Text = "Analysis Summary:";
			// 
			// NotImplementedResultsLabel
			// 
			this.NotImplementedResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NotImplementedResultsLabel.Location = new System.Drawing.Point (117, 107);
			this.NotImplementedResultsLabel.Name = "NotImplementedResultsLabel";
			this.NotImplementedResultsLabel.Size = new System.Drawing.Size (395, 20);
			this.NotImplementedResultsLabel.TabIndex = 16;
			this.NotImplementedResultsLabel.Text = "Methods called that throw NotImplementedException: 0";
			// 
			// PInvokesResultsLabel
			// 
			this.PInvokesResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PInvokesResultsLabel.Location = new System.Drawing.Point (117, 79);
			this.PInvokesResultsLabel.Name = "PInvokesResultsLabel";
			this.PInvokesResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.PInvokesResultsLabel.TabIndex = 19;
			this.PInvokesResultsLabel.Text = "P/Invokes called: 0";
			// 
			// AssemblyInstructions
			// 
			this.AssemblyInstructions.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AssemblyInstructions.Location = new System.Drawing.Point (70, 204);
			this.AssemblyInstructions.Name = "AssemblyInstructions";
			this.AssemblyInstructions.Size = new System.Drawing.Size (413, 54);
			this.AssemblyInstructions.TabIndex = 21;
			this.AssemblyInstructions.Text = "Select the main assembly (.exe or .dll) as well as any referenced user libraries " +
			    "(.dll).  (Do not select assemblies that ship with .Net, like System.Xml or Syste" +
			    "m.Windows.Forms.)";
			// 
			// MissingResultsLabel
			// 
			this.MissingResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MissingResultsLabel.Location = new System.Drawing.Point (117, 51);
			this.MissingResultsLabel.Name = "MissingResultsLabel";
			this.MissingResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.MissingResultsLabel.TabIndex = 23;
			this.MissingResultsLabel.Text = "Methods that still missing in Mono: 0";
			// 
			// ResultsText
			// 
			this.ResultsText.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsText.Location = new System.Drawing.Point (67, 197);
			this.ResultsText.Name = "ResultsText";
			this.ResultsText.Size = new System.Drawing.Size (416, 54);
			this.ResultsText.TabIndex = 24;
			this.ResultsText.Text = "Congratulations!  No potential issues were detected in your assemblies.  The only" +
			    " thing left to do is to try running them on Mono and see what happens.";
			// 
			// ResultsDetailLink
			// 
			this.ResultsDetailLink.AutoSize = true;
			this.ResultsDetailLink.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsDetailLink.Location = new System.Drawing.Point (368, 251);
			this.ResultsDetailLink.Name = "ResultsDetailLink";
			this.ResultsDetailLink.Size = new System.Drawing.Size (115, 16);
			this.ResultsDetailLink.TabIndex = 25;
			this.ResultsDetailLink.TabStop = true;
			this.ResultsDetailLink.Text = "View Detail Report";
			this.ResultsDetailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.ResultsDetailLink_LinkClicked);
			// 
			// ProjectLink
			// 
			this.ProjectLink.BackColor = System.Drawing.Color.Transparent;
			this.ProjectLink.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProjectLink.Location = new System.Drawing.Point (255, 445);
			this.ProjectLink.Name = "ProjectLink";
			this.ProjectLink.Size = new System.Drawing.Size (172, 14);
			this.ProjectLink.TabIndex = 26;
			this.ProjectLink.TabStop = true;
			this.ProjectLink.Text = "http://www.mono-project.com";
			this.ProjectLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.ProjectLink_LinkClicked);
			// 
			// SubmitLabel
			// 
			this.SubmitLabel.Font = new System.Drawing.Font ("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SubmitLabel.Location = new System.Drawing.Point (39, 13);
			this.SubmitLabel.Name = "SubmitLabel";
			this.SubmitLabel.Size = new System.Drawing.Size (416, 20);
			this.SubmitLabel.TabIndex = 27;
			this.SubmitLabel.Text = "Submit Results:";
			// 
			// SubmitInstructions
			// 
			this.SubmitInstructions.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SubmitInstructions.Location = new System.Drawing.Point (40, 37);
			this.SubmitInstructions.Name = "SubmitInstructions";
			this.SubmitInstructions.Size = new System.Drawing.Size (483, 37);
			this.SubmitInstructions.TabIndex = 28;
			this.SubmitInstructions.Text = "Want to help out the Mono project?  Please submit your results to the Mono team s" +
			    "o they can prioritize their efforts based on what functionality people need most" +
			    ".";
			// 
			// SubmitReportButton
			// 
			this.SubmitReportButton.Enabled = false;
			this.SubmitReportButton.Location = new System.Drawing.Point (459, 276);
			this.SubmitReportButton.Name = "SubmitReportButton";
			this.SubmitReportButton.Size = new System.Drawing.Size (86, 30);
			this.SubmitReportButton.TabIndex = 7;
			this.SubmitReportButton.Text = "Submit Report";
			this.SubmitReportButton.UseVisualStyleBackColor = true;
			this.SubmitReportButton.Click += new System.EventHandler (this.SubmitReportButton_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point (9, 445);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (103, 14);
			this.label2.TabIndex = 32;
			this.label2.Text = "Version 2.2";
			// 
			// MonoVersionCombo
			// 
			this.MonoVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonoVersionCombo.FormattingEnabled = true;
			this.MonoVersionCombo.Location = new System.Drawing.Point (283, 265);
			this.MonoVersionCombo.Name = "MonoVersionCombo";
			this.MonoVersionCombo.Size = new System.Drawing.Size (140, 21);
			this.MonoVersionCombo.TabIndex = 34;
			// 
			// MonoVersionLabel
			// 
			this.MonoVersionLabel.AutoSize = true;
			this.MonoVersionLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MonoVersionLabel.Location = new System.Drawing.Point (108, 266);
			this.MonoVersionLabel.Name = "MonoVersionLabel";
			this.MonoVersionLabel.Size = new System.Drawing.Size (169, 16);
			this.MonoVersionLabel.TabIndex = 35;
			this.MonoVersionLabel.Text = "Test Against Mono Version:";
			// 
			// CheckUpdateLink
			// 
			this.CheckUpdateLink.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CheckUpdateLink.Location = new System.Drawing.Point (286, 292);
			this.CheckUpdateLink.Name = "CheckUpdateLink";
			this.CheckUpdateLink.Size = new System.Drawing.Size (137, 14);
			this.CheckUpdateLink.TabIndex = 36;
			this.CheckUpdateLink.TabStop = true;
			this.CheckUpdateLink.Text = "Check for newer version";
			this.CheckUpdateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.CheckUpdateLink_LinkClicked);
			// 
			// DirectoryAddButton
			// 
			this.DirectoryAddButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.DirectoryAddButton.Location = new System.Drawing.Point (488, 48);
			this.DirectoryAddButton.Name = "DirectoryAddButton";
			this.DirectoryAddButton.Size = new System.Drawing.Size (30, 30);
			this.DirectoryAddButton.TabIndex = 38;
			this.DirectoryAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.toolTip1.SetToolTip (this.DirectoryAddButton, "Add Directory");
			this.DirectoryAddButton.UseVisualStyleBackColor = true;
			this.DirectoryAddButton.Click += new System.EventHandler (this.DirectoryAddButton_Click);
			// 
			// WhatsNextLabel
			// 
			this.WhatsNextLabel.Font = new System.Drawing.Font ("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WhatsNextLabel.Location = new System.Drawing.Point (39, 13);
			this.WhatsNextLabel.Name = "WhatsNextLabel";
			this.WhatsNextLabel.Size = new System.Drawing.Size (416, 20);
			this.WhatsNextLabel.TabIndex = 39;
			this.WhatsNextLabel.Text = "What\'s Next?";
			// 
			// Step1Panel
			// 
			this.Step1Panel.BackColor = System.Drawing.Color.Transparent;
			this.Step1Panel.Controls.Add (this.IntroductionLabel);
			this.Step1Panel.Location = new System.Drawing.Point (73, 60);
			this.Step1Panel.Name = "Step1Panel";
			this.Step1Panel.Size = new System.Drawing.Size (567, 358);
			this.Step1Panel.TabIndex = 41;
			this.Step1Panel.Visible = false;
			// 
			// Step4Panel
			// 
			this.Step4Panel.BackColor = System.Drawing.Color.Transparent;
			this.Step4Panel.Controls.Add (this.label4);
			this.Step4Panel.Controls.Add (this.DescriptionComboBox);
			this.Step4Panel.Controls.Add (this.label3);
			this.Step4Panel.Controls.Add (this.OptionalHomePageBox);
			this.Step4Panel.Controls.Add (this.SubmitInstructions);
			this.Step4Panel.Controls.Add (this.OptionalOrganizationBox);
			this.Step4Panel.Controls.Add (this.OptionalCommentsBox);
			this.Step4Panel.Controls.Add (this.SubmitReportButton);
			this.Step4Panel.Controls.Add (this.label1);
			this.Step4Panel.Controls.Add (this.OptionalEmailBox);
			this.Step4Panel.Controls.Add (this.label8);
			this.Step4Panel.Controls.Add (this.OptionalNameBox);
			this.Step4Panel.Controls.Add (this.SubmitLabel);
			this.Step4Panel.Controls.Add (this.label9);
			this.Step4Panel.Controls.Add (this.label11);
			this.Step4Panel.Controls.Add (this.label10);
			this.Step4Panel.Location = new System.Drawing.Point (73, 60);
			this.Step4Panel.Name = "Step4Panel";
			this.Step4Panel.Size = new System.Drawing.Size (567, 358);
			this.Step4Panel.TabIndex = 42;
			this.Step4Panel.Visible = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point (43, 140);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (237, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "Please tell us a little bit about you/your company:";
			// 
			// DescriptionComboBox
			// 
			this.DescriptionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DescriptionComboBox.FormattingEnabled = true;
			this.DescriptionComboBox.Items.AddRange (new object[] {
            "Corporate Website",
            "Public Website",
            "Corporate Desktop Application",
            "Desktop Application for Resale",
            "Web Application for Resale",
            "Open Source Project",
            "Other"});
			this.DescriptionComboBox.Location = new System.Drawing.Point (46, 110);
			this.DescriptionComboBox.Name = "DescriptionComboBox";
			this.DescriptionComboBox.Size = new System.Drawing.Size (247, 21);
			this.DescriptionComboBox.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point (43, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (260, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "Please choose the best description of this application:";
			// 
			// OptionalHomePageBox
			// 
			this.OptionalHomePageBox.Location = new System.Drawing.Point (118, 234);
			this.OptionalHomePageBox.Name = "OptionalHomePageBox";
			this.OptionalHomePageBox.Size = new System.Drawing.Size (175, 20);
			this.OptionalHomePageBox.TabIndex = 5;
			// 
			// OptionalOrganizationBox
			// 
			this.OptionalOrganizationBox.Location = new System.Drawing.Point (118, 208);
			this.OptionalOrganizationBox.Name = "OptionalOrganizationBox";
			this.OptionalOrganizationBox.Size = new System.Drawing.Size (175, 20);
			this.OptionalOrganizationBox.TabIndex = 4;
			// 
			// OptionalCommentsBox
			// 
			this.OptionalCommentsBox.Location = new System.Drawing.Point (324, 110);
			this.OptionalCommentsBox.Multiline = true;
			this.OptionalCommentsBox.Name = "OptionalCommentsBox";
			this.OptionalCommentsBox.Size = new System.Drawing.Size (226, 144);
			this.OptionalCommentsBox.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point (321, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (108, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Additional Comments:";
			// 
			// OptionalEmailBox
			// 
			this.OptionalEmailBox.Location = new System.Drawing.Point (90, 182);
			this.OptionalEmailBox.Name = "OptionalEmailBox";
			this.OptionalEmailBox.Size = new System.Drawing.Size (203, 20);
			this.OptionalEmailBox.TabIndex = 3;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point (44, 160);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size (41, 13);
			this.label8.TabIndex = 1;
			this.label8.Text = "Name: ";
			// 
			// OptionalNameBox
			// 
			this.OptionalNameBox.Location = new System.Drawing.Point (90, 158);
			this.OptionalNameBox.Name = "OptionalNameBox";
			this.OptionalNameBox.Size = new System.Drawing.Size (203, 20);
			this.OptionalNameBox.TabIndex = 2;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point (43, 186);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size (35, 13);
			this.label9.TabIndex = 9;
			this.label9.Text = "Email:";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point (43, 211);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size (69, 13);
			this.label11.TabIndex = 2;
			this.label11.Text = "Organization:";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point (43, 237);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size (66, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "Home Page:";
			// 
			// Step3Panel
			// 
			this.Step3Panel.BackColor = System.Drawing.Color.Transparent;
			this.Step3Panel.Controls.Add (this.AnalysisResultsLabel);
			this.Step3Panel.Controls.Add (this.MonoTodoResultsImage);
			this.Step3Panel.Controls.Add (this.MonoTodoResultsLabel);
			this.Step3Panel.Controls.Add (this.NotImplementedResultsImage);
			this.Step3Panel.Controls.Add (this.NotImplementedResultsLabel);
			this.Step3Panel.Controls.Add (this.PInvokesResultsImage);
			this.Step3Panel.Controls.Add (this.PInvokesResultsLabel);
			this.Step3Panel.Controls.Add (this.MissingResultsImage);
			this.Step3Panel.Controls.Add (this.MissingResultsLabel);
			this.Step3Panel.Controls.Add (this.ResultsText);
			this.Step3Panel.Controls.Add (this.ResultsDetailLink);
			this.Step3Panel.Location = new System.Drawing.Point (73, 60);
			this.Step3Panel.Name = "Step3Panel";
			this.Step3Panel.Size = new System.Drawing.Size (567, 358);
			this.Step3Panel.TabIndex = 43;
			this.Step3Panel.Visible = false;
			// 
			// MonoTodoResultsImage
			// 
			this.MonoTodoResultsImage.Location = new System.Drawing.Point (90, 133);
			this.MonoTodoResultsImage.Name = "MonoTodoResultsImage";
			this.MonoTodoResultsImage.Size = new System.Drawing.Size (22, 22);
			this.MonoTodoResultsImage.TabIndex = 11;
			this.MonoTodoResultsImage.TabStop = false;
			// 
			// NotImplementedResultsImage
			// 
			this.NotImplementedResultsImage.Location = new System.Drawing.Point (90, 105);
			this.NotImplementedResultsImage.Name = "NotImplementedResultsImage";
			this.NotImplementedResultsImage.Size = new System.Drawing.Size (22, 22);
			this.NotImplementedResultsImage.TabIndex = 15;
			this.NotImplementedResultsImage.TabStop = false;
			// 
			// PInvokesResultsImage
			// 
			this.PInvokesResultsImage.Location = new System.Drawing.Point (90, 77);
			this.PInvokesResultsImage.Name = "PInvokesResultsImage";
			this.PInvokesResultsImage.Size = new System.Drawing.Size (22, 22);
			this.PInvokesResultsImage.TabIndex = 18;
			this.PInvokesResultsImage.TabStop = false;
			// 
			// MissingResultsImage
			// 
			this.MissingResultsImage.Location = new System.Drawing.Point (90, 49);
			this.MissingResultsImage.Name = "MissingResultsImage";
			this.MissingResultsImage.Size = new System.Drawing.Size (22, 22);
			this.MissingResultsImage.TabIndex = 22;
			this.MissingResultsImage.TabStop = false;
			// 
			// Step2Panel
			// 
			this.Step2Panel.BackColor = System.Drawing.Color.Transparent;
			this.Step2Panel.Controls.Add (this.ScanningSpinner);
			this.Step2Panel.Controls.Add (this.AssemblyLabel);
			this.Step2Panel.Controls.Add (this.ScanningLabel);
			this.Step2Panel.Controls.Add (this.AssemblyInstructions);
			this.Step2Panel.Controls.Add (this.AssemblyAddButton);
			this.Step2Panel.Controls.Add (this.AssemblyRemoveButton);
			this.Step2Panel.Controls.Add (this.AssemblyListView);
			this.Step2Panel.Controls.Add (this.DirectoryAddButton);
			this.Step2Panel.Controls.Add (this.MonoVersionCombo);
			this.Step2Panel.Controls.Add (this.CheckUpdateLink);
			this.Step2Panel.Controls.Add (this.MonoVersionLabel);
			this.Step2Panel.Location = new System.Drawing.Point (73, 60);
			this.Step2Panel.Name = "Step2Panel";
			this.Step2Panel.Size = new System.Drawing.Size (634, 366);
			this.Step2Panel.TabIndex = 44;
			this.Step2Panel.Visible = false;
			// 
			// ScanningSpinner
			// 
			this.ScanningSpinner.Location = new System.Drawing.Point (473, 329);
			this.ScanningSpinner.Name = "ScanningSpinner";
			this.ScanningSpinner.Size = new System.Drawing.Size (16, 16);
			this.ScanningSpinner.TabIndex = 47;
			this.ScanningSpinner.TabStop = false;
			this.ScanningSpinner.Visible = false;
			// 
			// ScanningLabel
			// 
			this.ScanningLabel.AutoSize = true;
			this.ScanningLabel.Location = new System.Drawing.Point (493, 331);
			this.ScanningLabel.Name = "ScanningLabel";
			this.ScanningLabel.Size = new System.Drawing.Size (115, 13);
			this.ScanningLabel.TabIndex = 46;
			this.ScanningLabel.Text = "Scanning assemblies...";
			this.ScanningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ScanningLabel.Visible = false;
			// 
			// Step5Panel
			// 
			this.Step5Panel.BackColor = System.Drawing.Color.Transparent;
			this.Step5Panel.Controls.Add (this.GettingStartedButton);
			this.Step5Panel.Controls.Add (this.DownloadMonoButton);
			this.Step5Panel.Controls.Add (this.DownloadMonoDevelopButton);
			this.Step5Panel.Controls.Add (this.WhatsNextLabel);
			this.Step5Panel.Location = new System.Drawing.Point (89, 60);
			this.Step5Panel.Name = "Step5Panel";
			this.Step5Panel.Size = new System.Drawing.Size (567, 358);
			this.Step5Panel.TabIndex = 45;
			this.Step5Panel.Visible = false;
			// 
			// GettingStartedButton
			// 
			this.GettingStartedButton.BackColor = System.Drawing.Color.White;
			this.GettingStartedButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.GettingStartedButton.Image = global::MoMA.Properties.Resources.start;
			this.GettingStartedButton.Location = new System.Drawing.Point (66, 250);
			this.GettingStartedButton.Name = "GettingStartedButton";
			this.GettingStartedButton.Size = new System.Drawing.Size (389, 76);
			this.GettingStartedButton.TabIndex = 43;
			this.GettingStartedButton.Text = "Visit the Mono webpage for guides on how to get started with Mono.";
			this.GettingStartedButton.Title = "Getting Started Guides";
			this.GettingStartedButton.Click += new System.EventHandler (this.GettingStartedButton_Click);
			// 
			// DownloadMonoButton
			// 
			this.DownloadMonoButton.BackColor = System.Drawing.Color.White;
			this.DownloadMonoButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DownloadMonoButton.Image = global::MoMA.Properties.Resources.monoicon;
			this.DownloadMonoButton.Location = new System.Drawing.Point (66, 57);
			this.DownloadMonoButton.Name = "DownloadMonoButton";
			this.DownloadMonoButton.Size = new System.Drawing.Size (389, 90);
			this.DownloadMonoButton.TabIndex = 42;
			this.DownloadMonoButton.Text = "Mono is available to run on Linux, OSX, and Windows.  A VMWare image of Linux wit" +
			    "h Mono already installed is also available.";
			this.DownloadMonoButton.Title = "Download Mono";
			this.DownloadMonoButton.Click += new System.EventHandler (this.DownloadMonoButton_Click);
			// 
			// DownloadMonoDevelopButton
			// 
			this.DownloadMonoDevelopButton.BackColor = System.Drawing.Color.White;
			this.DownloadMonoDevelopButton.Cursor = System.Windows.Forms.Cursors.Hand;
			this.DownloadMonoDevelopButton.Image = global::MoMA.Properties.Resources.mdicon;
			this.DownloadMonoDevelopButton.Location = new System.Drawing.Point (66, 158);
			this.DownloadMonoDevelopButton.Name = "DownloadMonoDevelopButton";
			this.DownloadMonoDevelopButton.Size = new System.Drawing.Size (389, 76);
			this.DownloadMonoDevelopButton.TabIndex = 41;
			this.DownloadMonoDevelopButton.Text = "MonoDevelop is an IDE tailored for creating Mono applications.  It is available f" +
			    "or both Linux and OSX.";
			this.DownloadMonoDevelopButton.Title = "Download MonoDevelop";
			this.DownloadMonoDevelopButton.Click += new System.EventHandler (this.DownloadMonoDevelopButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size (719, 471);
			this.Controls.Add (this.Step2Panel);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.ProjectLink);
			this.Controls.Add (this.StepLabel);
			this.Controls.Add (this.BackButton);
			this.Controls.Add (this.NextButton);
			this.Controls.Add (this.Step5Panel);
			this.Controls.Add (this.Step3Panel);
			this.Controls.Add (this.Step1Panel);
			this.Controls.Add (this.Step4Panel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject ("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MoMA: Mono Migration Analyzer";
			this.Step1Panel.ResumeLayout (false);
			this.Step4Panel.ResumeLayout (false);
			this.Step4Panel.PerformLayout ();
			this.Step3Panel.ResumeLayout (false);
			this.Step3Panel.PerformLayout ();
			((System.ComponentModel.ISupportInitialize)(this.MonoTodoResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.NotImplementedResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.PInvokesResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.MissingResultsImage)).EndInit ();
			this.Step2Panel.ResumeLayout (false);
			this.Step2Panel.PerformLayout ();
			((System.ComponentModel.ISupportInitialize)(this.ScanningSpinner)).EndInit ();
			this.Step5Panel.ResumeLayout (false);
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Label StepLabel;
		private System.Windows.Forms.Label IntroductionLabel;
		private System.Windows.Forms.Label AssemblyLabel;
		private System.Windows.Forms.Button AssemblyAddButton;
		private System.Windows.Forms.Button AssemblyRemoveButton;
		private System.Windows.Forms.ListView AssemblyListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.PictureBox MonoTodoResultsImage;
		private System.Windows.Forms.Label MonoTodoResultsLabel;
		private System.Windows.Forms.Label AnalysisResultsLabel;
		private System.Windows.Forms.Label NotImplementedResultsLabel;
		private System.Windows.Forms.PictureBox NotImplementedResultsImage;
		private System.Windows.Forms.Label PInvokesResultsLabel;
		private System.Windows.Forms.PictureBox PInvokesResultsImage;
		private System.Windows.Forms.Label AssemblyInstructions;
		private System.Windows.Forms.Label MissingResultsLabel;
		private System.Windows.Forms.PictureBox MissingResultsImage;
		private System.Windows.Forms.Label ResultsText;
		private System.Windows.Forms.LinkLabel ResultsDetailLink;
		private System.Windows.Forms.LinkLabel ProjectLink;
		private System.Windows.Forms.Label SubmitLabel;
		private System.Windows.Forms.Label SubmitInstructions;
		private System.Windows.Forms.Button SubmitReportButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label MonoVersionLabel;
		private System.Windows.Forms.LinkLabel CheckUpdateLink;
		private System.Windows.Forms.Button DirectoryAddButton;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label WhatsNextLabel;
		private System.Windows.Forms.Panel Step1Panel;
		private System.Windows.Forms.Panel Step4Panel;
		private System.Windows.Forms.Panel Step3Panel;
		private System.Windows.Forms.Panel Step2Panel;
		private System.Windows.Forms.Panel Step5Panel;
		private WhatsNextButton DownloadMonoDevelopButton;
		private WhatsNextButton DownloadMonoButton;
		private WhatsNextButton GettingStartedButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox OptionalHomePageBox;
		private System.Windows.Forms.TextBox OptionalOrganizationBox;
		private System.Windows.Forms.TextBox OptionalCommentsBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox OptionalEmailBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox OptionalNameBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox DescriptionComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label ScanningLabel;
		private System.Windows.Forms.PictureBox ScanningSpinner;
		internal System.Windows.Forms.ComboBox MonoVersionCombo;
	}
}