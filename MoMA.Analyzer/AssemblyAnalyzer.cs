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
using System.Windows.Forms;
using System.Xml;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace MoMA.Analyzer
{
	public class AssemblyAnalyzer
	{
		#region Private Variables
		private CheckMonoTodo mono_todo;
		private BaseChecker not_implemented;
		private BaseChecker missing;
		private CheckPInvokes pinvoke;

		private List<MomaError> mono_todo_results;
		private List<MomaError> not_implemented_results;
		private List<MomaError> missing_results;
		private List<MomaError> pinvoke_results;
		
		private int todo_total;
		private int niex_total;
		private int miss_total;
		private int pinv_total;
		
		private string assembly_name;
		private string assembly_runtime;
		private Version assembly_version;

		private FileDefinition definitions;
		private List<string> assemblies;
		
		private string html_report_path;
		private string xml_report_path;
		private bool write_html_report;
		private bool write_xml_report;
		
		private HtmlReport r;
		private XmlReport xr;
		#endregion
		
		#region Constructor
		public AssemblyAnalyzer ()
		{
			assemblies = new List<string> ();

			mono_todo_results = new List<MomaError> ();
			not_implemented_results = new List<MomaError> ();
			missing_results = new List<MomaError> ();
			pinvoke_results = new List<MomaError> ();
		}
		#endregion

		#region Properties
		public FileDefinition Definitions {
			get { return definitions; }
			set { 
				if (definitions != value) {
					definitions = value;
				
					LoadDefinitions (definitions.FileName);
				}
			 }
		}
		
		public List<string> Assemblies {
			get { return assemblies; }
		}
		
		public string HtmlReportPath {
			get { return html_report_path; }
			set { html_report_path = value; }
		}
		
		public string XmlReportPath {
			get { return xml_report_path; }
			set { xml_report_path = value; }
		}
		
		public bool WriteHtmlReport {
			get { return write_html_report; }
			set { write_html_report = value; }
		}
		
		public bool WriteXmlReport {
			get { return write_xml_report; }
			set { write_xml_report = value; }
		}
		
		public string AssemblyName {
			get { return assembly_name; }
		}

		public string AssemblyRuntime {
			get { return assembly_runtime; }
			set {
				switch (value) {
					case "NET_1_0":
						assembly_runtime = "1.0";
						break;
					case "NET_1_1":
						assembly_runtime = "1.1";
						break;
					case "NET_2_0":
						assembly_runtime = "2.0";
						break;
					default:
						assembly_runtime = value;
						break;
				}
			}
		}
		
		public Version AssemblyVersion {
			get { return assembly_version; }
		}

		public List<MomaError> MonoTodoResults {
			get { return this.mono_todo_results; }
		}

		public List<MomaError> NotImplementedExceptionResults {
			get { return this.not_implemented_results; }
		}

		public List<MomaError> MissingMethodResults {
			get { return this.missing_results; }
		}

		public List<MomaError> PInvokeResults {
			get { return this.pinvoke_results; }
		}

		public int TotalIssues {
			get { return mono_todo_results.Count + not_implemented_results.Count + missing_results.Count + pinvoke_results.Count; }
		}
		#endregion
		
		#region Public Methods
		public ScanningCompletedEventArgs Analyze ()
		{
			if (write_html_report && string.IsNullOrEmpty (html_report_path))
				throw new InvalidOperationException ("WriteHtmlReport is true but HtmlReportPath is not set.");
			if (write_xml_report && string.IsNullOrEmpty (xml_report_path))
				throw new InvalidOperationException ("WriteXmlReport is true but XmlReportPath is not set.");
			
			// Reset our totals count
			todo_total = 0;
			niex_total = 0;
			miss_total = 0;
			pinv_total = 0;

			BeginReports ();

			// We have to do this first, so we can find methods that
			// call pinvoke methods in the next step.
			foreach (string assem in assemblies)
				ScanAssemblyForPInvokes (assem);
			
			// Scan each assembly for issues, raise event with results
			foreach (string assem in assemblies) {
				AnalyzeAssembly (assem);
				
				todo_total += mono_todo_results.Count;
				niex_total += not_implemented_results.Count;
				miss_total += missing_results.Count;
				pinv_total += pinvoke_results.Count;
				
				AssemblyScannedEventArgs asea = new AssemblyScannedEventArgs (assem, AssemblyRuntime, assembly_version, mono_todo_results, not_implemented_results, missing_results, pinvoke_results);
				OnAssemblyScanned (asea);
				AddAssemblyToReport (asea);
				
				mono_todo_results.Clear ();
				not_implemented_results.Clear ();
				missing_results.Clear ();
				pinvoke_results.Clear ();
			}
			
			// All done!
			ScanningCompletedEventArgs scea = new ScanningCompletedEventArgs (assemblies.Count, todo_total, niex_total, miss_total, pinv_total);
			OnScanningCompleted (scea);
			FinishReports (scea);
			
			return scea;
		}

		public static bool IsValidAssembly (string assembly)
		{
			try {
				AssemblyDefinition.ReadAssembly (assembly);
				return true;
			} catch {
				return false;
			}
		}

		// returns true if the results were successfully submitted, false if they weren't
		// however you must catch Exceptions for things like network failure, etc.
		public bool SubmitResults (string name, string email, string organization, string homepage, string comments, string apptype)
		{
			XmlDocument doc = new XmlDocument ();
			doc.Load (xml_report_path);

			SetXmlMetadataValue (doc, "name", name);
			SetXmlMetadataValue (doc, "email", email);
			SetXmlMetadataValue (doc, "homepage", homepage);
			SetXmlMetadataValue (doc, "organization", organization);
			SetXmlMetadataValue (doc, "comments", comments);

			SetXmlMetadataValue (doc, "apptype", apptype);

			MoMAWebService.MoMASubmit ws = new MoMAWebService.MoMASubmit ();
			return ws.SubmitResults (doc.OuterXml);
		}
		#endregion

		#region Private Methods
		private void AddAssemblyToReport (AssemblyScannedEventArgs e)
		{
			if (write_html_report)
				r.WriteAssembly (e);
						
			if (write_xml_report)
				xr.WriteAssembly (e);
		}
		
		private void AnalyzeAssembly (string assembly)
		{
			AssemblyDefinition ad = AssemblyDefinition.ReadAssembly (assembly);

			assembly_version = ad.Name.Version;
			AssemblyRuntime = ad.Modules.FirstOrDefault()?.Runtime.ToString () ?? "";
			assembly_name = Path.GetFileName (assembly);

			foreach (TypeDefinition type in ad.MainModule.Types) {
				if (type.Name != "<Module>") {
					// Check every method for calls that match our issues lists
					foreach (MethodDefinition method in type.Methods) {
						if (method.Body != null) {
							foreach (Instruction i in method.Body.Instructions) {
								if (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt || i.OpCode == OpCodes.Calli || i.OpCode == OpCodes.Ldftn || i.OpCode == OpCodes.Ldvirtftn || i.OpCode == OpCodes.Newobj || i.OpCode == OpCodes.Initobj) {
									Method match;

									if (mono_todo != null && mono_todo.Matches (i.Operand.ToString (), out match))
										mono_todo_results.Add (new MomaError (new Method (method.ToString ()), match));

									if (not_implemented != null && not_implemented.Matches (i.Operand.ToString (), out match))
										not_implemented_results.Add (new MomaError (new Method (method.ToString ()), match));

									if (pinvoke.Matches (i.Operand.ToString (), out match))
										pinvoke_results.Add (new MomaError (new Method (method.ToString (), method), match));

									if (missing.Matches (i.Operand.ToString (), out match))
										missing_results.Add (new MomaError (new Method (method.ToString ()), match));
								}
							}
						}
					}

					// Check every constructor for calls that match our issues lists
					foreach (MethodDefinition method in type.Methods.Where(m => m.IsConstructor)) {
						if (method.Body != null) {
							foreach (Instruction i in method.Body.Instructions) {
								if (i.OpCode == OpCodes.Call || i.OpCode == OpCodes.Callvirt || i.OpCode == OpCodes.Calli || i.OpCode == OpCodes.Ldftn || i.OpCode == OpCodes.Ldvirtftn || i.OpCode == OpCodes.Newobj || i.OpCode == OpCodes.Initobj) {
									Method match;

									if (mono_todo != null && mono_todo.Matches (i.Operand.ToString (), out match))
										mono_todo_results.Add (new MomaError (new Method (method.ToString ()), match));

									if (not_implemented != null && not_implemented.Matches (i.Operand.ToString (), out match))
										not_implemented_results.Add (new MomaError (new Method (method.ToString ()), match));

									if (pinvoke.Matches (i.Operand.ToString (), out match))
										pinvoke_results.Add (new MomaError (new Method (method.ToString ()), match));

									if (missing.Matches (i.Operand.ToString (), out match))
										missing_results.Add (new MomaError (new Method (method.ToString ()), match));
								}
							}
						}
					}
				}
			}
		}
	
		private void BeginReports ()
		{
			if (write_html_report) {
				EnsureOutputDirectory (html_report_path);

				r = new HtmlReport (this.html_report_path);
				
				r.Definitions = definitions.Version;
				r.Title = "MoMA Scan Results";
				r.BeginReport ();
			}

			if (write_xml_report) {
				EnsureOutputDirectory (xml_report_path);

				xr = new XmlReport (this.xml_report_path);

				xr.Definitions = definitions.Version;
				xr.MomaVersion = Application.ProductVersion;
				xr.BeginReport ();
			}
		}

		private static void EnsureOutputDirectory (string path)
		{
			if (!Directory.Exists (Path.GetDirectoryName (path)))
				Directory.CreateDirectory (Path.GetDirectoryName (path));
		}
		
		private void FinishReports (ScanningCompletedEventArgs e)
		{
			if (write_html_report)
				r.EndReport (e.MissingMethodTotal, e.NotImplementedExceptionTotal, e.MonoTodoTotal, e.PInvokeTotal);
			
			if (write_xml_report)
				xr.EndReport ();
		}

		private void LoadDefinitions (string definitionBundlePath)
		{
			Stream mt;
			Stream ni;
			Stream mi;

			DefinitionHandler.GetDefinitionStreamsFromBundle (definitionBundlePath, out mt, out ni, out mi);

			mono_todo = new CheckMonoTodo (mt);
			not_implemented = new BaseChecker (ni);
			missing = new BaseChecker (mi);

			mt.Close ();
			ni.Close ();
			mi.Close ();
		}

		private void ScanAssemblyForPInvokes (string assembly)
		{
			if (pinvoke == null)
				pinvoke = new CheckPInvokes ();

			pinvoke.FindPInvokesInAssembly (assembly);
		}

		private void SetXmlMetadataValue (XmlDocument doc, string node, string value)
		{
			if (string.IsNullOrEmpty (value))
				return;

			doc.DocumentElement["metadata"][node].InnerText = value;
		}
		#endregion

		#region Events
		public event EventHandler<AssemblyScannedEventArgs> AssemblyScanned;
		public event EventHandler<ScanningCompletedEventArgs> ScanningCompleted;

		protected void OnAssemblyScanned (AssemblyScannedEventArgs e)
		{
			if (AssemblyScanned != null)
				AssemblyScanned (this, e);
		}
		
		protected void OnScanningCompleted (ScanningCompletedEventArgs e)
		{
			if (ScanningCompleted != null)
				ScanningCompleted (this, e);
		}
		#endregion
	}
}
