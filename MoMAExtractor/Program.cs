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
			
			string mono_path = @"C:\Program Files\Mono-1.2\lib\mono\2.0";
			string ms_path = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";
			string output_path = Path.GetDirectoryName (Application.ExecutablePath);
			
			List<string> mono_assemblies = GetMonoAssemblies (mono_path);
			List<string> ms_assemblies = GetMicrosoftAssemblies (ms_path);

			SortedList<string, Method> all = new SortedList<string, Method> ();
			SortedList<string, Method> todo = new SortedList<string, Method> ();
			SortedList<string, Method> nie = new SortedList<string, Method> ();

			foreach (string assembly in mono_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, all, nie, todo);

			WriteListToFile (todo, Path.Combine (output_path, "monotodo.txt"), true);
			WriteListToFile (nie, Path.Combine (output_path, "exception.txt"), false);
			
			todo.Clear ();
			nie.Clear ();

			SortedList<string, Method> ms_all = new SortedList<string, Method> ();
			SortedList<string, Method> missing = new SortedList<string, Method> ();

			foreach (string assembly in ms_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, ms_all, null, null);
				
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

		private static List<string> GetMicrosoftAssemblies (string directory)
		{
			// Find all of Microsoft's assemblies
			List<string> assemblies = new List<string> ();

			foreach (string filepath in Directory.GetFiles (directory, "*.dll")) {
				string f = Path.GetFileName (filepath);

				if ((f.Contains ("Accessibility") || f.Contains ("System") || f.Contains ("mscorlib") || f.Contains ("Microsoft")) && !(f.Contains ("_")) && !(f.Contains ("Thunk")) && !(f.Contains ("Wrapper")))
					assemblies.Add (filepath);
			}
			
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
