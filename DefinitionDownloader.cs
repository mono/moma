using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MoMA.Analyzer;
using System.IO;

namespace MoMA
{
	public partial class DefinitionDownloader : Form
	{
		private FileDefinition fd;
		private string image_directory;

		public DefinitionDownloader ()
		{
			InitializeComponent ();

			image_directory = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Resources");
			LoadImages ();
		}

		public void LoadDefinitionFile (FileDefinition fd)
		{
			this.fd = fd;
			this.VersionLabel.Text = fd.Version;
			this.DateLabel.Text = fd.Date.ToShortDateString ();
		}
		
		private void CloseButton_Click (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void DownloadButton_Click (object sender, EventArgs e)
		{
			DownloadButton.Enabled = false;
			DownloadLabel.Visible = true;
			DownloadSpinner.Visible = true;

			Application.DoEvents ();
			
			try {
				string definition_directory;
				
				// Unix-y people generally can't write to where the executable is, so move it to their home
				if (Environment.OSVersion.Platform == PlatformID.Unix)
					definition_directory = Path.Combine (Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData), "moma"), "Definitions");
				else
					definition_directory = Path.Combine (Path.GetDirectoryName (Application.ExecutablePath), "Definitions");

				if (!Directory.Exists (definition_directory))
					Directory.CreateDirectory (definition_directory);
					
				string definition_file = Path.Combine (definition_directory, Path.GetFileName (fd.FileName));
				
				System.Net.WebClient wc = new System.Net.WebClient ();
				
				// I couldn't get DownloadFileAsync to work on Mono, so my spinner won't spin on Mono.
				// But I envision my users mainly being .Net, so I want to make sure that it spins for them.
				// Hence this nasty hack.
				if (RunningOnMono ()) {
					wc.DownloadFile (new Uri(fd.FileName), definition_file);
					this.DialogResult = DialogResult.OK;
				
				} else {
					wc.DownloadFileCompleted += new AsyncCompletedEventHandler (wc_DownloadFileCompleted);
					wc.DownloadFileAsync (new Uri (fd.FileName), definition_file);
				}
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("Download failed.  Reason:\n{0}", ex.ToString ()));
				this.DialogResult = DialogResult.Cancel;
			}
		}

		void wc_DownloadFileCompleted (object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error != null)
				MessageBox.Show (string.Format ("Download failed.  Reason:\n{0}", e.Error.ToString ()));
				
			this.DialogResult = DialogResult.OK;
		}
		
		private bool RunningOnMono ()
		{
			Type t = typeof (int);
			
			if (t.GetType ().ToString () == "System.MonoType")
				return true;
				
			return false;
		}

		private void LoadImages ()
		{
			try {
				this.BackgroundImage = Image.FromFile (Path.Combine (image_directory, "monoback.png"));
				DownloadSpinner.Image = Image.FromFile (Path.Combine (image_directory, "spinner.gif"));
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("There was an error loading resources for MoMA, please try downloading a new copy.\nError: {0}", ex.ToString ()));
			}
		}
	}
}