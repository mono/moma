using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MoMA
{
    public partial class OptionalInformation : Form
    {
        string file;

        public OptionalInformation(string file)
        {
            InitializeComponent();
            this.file = file;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader (file)){
			    string results = sr.ReadToEnd ();
			
			    MoMAWebServices.MoMASubmit ws = new MoMA.MoMAWebServices.MoMASubmit ();
			
                try {                    
                    string extra = String.Format (
                        "@Name: {0}\n" +
                        "@Email: {1}\n" +
                        "@Organization: {2}\n" +
                        "@HomePage: {3}\n" +
                        "@Comments: {4}\n{5}", 
                        name.Text, email.Text, organization.Text, homepage.Text, 
                        comments.Text.Replace ('\n', ' ').Replace ('\r', ' '),
                        results);

			        if (ws.SubmitResults (extra))	
				        MessageBox.Show ("Results successfully submitted.  Thanks!");
			        else
				        MessageBox.Show ("Result submission failed.  Please try again later.");
                } catch (Exception ex) {
                    MessageBox.Show ("Result submission failed (Exception={0}).", ex.GetType().ToString());
                }
            }
            Close ();
        }


    }
}