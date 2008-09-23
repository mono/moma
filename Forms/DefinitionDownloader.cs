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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MoMA.Analyzer;

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
				this.BackgroundImage = Image.FromFile (Path.Combine (image_directory, "dialogback.png"));
				DownloadSpinner.Image = Image.FromFile (Path.Combine (image_directory, "spinner.gif"));
			}
			catch (Exception ex) {
				MessageBox.Show (string.Format ("There was an error loading resources for MoMA, please try downloading a new copy.\nError: {0}", ex.ToString ()));
			}
		}
	}
}