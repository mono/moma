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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (MainForm));
			this.pictureBox1 = new System.Windows.Forms.PictureBox ();
			this.NextButton = new System.Windows.Forms.Button ();
			this.BackButton = new System.Windows.Forms.Button ();
			this.label1 = new System.Windows.Forms.Label ();
			this.StepLabel = new System.Windows.Forms.Label ();
			this.IntroductionLabel = new System.Windows.Forms.Label ();
			this.AssemblyLabel = new System.Windows.Forms.Label ();
			this.AssemblyAddButton = new System.Windows.Forms.Button ();
			this.AssemblyRemoveButton = new System.Windows.Forms.Button ();
			this.AssemblyListView = new System.Windows.Forms.ListView ();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader ();
			this.MonoTodoResultsImage = new System.Windows.Forms.PictureBox ();
			this.MonoTodoResultsLabel = new System.Windows.Forms.Label ();
			this.AnalysisResultsLabel = new System.Windows.Forms.Label ();
			this.NotImplementedResultsLabel = new System.Windows.Forms.Label ();
			this.NotImplementedResultsImage = new System.Windows.Forms.PictureBox ();
			this.PInvokesResultsLabel = new System.Windows.Forms.Label ();
			this.PInvokesResultsImage = new System.Windows.Forms.PictureBox ();
			this.AssemblyInstructions = new System.Windows.Forms.Label ();
			this.MissingResultsLabel = new System.Windows.Forms.Label ();
			this.MissingResultsImage = new System.Windows.Forms.PictureBox ();
			this.ResultsText = new System.Windows.Forms.Label ();
			this.ResultsDetailLink = new System.Windows.Forms.LinkLabel ();
			this.ProjectLink = new System.Windows.Forms.LinkLabel ();
			this.SubmitLabel = new System.Windows.Forms.Label ();
			this.SubmitInstructions = new System.Windows.Forms.Label ();
			this.ViewReportButton = new System.Windows.Forms.Button ();
			this.SubmitReportButton = new System.Windows.Forms.Button ();
			this.label2 = new System.Windows.Forms.Label ();
			this.MonoVersionCombo = new System.Windows.Forms.ComboBox ();
			this.MonoVersionLabel = new System.Windows.Forms.Label ();
			this.CheckUpdateLink = new System.Windows.Forms.LinkLabel ();
			this.OptionalGroupBox = new System.Windows.Forms.GroupBox ();
			this.OptionalHomePageBox = new System.Windows.Forms.TextBox ();
			this.OptionalOrganizationBox = new System.Windows.Forms.TextBox ();
			this.OptionalCommentsBox = new System.Windows.Forms.TextBox ();
			this.label7 = new System.Windows.Forms.Label ();
			this.OptionalEmailBox = new System.Windows.Forms.TextBox ();
			this.label3 = new System.Windows.Forms.Label ();
			this.OptionalNameBox = new System.Windows.Forms.TextBox ();
			this.label4 = new System.Windows.Forms.Label ();
			this.label6 = new System.Windows.Forms.Label ();
			this.label5 = new System.Windows.Forms.Label ();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.MonoTodoResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.NotImplementedResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.PInvokesResultsImage)).BeginInit ();
			((System.ComponentModel.ISupportInitialize)(this.MissingResultsImage)).BeginInit ();
			this.OptionalGroupBox.SuspendLayout ();
			this.SuspendLayout ();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
			this.pictureBox1.Location = new System.Drawing.Point (12, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size (100, 119);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font ("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point (135, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (340, 32);
			this.label1.TabIndex = 3;
			this.label1.Text = "Mono Migration Analyzer";
			// 
			// StepLabel
			// 
			this.StepLabel.AutoSize = true;
			this.StepLabel.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StepLabel.Location = new System.Drawing.Point (284, 429);
			this.StepLabel.Name = "StepLabel";
			this.StepLabel.Size = new System.Drawing.Size (60, 14);
			this.StepLabel.TabIndex = 4;
			this.StepLabel.Text = "Step 1 of 4";
			// 
			// IntroductionLabel
			// 
			this.IntroductionLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.IntroductionLabel.Location = new System.Drawing.Point (138, 130);
			this.IntroductionLabel.Name = "IntroductionLabel";
			this.IntroductionLabel.Size = new System.Drawing.Size (530, 202);
			this.IntroductionLabel.TabIndex = 5;
			this.IntroductionLabel.Text = resources.GetString ("IntroductionLabel.Text");
			// 
			// AssemblyLabel
			// 
			this.AssemblyLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AssemblyLabel.Location = new System.Drawing.Point (170, 100);
			this.AssemblyLabel.Name = "AssemblyLabel";
			this.AssemblyLabel.Size = new System.Drawing.Size (416, 20);
			this.AssemblyLabel.TabIndex = 6;
			this.AssemblyLabel.Text = "Choose the assemblies to analyze:";
			// 
			// AssemblyAddButton
			// 
			this.AssemblyAddButton.Location = new System.Drawing.Point (592, 123);
			this.AssemblyAddButton.Name = "AssemblyAddButton";
			this.AssemblyAddButton.Size = new System.Drawing.Size (30, 30);
			this.AssemblyAddButton.TabIndex = 8;
			this.AssemblyAddButton.UseVisualStyleBackColor = true;
			this.AssemblyAddButton.Click += new System.EventHandler (this.AssemblyAddButton_Click);
			// 
			// AssemblyRemoveButton
			// 
			this.AssemblyRemoveButton.Location = new System.Drawing.Point (592, 159);
			this.AssemblyRemoveButton.Name = "AssemblyRemoveButton";
			this.AssemblyRemoveButton.Size = new System.Drawing.Size (30, 30);
			this.AssemblyRemoveButton.TabIndex = 9;
			this.AssemblyRemoveButton.UseVisualStyleBackColor = true;
			this.AssemblyRemoveButton.Click += new System.EventHandler (this.AssemblyRemoveButton_Click);
			// 
			// AssemblyListView
			// 
			this.AssemblyListView.Columns.AddRange (new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.AssemblyListView.FullRowSelect = true;
			this.AssemblyListView.Location = new System.Drawing.Point (173, 123);
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
			// MonoTodoResultsImage
			// 
			this.MonoTodoResultsImage.Location = new System.Drawing.Point (193, 214);
			this.MonoTodoResultsImage.Name = "MonoTodoResultsImage";
			this.MonoTodoResultsImage.Size = new System.Drawing.Size (22, 22);
			this.MonoTodoResultsImage.TabIndex = 11;
			this.MonoTodoResultsImage.TabStop = false;
			// 
			// MonoTodoResultsLabel
			// 
			this.MonoTodoResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MonoTodoResultsLabel.Location = new System.Drawing.Point (220, 216);
			this.MonoTodoResultsLabel.Name = "MonoTodoResultsLabel";
			this.MonoTodoResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.MonoTodoResultsLabel.TabIndex = 12;
			this.MonoTodoResultsLabel.Text = "Methods marked with [MonoTodo] called: 0";
			// 
			// AnalysisResultsLabel
			// 
			this.AnalysisResultsLabel.Font = new System.Drawing.Font ("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AnalysisResultsLabel.Location = new System.Drawing.Point (169, 100);
			this.AnalysisResultsLabel.Name = "AnalysisResultsLabel";
			this.AnalysisResultsLabel.Size = new System.Drawing.Size (416, 20);
			this.AnalysisResultsLabel.TabIndex = 14;
			this.AnalysisResultsLabel.Text = "Analysis Summary:";
			// 
			// NotImplementedResultsLabel
			// 
			this.NotImplementedResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NotImplementedResultsLabel.Location = new System.Drawing.Point (220, 188);
			this.NotImplementedResultsLabel.Name = "NotImplementedResultsLabel";
			this.NotImplementedResultsLabel.Size = new System.Drawing.Size (395, 20);
			this.NotImplementedResultsLabel.TabIndex = 16;
			this.NotImplementedResultsLabel.Text = "Methods called that throw NotImplementedException: 0";
			// 
			// NotImplementedResultsImage
			// 
			this.NotImplementedResultsImage.Location = new System.Drawing.Point (193, 186);
			this.NotImplementedResultsImage.Name = "NotImplementedResultsImage";
			this.NotImplementedResultsImage.Size = new System.Drawing.Size (22, 22);
			this.NotImplementedResultsImage.TabIndex = 15;
			this.NotImplementedResultsImage.TabStop = false;
			// 
			// PInvokesResultsLabel
			// 
			this.PInvokesResultsLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PInvokesResultsLabel.Location = new System.Drawing.Point (220, 160);
			this.PInvokesResultsLabel.Name = "PInvokesResultsLabel";
			this.PInvokesResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.PInvokesResultsLabel.TabIndex = 19;
			this.PInvokesResultsLabel.Text = "P/Invokes called: 0";
			// 
			// PInvokesResultsImage
			// 
			this.PInvokesResultsImage.Location = new System.Drawing.Point (193, 158);
			this.PInvokesResultsImage.Name = "PInvokesResultsImage";
			this.PInvokesResultsImage.Size = new System.Drawing.Size (22, 22);
			this.PInvokesResultsImage.TabIndex = 18;
			this.PInvokesResultsImage.TabStop = false;
			// 
			// AssemblyInstructions
			// 
			this.AssemblyInstructions.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AssemblyInstructions.Location = new System.Drawing.Point (173, 278);
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
			this.MissingResultsLabel.Location = new System.Drawing.Point (220, 132);
			this.MissingResultsLabel.Name = "MissingResultsLabel";
			this.MissingResultsLabel.Size = new System.Drawing.Size (310, 20);
			this.MissingResultsLabel.TabIndex = 23;
			this.MissingResultsLabel.Text = "Methods that still missing in Mono: 0";
			// 
			// MissingResultsImage
			// 
			this.MissingResultsImage.Location = new System.Drawing.Point (193, 130);
			this.MissingResultsImage.Name = "MissingResultsImage";
			this.MissingResultsImage.Size = new System.Drawing.Size (22, 22);
			this.MissingResultsImage.TabIndex = 22;
			this.MissingResultsImage.TabStop = false;
			// 
			// ResultsText
			// 
			this.ResultsText.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ResultsText.Location = new System.Drawing.Point (170, 278);
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
			this.ResultsDetailLink.Location = new System.Drawing.Point (471, 332);
			this.ResultsDetailLink.Name = "ResultsDetailLink";
			this.ResultsDetailLink.Size = new System.Drawing.Size (115, 16);
			this.ResultsDetailLink.TabIndex = 25;
			this.ResultsDetailLink.TabStop = true;
			this.ResultsDetailLink.Text = "View Detail Report";
			this.ResultsDetailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.ResultsDetailLink_LinkClicked);
			// 
			// ProjectLink
			// 
			this.ProjectLink.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ProjectLink.Location = new System.Drawing.Point (243, 445);
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
			this.SubmitLabel.Location = new System.Drawing.Point (159, 83);
			this.SubmitLabel.Name = "SubmitLabel";
			this.SubmitLabel.Size = new System.Drawing.Size (416, 20);
			this.SubmitLabel.TabIndex = 27;
			this.SubmitLabel.Text = "Submit Results:";
			// 
			// SubmitInstructions
			// 
			this.SubmitInstructions.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SubmitInstructions.Location = new System.Drawing.Point (159, 108);
			this.SubmitInstructions.Name = "SubmitInstructions";
			this.SubmitInstructions.Size = new System.Drawing.Size (483, 103);
			this.SubmitInstructions.TabIndex = 28;
			this.SubmitInstructions.Text = resources.GetString ("SubmitInstructions.Text");
			// 
			// ViewReportButton
			// 
			this.ViewReportButton.Location = new System.Drawing.Point (463, 382);
			this.ViewReportButton.Name = "ViewReportButton";
			this.ViewReportButton.Size = new System.Drawing.Size (86, 30);
			this.ViewReportButton.TabIndex = 6;
			this.ViewReportButton.Text = "View Report";
			this.ViewReportButton.UseVisualStyleBackColor = true;
			this.ViewReportButton.Click += new System.EventHandler (this.ViewReportButton_Click);
			// 
			// SubmitReportButton
			// 
			this.SubmitReportButton.Enabled = false;
			this.SubmitReportButton.Location = new System.Drawing.Point (555, 382);
			this.SubmitReportButton.Name = "SubmitReportButton";
			this.SubmitReportButton.Size = new System.Drawing.Size (86, 30);
			this.SubmitReportButton.TabIndex = 7;
			this.SubmitReportButton.Text = "Submit Report";
			this.SubmitReportButton.UseVisualStyleBackColor = true;
			this.SubmitReportButton.Click += new System.EventHandler (this.SubmitReportButton_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point (9, 445);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (72, 14);
			this.label2.TabIndex = 32;
			this.label2.Text = "Version 1.2.4";
			// 
			// MonoVersionCombo
			// 
			this.MonoVersionCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MonoVersionCombo.FormattingEnabled = true;
			this.MonoVersionCombo.Location = new System.Drawing.Point (386, 339);
			this.MonoVersionCombo.Name = "MonoVersionCombo";
			this.MonoVersionCombo.Size = new System.Drawing.Size (140, 21);
			this.MonoVersionCombo.TabIndex = 34;
			// 
			// MonoVersionLabel
			// 
			this.MonoVersionLabel.AutoSize = true;
			this.MonoVersionLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MonoVersionLabel.Location = new System.Drawing.Point (211, 340);
			this.MonoVersionLabel.Name = "MonoVersionLabel";
			this.MonoVersionLabel.Size = new System.Drawing.Size (169, 16);
			this.MonoVersionLabel.TabIndex = 35;
			this.MonoVersionLabel.Text = "Test Against Mono Version:";
			// 
			// CheckUpdateLink
			// 
			this.CheckUpdateLink.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.CheckUpdateLink.Location = new System.Drawing.Point (389, 366);
			this.CheckUpdateLink.Name = "CheckUpdateLink";
			this.CheckUpdateLink.Size = new System.Drawing.Size (137, 14);
			this.CheckUpdateLink.TabIndex = 36;
			this.CheckUpdateLink.TabStop = true;
			this.CheckUpdateLink.Text = "Check for newer version";
			this.CheckUpdateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler (this.CheckUpdateLink_LinkClicked);
			// 
			// OptionalGroupBox
			// 
			this.OptionalGroupBox.Controls.Add (this.OptionalHomePageBox);
			this.OptionalGroupBox.Controls.Add (this.OptionalOrganizationBox);
			this.OptionalGroupBox.Controls.Add (this.OptionalCommentsBox);
			this.OptionalGroupBox.Controls.Add (this.label7);
			this.OptionalGroupBox.Controls.Add (this.OptionalEmailBox);
			this.OptionalGroupBox.Controls.Add (this.label3);
			this.OptionalGroupBox.Controls.Add (this.OptionalNameBox);
			this.OptionalGroupBox.Controls.Add (this.label4);
			this.OptionalGroupBox.Controls.Add (this.label6);
			this.OptionalGroupBox.Controls.Add (this.label5);
			this.OptionalGroupBox.Location = new System.Drawing.Point (161, 211);
			this.OptionalGroupBox.Name = "OptionalGroupBox";
			this.OptionalGroupBox.Size = new System.Drawing.Size (479, 165);
			this.OptionalGroupBox.TabIndex = 37;
			this.OptionalGroupBox.TabStop = false;
			this.OptionalGroupBox.Text = "Optional additional information to submit:";
			// 
			// OptionalHomePageBox
			// 
			this.OptionalHomePageBox.Location = new System.Drawing.Point (6, 139);
			this.OptionalHomePageBox.Name = "OptionalHomePageBox";
			this.OptionalHomePageBox.Size = new System.Drawing.Size (182, 20);
			this.OptionalHomePageBox.TabIndex = 4;
			// 
			// OptionalOrganizationBox
			// 
			this.OptionalOrganizationBox.Location = new System.Drawing.Point (6, 103);
			this.OptionalOrganizationBox.Name = "OptionalOrganizationBox";
			this.OptionalOrganizationBox.Size = new System.Drawing.Size (182, 20);
			this.OptionalOrganizationBox.TabIndex = 3;
			// 
			// OptionalCommentsBox
			// 
			this.OptionalCommentsBox.Location = new System.Drawing.Point (208, 29);
			this.OptionalCommentsBox.Multiline = true;
			this.OptionalCommentsBox.Name = "OptionalCommentsBox";
			this.OptionalCommentsBox.Size = new System.Drawing.Size (265, 130);
			this.OptionalCommentsBox.TabIndex = 5;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point (207, 16);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size (148, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Comments for the Mono team:";
			// 
			// OptionalEmailBox
			// 
			this.OptionalEmailBox.Location = new System.Drawing.Point (6, 65);
			this.OptionalEmailBox.Name = "OptionalEmailBox";
			this.OptionalEmailBox.Size = new System.Drawing.Size (182, 20);
			this.OptionalEmailBox.TabIndex = 2;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point (6, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (41, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Name: ";
			// 
			// OptionalNameBox
			// 
			this.OptionalNameBox.Location = new System.Drawing.Point (6, 29);
			this.OptionalNameBox.Name = "OptionalNameBox";
			this.OptionalNameBox.Size = new System.Drawing.Size (182, 20);
			this.OptionalNameBox.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point (7, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size (35, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Email:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point (6, 126);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size (102, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "Project Home Page:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point (7, 89);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size (69, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "Organization:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size (719, 471);
			this.Controls.Add (this.OptionalGroupBox);
			this.Controls.Add (this.CheckUpdateLink);
			this.Controls.Add (this.MonoVersionLabel);
			this.Controls.Add (this.MonoVersionCombo);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.SubmitReportButton);
			this.Controls.Add (this.ViewReportButton);
			this.Controls.Add (this.SubmitInstructions);
			this.Controls.Add (this.SubmitLabel);
			this.Controls.Add (this.ProjectLink);
			this.Controls.Add (this.ResultsDetailLink);
			this.Controls.Add (this.ResultsText);
			this.Controls.Add (this.MissingResultsLabel);
			this.Controls.Add (this.MissingResultsImage);
			this.Controls.Add (this.label1);
			this.Controls.Add (this.PInvokesResultsLabel);
			this.Controls.Add (this.PInvokesResultsImage);
			this.Controls.Add (this.NotImplementedResultsLabel);
			this.Controls.Add (this.NotImplementedResultsImage);
			this.Controls.Add (this.AnalysisResultsLabel);
			this.Controls.Add (this.MonoTodoResultsLabel);
			this.Controls.Add (this.MonoTodoResultsImage);
			this.Controls.Add (this.AssemblyListView);
			this.Controls.Add (this.AssemblyRemoveButton);
			this.Controls.Add (this.AssemblyAddButton);
			this.Controls.Add (this.AssemblyLabel);
			this.Controls.Add (this.IntroductionLabel);
			this.Controls.Add (this.StepLabel);
			this.Controls.Add (this.BackButton);
			this.Controls.Add (this.NextButton);
			this.Controls.Add (this.pictureBox1);
			this.Controls.Add (this.AssemblyInstructions);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "MoMA: Mono Migration Analyzer";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.MonoTodoResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.NotImplementedResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.PInvokesResultsImage)).EndInit ();
			((System.ComponentModel.ISupportInitialize)(this.MissingResultsImage)).EndInit ();
			this.OptionalGroupBox.ResumeLayout (false);
			this.OptionalGroupBox.PerformLayout ();
			this.ResumeLayout (false);
			this.PerformLayout ();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button NextButton;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Label label1;
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
		private System.Windows.Forms.Button ViewReportButton;
		private System.Windows.Forms.Button SubmitReportButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox MonoVersionCombo;
		private System.Windows.Forms.Label MonoVersionLabel;
		private System.Windows.Forms.LinkLabel CheckUpdateLink;
		private System.Windows.Forms.GroupBox OptionalGroupBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox OptionalNameBox;
		private System.Windows.Forms.TextBox OptionalEmailBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox OptionalOrganizationBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox OptionalHomePageBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox OptionalCommentsBox;
	}
}