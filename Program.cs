using System;
using System.Collections.Generic;
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
				form.AnalyzeAssemblies ();

			return 0;
		}
	}
}
