using System;
using System.Collections.Generic;
using System.Text;

namespace MoMA.Analyzer
{
	public class FileDefinition : IComparable<FileDefinition>
	{
		private string version;
		private DateTime date;
		private string filename;

		public FileDefinition (string version, string date, string filename)
		{
			this.version = version;
			this.date = DateTime.ParseExact (date, "MM/dd/yy", new System.Globalization.CultureInfo("en-US").DateTimeFormat);
			this.filename = filename;
		}
		
		public FileDefinition ()
		{
		}

		public string Version
		{
			get { return version; }
			set { version = value; }
		}

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		public string FileName
		{
			get { return filename; }
			set { filename = value; }
		}

		public override string ToString ()
		{
			return this.version;
		}

		#region IComparable<DefinitionFile> Members
		// We want to sort reverse-chronologically, most recent file first
		int IComparable<FileDefinition>.CompareTo (FileDefinition other)
		{
			return date.CompareTo (other.date) * -1;
		}
		#endregion
	}
}
