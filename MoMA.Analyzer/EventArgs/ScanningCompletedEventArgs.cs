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
	public class ScanningCompletedEventArgs : EventArgs
	{
		private int assemblies_scanned;
		private int miss_total;
		private int niex_total;
		private int pinv_total;
		private int todo_total;

		public ScanningCompletedEventArgs (int assem, int todo, int niex, int miss, int pinv)
		{
			assemblies_scanned = assem;
			miss_total = miss;
			niex_total = niex;
			pinv_total = pinv;
			todo_total = todo;
		}

		#region Properties
		public int AssembliesScanned {
			get { return assemblies_scanned; }
		}

		public int MissingMethodTotal {
			get { return miss_total; }
		}

		public int NotImplementedExceptionTotal {
			get { return niex_total; }
		}

		public int PInvokeTotal {
			get { return pinv_total; }
		}

		public int MonoTodoTotal {
			get { return todo_total; }
		}
		#endregion
	}
}
