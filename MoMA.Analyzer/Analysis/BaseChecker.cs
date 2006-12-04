using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MoMA.Analyzer
{
	public class BaseChecker
	{
		protected SortedList <string, Method> data;

		protected BaseChecker ()
		{
		}
		
		public BaseChecker (Stream input)
		{
			data = new SortedList<string, Method> ();
			
			StreamReader input_reader = new StreamReader (input);
			string line;

			while ((line = input_reader.ReadLine ()) != null)
				data[line] = new Method (line);
		}
		
		public BaseChecker (SortedList <string, Method> data)
		{
			this.data = data;
		}

		public virtual bool Matches (string method, out Method match)
		{
			if (data.ContainsKey (method)) {
				match = data[method];
				return true;
			}

			match = null; 
			return false;
		}

	}
}
