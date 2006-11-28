using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
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
			AssemblyDefinition ad;

			try {
				ad = AssemblyFactory.GetAssembly (assembly);
			} catch (ImageFormatException ife){
				
				return;
			}

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
