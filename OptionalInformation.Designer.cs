namespace MoMA
{
    partial class OptionalInformation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.organization = new System.Windows.Forms.TextBox();
            this.homepage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comments = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Optional Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Optional Organization:";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(159, 39);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(256, 20);
            this.name.TabIndex = 1;
            // 
            // organization
            // 
            this.organization.Location = new System.Drawing.Point(159, 91);
            this.organization.Name = "organization";
            this.organization.Size = new System.Drawing.Size(256, 20);
            this.organization.TabIndex = 4;
            // 
            // homepage
            // 
            this.homepage.Location = new System.Drawing.Point(159, 117);
            this.homepage.Name = "homepage";
            this.homepage.Size = new System.Drawing.Size(256, 20);
            this.homepage.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Optional Project Home Page:";
            // 
            // comments
            // 
            this.comments.Location = new System.Drawing.Point(28, 179);
            this.comments.Multiline = true;
            this.comments.Name = "comments";
            this.comments.Size = new System.Drawing.Size(387, 213);
            this.comments.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Comments for the Mono team:";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(159, 65);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(256, 20);
            this.email.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Optional E-Mail Address:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 423);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Send Feedback";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OptionalInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 462);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comments);
            this.Controls.Add(this.homepage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.organization);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "OptionalInformation";
            this.Text = "OptionalInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox organization;
        private System.Windows.Forms.TextBox homepage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox comments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}