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

using System.Collections.Generic;
using Mono.Cecil;

namespace MoMA.Analyzer
{
	public class CheckPInvokes : BaseChecker
	{
		public CheckPInvokes ()
		{
			data = new SortedList<string, Method> ();
		}
		
		public void FindPInvokesInAssembly (string assembly)
		{
			AssemblyDefinition ad = AssemblyDefinition.ReadAssembly (assembly);

			//Gets all types of the MainModule of the assembly
			foreach (TypeDefinition type in ad.MainModule.Types) {
				if (type.Name != "<Module>") {
					//Gets all methods of the current type
					foreach (MethodDefinition method in type.Methods)
						if ((method.Attributes & MethodAttributes.PInvokeImpl) == MethodAttributes.PInvokeImpl)
							data[method.ToString ()] = new Method (method.ToString (), method.PInvokeInfo.Module.Name);
				}
			}	
		}
	}
}
