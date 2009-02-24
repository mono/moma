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

namespace MoMA.Analyzer
{
	public class MomaError
	{
		private Method caller;
		private Method callee;

		private string document;
		private int start_row;
		private int start_col;
		private int end_row;
		private int end_col;

		public MomaError (Method caller, Method callee)
		{
			this.caller = caller;
			this.callee = callee;
		}

		public MomaError (Method caller, Method callee, string document, int startRow, int endRow, int startColumn, int endColumn) : this (caller, callee)
		{
			this.document = document;
			this.start_row = startRow;
			this.start_col = startColumn;
			this.end_row = endRow;
			this.end_col = endColumn;
		}
		
		public virtual Method GetCaller ()
		{
			return caller;
		}
		
		public virtual Method GetCallee ()
		{
			return callee;
		}
	}
}
