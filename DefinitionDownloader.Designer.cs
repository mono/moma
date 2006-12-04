namespace MoMA
{
	partial class DefinitionDownloader
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (DefinitionDownloader));
			this.label1 = new System.Windows.Forms.Label ();
			this.label2 = new System.Windows.Forms.Label ();
			this.label3 = new System.Windows.Forms.Label ();
			this.VersionLabel = new System.Windows.Forms.Label ();
			this.DateLabel = new System.Windows.Forms.Label ();
			this.DownloadButton = new System.Windows.Forms.Button ();
			this.CloseButton = new System.Windows.Forms.Button ();
			this.DownloadSpinner = new System.Windows.Forms.PictureBox ();
			this.DownloadLabel = new System.Windows.Forms.Label ();
			((System.ComponentModel.ISupportInitialize)(this.DownloadSpinner)).BeginInit ();
			this.SuspendLayout ();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point (13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size (418, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "New MoMA definitions are available:";
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point (90, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size (75, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Version:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point (90, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size (75, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "Date:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// VersionLabel
			// 
			this.VersionLabel.BackColor = System.Drawing.Color.Transparent;
			this.VersionLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.VersionLabel.Location = new System.Drawing.Point (171, 56);
			this.VersionLabel.Name = "VersionLabel";
			this.VersionLabel.Size = new System.Drawing.Size (164, 17);
			this.VersionLabel.TabIndex = 3;
			this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DateLabel
			// 
			this.DateLabel.BackColor = System.Drawing.Color.Transparent;
			this.DateLabel.Font = new System.Drawing.Font ("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DateLabel.Location = new System.Drawing.Point (171, 78);
			this.DateLabel.Name = "DateLabel";
			this.DateLabel.Size = new System.Drawing.Size (164, 17);
			this.DateLabel.TabIndex = 4;
			this.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DownloadButton
			// 
			this.DownloadButton.Location = new System.Drawing.Point (213, 126);
			this.DownloadButton.Name = "DownloadButton";
			this.DownloadButton.Size = new System.Drawing.Size (86, 30);
			this.DownloadButton.TabIndex = 8;
			this.DownloadButton.Text = "Download";
			this.DownloadButton.UseVisualStyleBackColor = true;
			this.DownloadButton.Click += new System.EventHandler (this.DownloadButton_Click);
			// 
			// CloseButton
			// 
			this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CloseButton.Location = new System.Drawing.Point (305, 126);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size (86, 30);
			this.CloseButton.TabIndex = 9;
			this.CloseButton.Text = "Close";
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler (this.CloseButton_Click);
			// 
			// DownloadSpinner
			// 
			this.DownloadSpinner.Image = global::MoMA.Properties.Resources.spinner;
			this.DownloadSpinner.Location = new System.Drawing.Point (19, 132);
			this.DownloadSpinner.Name = "DownloadSpinner";
			this.DownloadSpinner.Size = new System.Drawing.Size (16, 16);
			this.DownloadSpinner.TabIndex = 10;
			this.DownloadSpinner.TabStop = false;
			this.DownloadSpinner.Visible = false;
			// 
			// DownloadLabel
			// 
			this.DownloadLabel.BackColor = System.Drawing.Color.Transparent;
			this.DownloadLabel.Font = new System.Drawing.Font ("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.DownloadLabel.Location = new System.Drawing.Point (41, 133);
			this.DownloadLabel.Name = "DownloadLabel";
			this.DownloadLabel.Size = new System.Drawing.Size (147, 17);
			this.DownloadLabel.TabIndex = 11;
			this.DownloadLabel.Text = "Downloading...";
			this.DownloadLabel.Visible = false;
			// 
			// DefinitionDownloader
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.BackgroundImage = global::MoMA.Properties.Resources.monoback;
			this.CancelButton = this.CloseButton;
			this.ClientSize = new System.Drawing.Size (403, 167);
			this.Controls.Add (this.DownloadLabel);
			this.Controls.Add (this.DownloadSpinner);
			this.Controls.Add (this.CloseButton);
			this.Controls.Add (this.DownloadButton);
			this.Controls.Add (this.DateLabel);
			this.Controls.Add (this.VersionLabel);
			this.Controls.Add (this.label3);
			this.Controls.Add (this.label2);
			this.Controls.Add (this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject ("$this.Icon")));
			this.Name = "DefinitionDownloader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Download New Definitions?";
			((System.ComponentModel.ISupportInitialize)(this.DownloadSpinner)).EndInit ();
			this.ResumeLayout (false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label VersionLabel;
		private System.Windows.Forms.Label DateLabel;
		private System.Windows.Forms.Button DownloadButton;
		private System.Windows.Forms.Button CloseButton;
		private System.Windows.Forms.PictureBox DownloadSpinner;
		private System.Windows.Forms.Label DownloadLabel;

	}
}