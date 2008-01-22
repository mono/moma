using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.Web.UI;

namespace MoMA.Analyzer
{
	public class AssemblyAnalyzer
	{
		private CheckMonoTodo mono_todo;
		private BaseChecker not_implemented;
		private BaseChecker missing;
		private CheckPInvokes pinvoke;

		private List<BaseError> mono_todo_results;
		private List<BaseError> not_implemented_results;
		private List<BaseError> missing_results;
		private List<BaseError> pinvoke_results;

		public List<BaseError> MonoTodoResults
		{
			get { return this.mono_todo_results; }
		}

		public List<BaseError> NotImplementedExceptionResults
		{
			get { return this.not_implemented_results; }
		}

		public List<BaseError> MissingMethodResults
		{
			get { return this.missing_results; }
		}

		public List<BaseError> PInvokeResults
		{
			get { return this.pinvoke_results; }
		}

		public AssemblyAnalyzer ()
		{
			mono_todo_results = new List<BaseError> ();
			not_implemented_results = new List<BaseError> ();
			missing_results = new List<BaseError> ();
			pinvoke_results = new List<BaseError> ();
		}

		public void LoadDefinitions (string definitionBundlePath)
		{
			Stream mt;
			Stream ni;
			Stream mi;

			DefinitionHandler.GetDefinitionStreamsFromBundle (definitionBundlePath, out mt, out ni, out mi);

			LoadDefinitions (mt, ni, mi);

			mt.Close ();
			ni.Close ();
			mi.Close ();	
		}
		
		public void LoadDefinitions (string monoTodoDefinitions, string notImplementedDefinitions, string missingDefinitions)
		{
			Stream mt = new FileStream (monoTodoDefinitions, FileMode.Open);
			Stream ni = new FileStream (notImplementedDefinitions, FileMode.Open);
			Stream mi = new FileStream (missingDefinitions, FileMode.Open);

			LoadDefinitions (mt, ni, mi);

			mt.Close ();
			ni.Close ();
			mi.Close ();
		}

		public void LoadDefinitions (Stream monoTodoDefinitions, Stream notImplementedDefinitions, Stream missingDefinitions)
		{
			if (monoTodoDefinitions != null)
				mono_todo = new CheckMonoTodo (monoTodoDefinitions);

			if (notImplementedDefinitions != null)
				not_implemented = new BaseChecker (notImplementedDefinitions);

			if (missingDefinitions != null)
				missing = new BaseChecker (missingDefinitions);
		}

		public void ScanAssemblyForPInvokes (string assembly)
		{
			if (pinvoke == null)
				pinvoke = new CheckPInvokes ();

			pinvoke.FindPInvokesInAssembly (assembly);
		}

		public void AnalyzeAssembly (string assembly)
		{
			AssemblyDefinition ad = AssemblyFactory.GetAssembly (assembly);

			foreach (TypeDefinition type in ad.MainModule.Types) {
				if (type.Name != "<Module>") {
					// Check every method for calls that match our issues lists
					foreach (MethodDefinition method in type.Methods) {
						if (method.Body != null) {
							foreach (Instruction i in method.Body.Instructions) {
								if (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt || i.OpCode == OpCodes.Calli || i.OpCode == OpCodes.Ldftn || i.OpCode == OpCodes.Ldvirtftn || i.OpCode == OpCodes.Newobj || i.OpCode == OpCodes.Initobj) {
									Method match;

									if (mono_todo != null && mono_todo.Matches (i.Operand.ToString (), out match))
										mono_todo_results.Add (new MonoTodoError (new Method (method.ToString ()), match));

									if (not_implemented != null && not_implemented.Matches (i.Operand.ToString (), out match))
										not_implemented_results.Add (new NotImplementedExceptionError (new Method (method.ToString ()), match));

									if (pinvoke.Matches (i.Operand.ToString (), out match))
										pinvoke_results.Add (new PInvokeError (new Method (method.ToString ()), match));

									if (missing.Matches (i.Operand.ToString (), out match))
										missing_results.Add (new MissingMethodError (new Method (method.ToString ()), match));
								}
							}
						}
					}

					// Check every constructor for calls that match our issues lists
					foreach (MethodDefinition method in type.Constructors) {
						if (method.Body != null) {
							foreach (Instruction i in method.Body.Instructions) {
								if (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt || i.OpCode == OpCodes.Calli || i.OpCode == OpCodes.Ldftn || i.OpCode == OpCodes.Ldvirtftn || i.OpCode == OpCodes.Newobj || i.OpCode == OpCodes.Initobj) {
									Method match;

									if (mono_todo != null && mono_todo.Matches (i.Operand.ToString (), out match))
										mono_todo_results.Add (new MonoTodoError (new Method (method.ToString ()), match));

									if (not_implemented != null && not_implemented.Matches (i.Operand.ToString (), out match))
										not_implemented_results.Add (new NotImplementedExceptionError (new Method (method.ToString ()), match));

									if (pinvoke.Matches (i.Operand.ToString (), out match))
										pinvoke_results.Add (new PInvokeError (new Method (method.ToString ()), match));

									if (missing.Matches (i.Operand.ToString (), out match))
										missing_results.Add (new MissingMethodError (new Method (method.ToString ()), match));
								}
							}
						}
					}
				}
			}
		}

