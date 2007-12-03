using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using MoMA.Analyzer;
using System.Windows.Forms;

namespace MoMAExtractor
{
	class Program
	{
		static void Main (string[] args)
		{
			// I'm just interested in getting the files needed for MoMA
			// right now, this may only work on my machine  :)

			string mono_path = @"C:\Program Files (x86)\Mono-1.2.5\lib\mono\2.0";
			string output_path = Path.GetDirectoryName (Application.ExecutablePath);
			
			List<string> mono_assemblies = GetMonoAssemblies (mono_path);
			List<string> ms_assemblies = GetMicrosoftAssemblies ();

			SortedList<string, Method> ms_all = new SortedList<string, Method> ();
			SortedList<string, Method> missing = new SortedList<string, Method> ();

			foreach (string assembly in ms_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, ms_all, null, null);
				
			SortedList<string, Method> all = new SortedList<string, Method> ();
			SortedList<string, Method> todo = new SortedList<string, Method> ();
			SortedList<string, Method> nie = new SortedList<string, Method> ();

			foreach (string assembly in mono_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, all, nie, todo);

			// Only use the TODO's that are also in MS's assemblies
			SortedList<string, Method> final_todo = new SortedList<string, Method> ();

			foreach (string s in todo.Keys)
				if (ms_all.ContainsKey (s))
					final_todo[s] = todo[s];

			WriteListToFile (final_todo, Path.Combine (output_path, "monotodo.txt"), true);
			
			// Only use the NIEX's that are also in MS's assemblies
			SortedList<string, Method> final_nie = new SortedList<string, Method> ();

			foreach (string s in nie.Keys)
				if (ms_all.ContainsKey (s))
					final_nie[s] = nie[s];

			WriteListToFile (final_nie, Path.Combine (output_path, "exception.txt"), false);
			
			todo.Clear ();
			nie.Clear ();

			MethodExtractor.ComputeMethodDifference (ms_all, all, missing);

			WriteListToFile (missing, Path.Combine (output_path, "missing.txt"), false);
	
			Console.WriteLine ("done");
			Console.ReadLine ();
		}

		private static List<string> GetMonoAssemblies (string directory)
		{
			// Find all of Mono's assemblies
			List<string> assemblies = new List<string> ();

			foreach (string f in Directory.GetFiles (directory, "*.dll"))
				if (f.Contains ("Accessibility") || f.Contains ("System") || f.Contains ("mscorlib") || f.Contains ("Microsoft"))
					assemblies.Add (f);

			return assemblies;
		}

		private static List<string> GetMicrosoftAssemblies ()
		{
			string ms_path_20 = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";
			string ms_path_30 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0";
			string ms_path_35 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5";

			// Find all of Microsoft's assemblies
			List<string> assemblies = new List<string> ();

			// 2.0 Assemblies
			assemblies.Add (Path.Combine (ms_path_20, "Accessibility.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.Build.Engine.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.Build.Framework.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.Build.Tasks.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.Build.Utilities.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.JScript.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.VisualBasic.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.VisualC.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "Microsoft.Vsa.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "mscorlib.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Configuration.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Configuration.Install.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Data.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Data.OracleClient.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Design.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.DirectoryServices.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Drawing.Design.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Drawing.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.EnterpriseServices.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Management.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Messaging.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Runtime.Remoting.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Runtime.Serialization.Formatters.Soap.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Security.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.ServiceProcess.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Transactions.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Web.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Web.Services.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Windows.Forms.dll"));
			assemblies.Add (Path.Combine (ms_path_20, "System.Xml.dll"));

			// 3.0 Assemblies
			assemblies.Add (Path.Combine (ms_path_30, "PresentationBuildTasks.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationCore.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationFramework.Aero.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationFramework.Classic.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationFramework.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationFramework.Luna.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "PresentationFramework.Royale.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "ReachFramework.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.IdentityModel.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.IdentityModel.Selectors.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.IO.Log.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Printing.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Runtime.Serialization.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.ServiceModel.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Speech.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Workflow.Activities.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Workflow.ComponentModel.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "System.Workflow.Runtime.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "UIAutomationClient.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "UIAutomationClientsideProviders.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "UIAutomationProvider.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "UIAutomationTypes.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "WindowsBase.dll"));
			assemblies.Add (Path.Combine (ms_path_30, "WindowsFormsIntegration.dll"));

			// 3.5 Assemblies
			assemblies.Add (Path.Combine (ms_path_35, "Microsoft.Build.Conversion.v3.5.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "Microsoft.Build.Engine.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "Microsoft.Build.Framework.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "Microsoft.Build.Utilities.v3.5.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "Microsoft.VisualC.STLCLR.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.AddIn.Contract.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.AddIn.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Core.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Data.DataSetExtensions.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Data.Linq.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.DirectoryServices.AccountManagement.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Management.Instrumentation.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Net.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.ServiceModel.Web.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Web.Extensions.Design.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Web.Extensions.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.Windows.Presentation.dll"));
			assemblies.Add (Path.Combine (ms_path_35, "System.WorkflowServices.dll"));
			
			return assemblies;
		}
		
		private static void WriteListToFile (SortedList<string, Method> list, string filename, bool writeDataField)
		{
			StreamWriter sw = new StreamWriter (filename);
			
			foreach (Method m in list.Values) {
				if (writeDataField)
					sw.WriteLine ("{0}-{1}", m.RawMethod, m.Data);
				else
					sw.WriteLine (m.RawMethod);
			}
			
			sw.Close ();
		}
	}
}
