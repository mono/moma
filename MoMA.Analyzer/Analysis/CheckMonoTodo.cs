using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MoMA.Analyzer
{
	public class CheckMonoTodo : BaseChecker
	{
		public CheckMonoTodo (Stream input)
		{
			data = new SortedList<string, Method> ();

			StreamReader input_reader = new StreamReader (input);
			string line;

			while ((line = input_reader.ReadLine ()) != null)
			{
				int split = line.IndexOf ("-");
				
				string method = line.Substring (0, split);
				string description = line.Substring (split + 1);
				
				data[method] = new Method (method, description);
			}
		}
	}
}
