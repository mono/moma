using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using MoMA.Analyzer;

namespace MoMAExtractor
{
	class Program2
	{
		// Parameters to fiddle with
		private static bool use_20 = true;
		private static bool use_30 = true;
		private static bool use_35 = true;

		private static bool use_design = true;
		private static bool mwf_only = false;

		// True: Output the count of methods in each MS assembly
		// False: Output MoMA stats for each assembly
		private static bool count_only = false;
		
		static void Main0 (string[] args)
		{
			string output_path = Path.GetDirectoryName (Application.ExecutablePath);

			// Get the assemblies we want to examine
			List<string> mono_assemblies = AssemblyManager.GetAssemblies (true, use_20, use_30, use_35, false, false, use_design, mwf_only);
			List<string> ms_assemblies = AssemblyManager.GetAssemblies (false, use_20, use_30, use_35, false, false, use_design, mwf_only);

			StreamWriter sw = new StreamWriter (Path.Combine (output_path, "summary.txt"));
			
			foreach (string assembly in ms_assemblies) {
				SortedList<string, Method> ms_all = new SortedList<string, Method> ();
				SortedList<string, Method> missing = new SortedList<string, Method> ();

				// Get all methods in MS assembly
				MethodExtractor.ExtractFromAssembly (assembly, ms_all, null, null);
				string file = Path.GetFileName (assembly);

				// We only want MS method counts
				if (count_only) {
					sw.WriteLine ("{0}: {1}", file, ms_all.Count);
					continue;
				}
				
				// Find the matching Mono assembly
				string mono_file = string.Empty;
				
				foreach (string s in mono_assemblies)
					if (s.ToLower ().Contains (file.ToLower ()))
						mono_file = s;
				
				if (string.IsNullOrEmpty (mono_file)) {
					sw.WriteLine ("No Mono assembly found for " + file);
					continue;
				}
					
				// Do the MoMA extracts/compares, and output the results
				SortedList<string, Method> all = new SortedList<string, Method> ();
				SortedList<string, Method> todo = new SortedList<string, Method> ();
				SortedList<string, Method> nie = new SortedList<string, Method> ();
				
				MethodExtractor.ExtractFromAssembly (mono_file, all, nie, todo);
				
				SortedList<string, Method> final_todo = new SortedList<string, Method> ();

				foreach (string s in todo.Keys)
					if (ms_all.ContainsKey (s))
						final_todo[s] = todo[s];

				sw.WriteLine (file);
				sw.WriteLine (string.Format ("TODO: {0}", final_todo.Count));
				
				SortedList<string, Method> final_nie = new SortedList<string, Method> ();

				foreach (string s in nie.Keys)
					if (ms_all.ContainsKey (s))
						final_nie[s] = nie[s];

				sw.WriteLine (string.Format ("NIEX: {0}", final_nie.Count));
		
				MethodExtractor.ComputeMethodDifference (ms_all, all, missing, true);
				sw.WriteLine (string.Format ("MISS: {0}", missing.Count));
			}

			sw.Close ();
			sw.Dispose ();
			
			Console.WriteLine ("done");
			Console.ReadLine ();
		}
	}
}
