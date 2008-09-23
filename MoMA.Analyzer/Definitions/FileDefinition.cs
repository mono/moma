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

			// Yes, this will fail in the year 2100, find one of my grandchildren to complain to...
			this.date = new DateTime (int.Parse (date.Substring (6, 2)) + 2000, int.Parse (date.Substring (0, 2)), int.Parse (date.Substring (3, 2)));

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