		public XhtmlTextWriter BeginHtmlReport (Stream output)
		{
			StreamWriter sw = new StreamWriter (output);
			XhtmlTextWriter writer = new XhtmlTextWriter (sw);

			writer.WriteBeginTag ("html");
			writer.WriteAttribute ("xmlns", "http://www.w3.org/1999/xhtml");
			writer.Write (HtmlTextWriter.TagRightChar);
			writer.WriteFullBeginTag ("head");

			writer.WriteFullBeginTag ("title");
			writer.WriteEncodedText ("MoMa Report");
			writer.WriteEndTag ("title");

			WriteCss (writer);

			writer.WriteEndTag ("head");
			writer.WriteFullBeginTag ("body");

			writer.WriteFullBeginTag ("h1");
			writer.WriteEncodedText ("MoMA Scan Results");
			writer.WriteEndTag ("h1");
			
			writer.WriteBreak ();
			writer.WriteEncodedText (String.Format ("Scan time: {0}" , DateTime.Now.ToString ()));
			writer.WriteBreak ();
			writer.WriteBreak ();
			writer.Write ("For descriptions of issues and what to do, see <a href=\"http://www.mono-project.com/MoMA_-_Issue_Descriptions\">http://www.mono-project.com/MoMA_-_Issue_Descriptions</a>.");
			writer.WriteBreak ();
			writer.WriteBreak ();
			
			return writer;
		}

		public StreamWriter BeginTextReport (Stream output)
		{
			return new StreamWriter (output);
		}

		public void AddResultsToHtmlReport (XhtmlTextWriter writer)
		{
			if (missing_results.Count + pinvoke_results.Count + not_implemented_results.Count + mono_todo_results.Count == 0) {
				writer.WriteFullBeginTag ("h3");
				writer.WriteEncodedText ("No Issues Found");
				writer.WriteEndTag ("h3");
				writer.WriteBreak ();
			}
			else {
				OutputHtmlResults (writer, "Methods missing from Mono", missing_results, "Calling Method", "Method not yet in Mono");
				OutputHtmlResults (writer, "P/Invokes into native code", pinvoke_results, "Calling Method", "P/Invoke Method", "External DLL");
				OutputHtmlResults (writer, "Methods called that throw NotImplementedException", not_implemented_results, "Calling Method", "Mono method that throws NotImplementedException");
				OutputHtmlResults (writer, "Methods called marked with [MonoTodo]", mono_todo_results, "Calling Method", "Method with [MonoTodo]", "Reason");
			}
		}

		public void AddResultsToTextReport (StreamWriter writer)
		{
			OutputTextResults (writer, "[MISS]", missing_results);
			OutputTextResults (writer, "[PINV]", pinvoke_results);
			OutputTextResults (writer, "[NIEX]", not_implemented_results);
			OutputTextResults (writer, "[TODO]", mono_todo_results);
		}

