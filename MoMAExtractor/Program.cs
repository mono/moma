using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MoMA.Analyzer;

namespace MoMAExtractor
{
	class Program
	{
		// Parameters to fiddle with
		private static bool use_20 = false;	// Include the 2.0 framework
		private static bool use_30 = false;	// Include the 3.0 framework
		private static bool use_35 = false;	// Include the 3.5 framework
		private static bool use_40 = false;  // Include the 4.0 framework
		private static bool use_45 = true;  // Include the 4.0 framework
		private static bool use_mobile = false;
		
		private static bool use_design = false;	// Include *Design namespaces
		private static bool mwf_only = false;	// Only do System.Windows.Forms (overrides others)
		
		static void Main (string[] args)
		{
			string output_path = Path.GetDirectoryName (Application.ExecutablePath);

			// Get the assemblies we want to examine
			List<string> mono_assemblies = AssemblyManager.GetAssemblies (true, use_20, use_30, use_35, use_40, use_45, use_mobile, use_design, mwf_only);
			List<string> ms_assemblies = AssemblyManager.GetAssemblies (false, use_20, use_30, use_35, use_40, use_45, use_mobile, use_design, mwf_only);

			// Extract all methods from the MS assemblies
			SortedList<string, Method> ms_all = new SortedList<string, Method> ();

			foreach (string assembly in ms_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, ms_all, null, null);
			
			// Extract all, NIEX, and TODO methods from Mono assemblies
			SortedList<string, Method> missing = new SortedList<string, Method> ();
			SortedList<string, Method> all = new SortedList<string, Method> ();
			SortedList<string, Method> todo = new SortedList<string, Method> ();
			SortedList<string, Method> nie = new SortedList<string, Method> ();

			foreach (string assembly in mono_assemblies)
				MethodExtractor.ExtractFromAssembly (assembly, all, nie, todo);

			// Only report the TODO's that are also in MS's assemblies
			SortedList<string, Method> final_todo = new SortedList<string, Method> ();

			foreach (string s in todo.Keys)
				if (ms_all.ContainsKey (s))
					final_todo[s] = todo[s];

			WriteListToFile (final_todo, Path.Combine (output_path, "monotodo.txt"), true);
			
			// Only report the NIEX's that are also in MS's assemblies
			SortedList<string, Method> final_nie = new SortedList<string, Method> ();

			foreach (string s in nie.Keys)
				if (ms_all.ContainsKey (s))
					final_nie[s] = nie[s];

			WriteListToFile (final_nie, Path.Combine (output_path, "exception.txt"), false);
			
			// Write methods that are both TODO and NIEX
			SortedList<string, Method> todo_niex = new SortedList<string, Method> ();

			foreach (string s in nie.Keys)
				if (todo.ContainsKey (s))
					todo_niex.Add (s, todo[s]);

			WriteListToFile (todo_niex, Path.Combine (output_path, "dupe.txt"), true);
			
			// Find methods that exist in MS but not in Mono (Missing methods)
			MethodExtractor.ComputeMethodDifference (ms_all, all, missing, use_design);

			WriteListToFile (missing, Path.Combine (output_path, "missing.txt"), false);
	
			Console.WriteLine ("done");
			Console.ReadLine ();
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
