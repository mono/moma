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
using System.Collections.Generic;
using System.IO;

namespace MoMA.Analyzer
{
	public class AssemblyScannedEventArgs : EventArgs
	{
		private string assembly_path;
		private string assembly_name;
		private string assembly_runtime;
		private Version assembly_version;
		private List<BaseError> mono_todo_results;
		private List<BaseError> not_implemented_results;
		private List<BaseError> missing_results;
		private List<BaseError> pinvoke_results;

		public AssemblyScannedEventArgs (string path, string runtime, Version version, List<BaseError> todo, List<BaseError> niex, List<BaseError> miss, List<BaseError> pinv)
		{
			assembly_path = path;
			assembly_name = Path.GetFileName (path);
			assembly_runtime = runtime;
			assembly_version = version;
			mono_todo_results = todo;
			not_implemented_results = niex;
			missing_results = miss;
			pinvoke_results = pinv;
		}

		#region Properties
		public string AssemblyName {
			get { return assembly_name; }
		}

		public string AssemblyRuntime {
			get { return assembly_runtime; }
		}

		public Version AssemblyVersion {
			get { return assembly_version; }
		}

		public List<BaseError> MonoTodoResults {
			get { return this.mono_todo_results; }
		}

		public List<BaseError> NotImplementedExceptionResults {
			get { return this.not_implemented_results; }
		}

		public List<BaseError> MissingMethodResults {
			get { return this.missing_results; }
		}

		public List<BaseError> PInvokeResults {
			get { return this.pinvoke_results; }
		}
		
		public int TotalIssues {
			get { return mono_todo_results.Count + not_implemented_results.Count + missing_results.Count + pinvoke_results.Count; }
		}
		#endregion
	}
}
