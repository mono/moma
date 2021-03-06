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
using System.Windows.Forms;

namespace MoMA
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static int Main (string[] args)
		{
			Application.EnableVisualStyles ();
			Application.SetCompatibleTextRenderingDefault (false);
			MainForm form = new MainForm ();

			bool nogui = false;

			for (int i = 0; i < args.Length; i++) {
				string arg = args[i];
				string nextArg = (i + 1 < args.Length) ? args[i + 1] : null;

				switch (arg.ToLower ()) {
					case "--nogui":
					case "-nogui":
						nogui = true;
						break;
					case "--out":
					case "-out":
						// if !full path, use report dir
						form.ReportFileName = nextArg;
						i++;
						break;
					default:
						if (arg.StartsWith ("-")) {
							Console.WriteLine ("Unknown argument: {0}", arg);
							return 1;
						}
						
						form.AddAssembly (arg);
						break;
				}
			}

			if (!nogui)
				Application.Run (form);
			else
				form.AnalyzeNoGui ();

			return 0;
		}
	}
}