		private void OutputHtmlResults (XhtmlTextWriter writer, string heading, List<BaseError> results, params string[] tableHeaders)
		{
			if (results.Count == 0)
				return;

			writer.WriteFullBeginTag ("h3");
			writer.WriteEncodedText (heading);
			writer.WriteEndTag ("h3");

			writer.WriteFullBeginTag ("table");
			writer.WriteBeginTag ("tr");
			writer.WriteAttribute ("class", "header");
			writer.Write (HtmlTextWriter.TagRightChar);


			if (tableHeaders != null && tableHeaders.Length > 0) {
				foreach (string s in tableHeaders) {
					writer.WriteFullBeginTag ("td");
					writer.WriteEncodedText (s);
					writer.WriteEndTag ("td");
				}
			}

			writer.WriteEndTag ("tr");

			bool odd = false;
			string previous_class = string.Empty;

			foreach (BaseError be in results) {
				if (previous_class != be.GetCaller ().Class) {
					writer.WriteBeginTag ("tr");
					writer.WriteAttribute ("class", "class");
					writer.Write (HtmlTextWriter.TagRightChar);

					writer.WriteBeginTag ("td");
					writer.WriteAttribute ("colspan", "3");
					writer.Write (HtmlTextWriter.TagRightChar);

					writer.WriteEncodedText ("Class " + be.GetCaller ().Class + ":");
					writer.WriteEndTag ("td");
					writer.WriteEndTag ("tr");


				}
				be.WriteHtml (writer, odd);
				odd = !odd;
				previous_class = be.GetCaller ().Class;
			}

			writer.WriteEndTag ("table");
			writer.WriteBreak ();
			writer.WriteBreak ();
		}

		private void OutputTextResults (StreamWriter writer, string heading, List<BaseError> results)
		{
			if (results.Count == 0)
				return;

			foreach (BaseError be in results) {
				writer.Write ("{0} ", heading);
				be.WriteText (writer);
			}
		}

		public void FinishHtmlReport (XhtmlTextWriter writer)
		{
			writer.WriteEndTag ("body");
			writer.WriteEndTag ("html");
			writer.Close ();
		}

		public void FinishTextReport (StreamWriter writer)
		{
			writer.Close ();
		}

		public void ClearPInvokeDefinitions ()
		{
			pinvoke_results = new List<BaseError> ();
		}

		private void WriteCss (XhtmlTextWriter writer)
		{
			writer.WriteFullBeginTag ("style");

			writer.WriteLine ("body { background-color: #fff; color: #333; font-family: lucida grande, sans-serif; margin: 5; padding: 0; font-size: 9pt; }");
			writer.WriteLine ("table { font-size: 9pt; width: 100%; padding: 0; margin: 0; font-family: Verdana, Tahoma, Lucida Sans, Sans-Serif; border-collapse: collapse; }");
			writer.WriteLine ("table tr.header { font-weight: bold; font-size: 12px; padding: 5px; background-color: #e8f3d4; border: none; }");
			writer.WriteLine ("table tr.header td { padding: 5px; border: 1px; }");
			writer.WriteLine ("tr.odd { background-color: #F1F5FA; }");
			writer.WriteLine ("tr.class { 	font-weight: bold; }");
			writer.WriteLine ("h1,h2,h3,h4,h5,h6 { color: #68892f; font-family: vag rounded, vag round, arial mt rounded, arial rounded, lucida grande, myriad, andale sans, luxi sans, bitstream vera sans, tahoma, toga sans, helvetica, arial, sans-serif; margin: 0; padding: 0; }");
			writer.WriteLine ("h1 { font-size: 2.25em; }");
			writer.WriteLine ("h2 { margin-bottom: .5em; font-size: 1.75em; }");
			writer.WriteLine ("h3 { margin-bottom: .45em; font-size: 1.25em; }");

			writer.WriteEndTag ("style");
		}
		
		public static bool IsValidAssembly (string assembly)
		{
			try {
				AssemblyFactory.GetAssembly (assembly);
				return true;
			}
			catch (Exception) {
				return false;
			}
		}
		
		// results and version are required, the rest is optional
		// returns true if the results were successfully submitted, false if they weren't
		// however you must catch Exceptions for things like network failure, etc.
		public static bool SubmitResults (string results, string version, string name, string email, string organization, string homepage, string comments)
		{
			if (string.IsNullOrEmpty(results) || string.IsNullOrEmpty(version))
				throw new ArgumentException ("You must fill in results and version");
				
			MoMAWebService.MoMASubmit ws = new MoMAWebService.MoMASubmit ();

			string extra = String.Format (
			    "@Definitions: {0}\n" +
			    "@Name: {1}\n" +
			    "@Email: {2}\n" +
			    "@Organization: {3}\n" +
			    "@HomePage: {4}\n" +
			    "@Comments: {5}\n{6}", version,
			    name, email, organization, homepage,
			    comments.Replace ('\n', ' ').Replace ('\r', ' '),
			    results);
		
			return ws.SubmitResults (extra);
		}
	}
}
