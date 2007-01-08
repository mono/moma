using System;
using System.Collections.Generic;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;

namespace MoMA.Analyzer
{
	public class MethodExtractor
	{
		private static SortedList<string, string> privateclasses = new SortedList<string, string> ();
		
		// Parse the assemblies looking for various sticky points
		// Leave any of the SortedList parameters null that you aren't interested in
		public static void ExtractFromAssembly (string assembly, SortedList<string, Method> allMethods, SortedList<string, Method> throwsNotImplementedMethods, SortedList<string, Method> monoTodoMethods)
		{
			privateclasses.Clear ();
			AssemblyDefinition ad = AssemblyFactory.GetAssembly (assembly);

			//Gets all types of the MainModule of the assembly
			foreach (TypeDefinition type in ad.MainModule.Types) {
				if (type.Name != "<Module>") {
					// If this is a private nested class, skip it
					if (privateclasses.ContainsKey (type.Module.Name + type.ToString ()))
						continue;
						
					// We only want Public classes
					if ((type.Attributes & TypeAttributes.Public) == 0 || (((type.Attributes & TypeAttributes.NestedPrivate) == TypeAttributes.NestedPrivate))) {
						FindPrivateNestedClasses (type);
						continue;
					}

					//Check for [MonoTODO]s on a Property, but not actually on the Getter/Setter
					if (monoTodoMethods != null) {
						foreach (PropertyDefinition property in type.Properties) {
							foreach (CustomAttribute ca in property.CustomAttributes) {
								if (ca.Constructor.DeclaringType.ToString () == "System.MonoTODOAttribute") {
									if (property.GetMethod != null && ((property.GetMethod.Attributes & MethodAttributes.Family) == MethodAttributes.Family || (property.GetMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public))
										monoTodoMethods[property.GetMethod.ToString ()] = new Method (property.GetMethod.ToString (), ca.ConstructorParameters.Count > 0 ? ca.ConstructorParameters[0].ToString () : string.Empty);
									if (property.SetMethod != null && ((property.SetMethod.Attributes & MethodAttributes.Family) == MethodAttributes.Family || (property.SetMethod.Attributes & MethodAttributes.Public) == MethodAttributes.Public))
										monoTodoMethods[property.SetMethod.ToString ()] = new Method (property.SetMethod.ToString (), ca.ConstructorParameters.Count > 0 ? ca.ConstructorParameters[0].ToString () : string.Empty);
								}
							}
						}
					}
					
					//Gets all methods of the current type
					foreach (MethodDefinition method in type.Methods) {
						// We only want Public and Protected methods
						if (!((method.Attributes & MethodAttributes.Family) == MethodAttributes.Family || (method.Attributes & MethodAttributes.Public) == MethodAttributes.Public))
							continue;
							
						// If adding all methods, add this method
						if (allMethods != null)
							allMethods[method.ToString ()] = new Method (method.ToString ());

						// If adding MonoTODO methods, check this method
						if (monoTodoMethods != null)
							foreach (CustomAttribute ca in method.CustomAttributes)
								if (ca.Constructor.DeclaringType.ToString () == "System.MonoTODOAttribute")
									monoTodoMethods[method.ToString ()] = new Method (method.ToString (), ca.ConstructorParameters.Count > 0 ? ca.ConstructorParameters[0].ToString () : string.Empty);

						// If adding methods that throw NotImplementedException, look for those
						if (throwsNotImplementedMethods != null && method.Body != null)
							foreach (Instruction i in method.Body.Instructions)
								if (i.OpCode == OpCodes.Throw)
									if (i.Previous.Operand != null && i.Previous.Operand.ToString ().StartsWith ("System.Void System.NotImplementedException"))
										throwsNotImplementedMethods[method.ToString ()] = new Method (method.ToString ());
					}

					//Gets all constructors of the current type
					foreach (MethodDefinition method in type.Constructors) {
						// We only want Public and Protected methods
						if ((method.Attributes & MethodAttributes.Family) == 0 && (method.Attributes & MethodAttributes.Public) == 0)
							continue;

						// If adding all methods, add this method
						if (allMethods != null)
							allMethods[method.ToString ()] = new Method (method.ToString ());

						// If adding MonoTODO methods, check this method
						if (monoTodoMethods != null)
							foreach (CustomAttribute ca in method.CustomAttributes)
								if (ca.Constructor.DeclaringType.ToString () == "System.MonoTODOAttribute")
									monoTodoMethods[method.ToString ()] = new Method (method.ToString (), ca.ConstructorParameters.Count > 0 ? ca.ConstructorParameters[0].ToString () : string.Empty);

						// If adding methods that throw NotImplementedException, look for those
						if (throwsNotImplementedMethods != null && method.Body != null)
							foreach (Instruction i in method.Body.Instructions)
								if (i.OpCode == OpCodes.Throw)
									if (i.Previous.Operand != null && i.Previous.Operand.ToString ().StartsWith ("System.Void System.NotImplementedException"))
										throwsNotImplementedMethods[method.ToString ()] = new Method (method.ToString ());
					}

				}
			}
		}

		public static void ComputeMethodDifference (SortedList<string, Method> master, SortedList<string, Method> subset, SortedList<string, Method> output)
		{
			// If it's in the master but not the subset, add it to the output
			foreach (string s in master.Keys)
				if (!(subset.ContainsKey (s)))
					output[s] = new Method (s);
		}
		
		private static void FindPrivateNestedClasses (TypeDefinition type)
		{
			foreach (TypeDefinition t in type.NestedTypes) 
			{
				privateclasses.Add (t.Module.Name + t.ToString (), string.Empty);
				FindPrivateNestedClasses (t);
			}
		}
	}
}
