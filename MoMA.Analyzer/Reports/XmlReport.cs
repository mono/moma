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
using System.Xml;

namespace MoMA.Analyzer
{
	public class XmlReport
	{
		private XmlWriter xml;
		
		private string filename;
		
		private string definitions = string.Empty;
		private string momaversion = string.Empty;
		private string name = string.Empty;
		private string email = string.Empty;
		private string homepage = string.Empty;
		private string organization = string.Empty;
		private string comments = string.Empty;
		private string apptype = string.Empty;

		public XmlReport (string filename)
		{
			this.filename = filename;
		}
		
		#region Properties
		public string Definitions {
			get { return definitions; }
			set { definitions = value; }
		}

		public string MomaVersion {
			get { return momaversion; }
			set { momaversion = value; }
		}

		public string Name {
			get { return name; }
			set { name = value; }
		}

		public string Email {
			get { return email; }
			set { email = value; }
		}

		public string Homepage {
			get { return homepage; }
			set { homepage = value; }
		}

		public string Organization {
			get { return organization; }
			set { organization = value; }
		}

		public string Comments {
			get { return comments; }
			set { comments = value; }
		}

		public string AppType {
			get { return apptype; }
			set { apptype = value; }
		}
		#endregion
		
		#region Public Methods
		public void BeginReport ()
		{
			XmlWriterSettings set = new XmlWriterSettings ();
			set.Indent = true;

			xml = XmlWriter.Create (filename, set);

			xml.WriteStartElement ("report");
			xml.WriteAttributeString ("version", "1.0");

			// Write <metadata> section
			xml.WriteStartElement ("metadata");
			xml.WriteElementString ("definitions", definitions);
			xml.WriteElementString ("momaversion", momaversion);
			xml.WriteElementString ("date", DateTime.Now.ToString ("u"));
			xml.WriteElementString ("name", name);
			xml.WriteElementString ("email", email);
			xml.WriteElementString ("homepage", homepage);
			xml.WriteElementString ("organization", organization);
			xml.WriteElementString ("comments", comments);
			xml.WriteElementString ("apptype", apptype);
			xml.WriteEndElement ();		// metadata

			xml.WriteStartElement ("assemblies");
		}

		public void EndReport ()
		{
			xml.WriteEndElement ();		// assemblies
			xml.WriteEndElement ();		// report

			xml.Close ();
		}
		
		public void WriteAssembly (AssemblyScannedEventArgs e)
		{
			xml.WriteStartElement ("assembly");
			
			xml.WriteAttributeString ("name", e.AssemblyName);
			xml.WriteAttributeString ("version", e.AssemblyVersion.ToString ());
			xml.WriteAttributeString ("runtime", e.AssemblyRuntime);
			xml.WriteAttributeString ("todo", e.MonoTodoResults.Count.ToString ());
			xml.WriteAttributeString ("niex", e.NotImplementedExceptionResults.Count.ToString ());
			xml.WriteAttributeString ("miss", e.MissingMethodResults.Count.ToString ());
			xml.WriteAttributeString ("pinv", e.PInvokeResults.Count.ToString ());

			// Write MonoTodo <issue>'s
			foreach (MonoTodoError er in e.MonoTodoResults) {
				xml.WriteStartElement ("issue");
				xml.WriteAttributeString ("type", "todo");
				xml.WriteElementString ("class", er.GetCaller ().ClassOnly);
				xml.WriteElementString ("caller", er.GetCaller ().ToString ());
				xml.WriteElementString ("method", er.GetCallee ().ToString ());
				xml.WriteElementString ("raw", er.GetCallee ().RawMethod);
				xml.WriteElementString ("data", er.GetCallee ().Data);
				xml.WriteEndElement ();
			}

			// Write NIEX <issue>'s
			foreach (NotImplementedExceptionError er in e.NotImplementedExceptionResults) {
				xml.WriteStartElement ("issue");
				xml.WriteAttributeString ("type", "niex");
				xml.WriteElementString ("class", er.GetCaller ().ClassOnly);
				xml.WriteElementString ("caller", er.GetCaller ().ToString ());
				xml.WriteElementString ("method", er.GetCallee ().ToString ());
				xml.WriteElementString ("raw", er.GetCallee ().RawMethod);
				xml.WriteEndElement ();
			}

			// Write Missing <issue>'s
			foreach (MissingMethodError er in e.MissingMethodResults) {
				xml.WriteStartElement ("issue");
				xml.WriteAttributeString ("type", "miss");
				xml.WriteElementString ("class", er.GetCaller ().ClassOnly);
				xml.WriteElementString ("caller", er.GetCaller ().ToString ());
				xml.WriteElementString ("method", er.GetCallee ().ToString ());
				xml.WriteElementString ("raw", er.GetCallee ().RawMethod);
				xml.WriteEndElement ();
			}

			// Write P/Invoke <issue>'s
			foreach (PInvokeError er in e.PInvokeResults) {
				xml.WriteStartElement ("issue");
				xml.WriteAttributeString ("type", "pinv");
				xml.WriteElementString ("class", er.GetCaller ().ClassOnly);
				xml.WriteElementString ("caller", er.GetCaller ().ToString ());
				xml.WriteElementString ("method", er.GetCallee ().ToString ());
				xml.WriteElementString ("raw", er.GetCallee ().RawMethod);
				xml.WriteElementString ("data", er.GetCallee ().Data);
				xml.WriteEndElement ();
			}
			
			xml.WriteEndElement ();		// assembly
		}
		#endregion
	}
}
