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
using System.IO;

namespace MoMA.Analyzer
{
	public class HtmlReport
	{
		private StreamWriter report;
		
		private string filename;

		private string definitions = string.Empty;
		private string title = string.Empty;
		
		private int counter = 0;
	
		public HtmlReport (string filename)
		{
			this.filename = filename;
		}

		#region Properties
		public string Definitions {
			get { return definitions; }
			set { definitions = value; }
		}
		
		public string Title {
			get { return title; }
			set { title = value; }
		}
		#endregion

		#region Public Methods
		public void BeginReport ()
		{
			report = new StreamWriter (filename);

			report.WriteLine (@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">");
			report.WriteLine (@"<html xmlns=""http://www.w3.org/1999/xhtml"">");
			report.WriteLine (@"<head>");
			report.WriteLine (@"<title>{0}</title>", title);
			report.WriteLine (@"<link rel=""stylesheet"" type=""text/css"" href=""Media/moma.css"" />");
			report.WriteLine (@"<script type=""text/ecmascript"" src=""Media/moma.js""></script>");
			report.WriteLine (@"</head>");
			report.WriteLine (@"<body>");
			
			WriteReportHeader ();
			WriteSummary ();
			BeginTable ();
		}

		public void WriteAssembly (AssemblyScannedEventArgs e)
		{
			WriteTableRow (e.AssemblyName, e.AssemblyVersion.ToString (), e.MissingMethodResults.Count, e.NotImplementedExceptionResults.Count, e.MonoTodoResults.Count, e.PInvokeResults.Count);

			if (e.TotalIssues > 0)
				BeginSubRow ();

			if (e.MissingMethodResults.Count > 0) {
				WriteSubRowHeader ("Calling Method", "Method Missing from Mono", string.Empty);

				foreach (BaseError b in e.MissingMethodResults)
					WriteSubRowContent (b.GetCaller ().ToString (), b.GetCallee ().ToStringWithClass (), string.Empty);
			}

			if (e.NotImplementedExceptionResults.Count > 0) {
				WriteSubRowHeader ("Calling Method", "Method that Throws NotImplementedException", string.Empty);

				foreach (BaseError b in e.NotImplementedExceptionResults)
					WriteSubRowContent (b.GetCaller ().ToString (), b.GetCallee ().ToStringWithClass (), string.Empty);
			}

			if (e.MonoTodoResults.Count > 0) {
				WriteSubRowHeader ("Calling Method", "Method with [MonoTodo]", "Reason");

				foreach (BaseError b in e.MonoTodoResults)
					WriteSubRowContent (b.GetCaller ().ToString (), b.GetCallee ().ToStringWithClass (), b.GetCallee ().Data);
			}

			if (e.PInvokeResults.Count > 0) {
				WriteSubRowHeader ("Calling Method", "P/Invoke Method", "P/Invoke Library");

				foreach (BaseError b in e.PInvokeResults)
					WriteSubRowContent (b.GetCaller ().ToString (), b.GetCallee ().ToStringWithClass (), b.GetCallee ().Data);
			}

			if (e.TotalIssues > 0)
				EndSubRow ();
		}

		public void EndReport (int miss, int niex, int todo, int pinv)
		{
			report.WriteLine ("      </tbody>");
			report.WriteLine ("      <tfoot>");
			report.WriteLine ("        <tr class='tabletotal'>");

			report.WriteLine ("          <td></td>");
			report.WriteLine ("          <td></td>");
			report.WriteLine ("          <td>Totals</td>");
			report.WriteLine ("          <td></td>");
			report.WriteLine ("          <td>{0}</td>", miss);
			report.WriteLine ("          <td>{0}</td>", niex);
			report.WriteLine ("          <td>{0}</td>", todo);
			report.WriteLine ("          <td>{0}</td>", pinv);
			report.WriteLine ("        </tr>");
			report.WriteLine ("      </tfoot>");
			report.WriteLine (@"    </table>");
			report.WriteLine (@"</div>");
			report.WriteLine (@"</body>");
			report.WriteLine (@"</html>");

			report.Close ();
			report.Dispose ();
		}
		#endregion
		
		#region Private Methods
		private void BeginSubRow ()
		{
			report.WriteLine ("        <tr id='el{0}' class='errorlist' style='display: none'>", counter);
			report.WriteLine ("          <td></td>");
			report.WriteLine ("          <td colspan='7'>");
			report.WriteLine ("            <table cellpadding='2' cellspacing='0' width='100%' class='inner-results'>");
		}
		
		private void BeginTable ()
		{
			report.WriteLine (@"    <table class='results-table'>");
			report.WriteLine (@"      <thead>");
			report.WriteLine (@"        <tr>");
			report.WriteLine (@"          <th scope='col'></th>");
			report.WriteLine (@"          <th scope='col'></th>");
			report.WriteLine (@"          <th scope='col'>Assembly</th>");
			report.WriteLine (@"          <th scope='col'>Version</th>");
			report.WriteLine (@"          <th scope='col'>Missing</th>");
			report.WriteLine (@"          <th scope='col'>Not Implemented</th>");
			report.WriteLine (@"          <th scope='col'>Todo</th>");
			report.WriteLine (@"          <th scope='col'>P/Invoke</th>");
			report.WriteLine (@"        </tr>");
			report.WriteLine (@"      </thead>");
			report.WriteLine (@"      <tbody>");
		}

		private void EndSubRow ()
		{
			report.WriteLine ("            </table>");
			report.WriteLine ("          </td>");
			report.WriteLine ("        </tr>");
		}

		private string PassFail (int count)
		{
			if (count > 0)
				return "Media/fail.png";
			else
				return "Media/pass.png";
		}

		private string Pluralize (int count, string singular, string plural)
		{
			if (count == 0)
				return string.Format ("No {0}", plural);
			else if (count == 1)
				return string.Format ("{0} {1}", count, singular);
			else
				return string.Format ("{0} {1}", count, plural);
		}

		private void WriteReportHeader ()
		{
			report.WriteLine (@"    <div class='header'>");
			report.WriteLine (@"        <div class='headertext'>{0}</div>", title);
			report.WriteLine (@"    </div>");
			report.WriteLine (@"    <div class='wrapper'>");
		}
		
		private void WriteSubRowContent (string one, string two, string three)
		{
			report.WriteLine ("              <tr>");
			report.WriteLine ("              <td>{0}</td>", one.Replace ("(", " ("));

			if (string.IsNullOrEmpty (three)) {
				report.WriteLine ("              <td colspan='2'>{0}</td>", two.Replace ("(", " ("));
			} else {
				report.WriteLine ("              <td>{0}</td>", two.Replace ("(", " ("));
				report.WriteLine ("              <td>{0}</td>", three.Replace ("(", " ("));
			}

			report.WriteLine ("              </tr>");
		}
		
		private void WriteSubRowHeader (string one, string two, string three)
		{
			report.WriteLine ("              <tr class='inner-header'>");
			report.WriteLine ("              <td>{0}</td>", one.Replace ("(", " ("));
			
			if (string.IsNullOrEmpty (three)) {
				report.WriteLine ("              <td colspan='2'>{0}</td>", two.Replace ("(", " ("));
			} else {
				report.WriteLine ("              <td>{0}</td>", two.Replace ("(", " ("));
				report.WriteLine ("              <td>{0}</td>", three.Replace ("(", " ("));
			}
			
			report.WriteLine ("              </tr>");
		}
		
		private void WriteSummary ()
		{
			report.WriteLine (@"    <div class='legend'>");

			report.WriteLine (@"      <div>");
			report.WriteLine (@"        Scan Date: {0}<br/>", DateTime.Now.ToString ());
			report.WriteLine (@"        MoMA Definitions: {0}<br/><br/>", definitions);
			report.WriteLine (@"        For descriptions of issues, see <a href='http://www.mono-project.com/MoMA_-_Issue_Descriptions'>MoMA Issue Descriptions</a>.");
			report.WriteLine (@"      </div>");
			
			report.WriteLine (@"    </div>");
		}

		private void WriteTableRow (string assembly, string version, int miss, int niex, int todo, int pinv)
		{
			bool is_error = miss + niex + todo + pinv > 0;
			counter++;
			
			if (is_error) {
				report.WriteLine ("        <tr class='errorrow' onclick='toggle(\"el{0}\", \"img{0}\")'>", counter);
				report.WriteLine ("          <td style='width: 10px'><img id='img{0}' src='Media/plus.png' /></td>", counter);
				report.WriteLine ("          <td style='width: 16px'><img src='Media/fail.png' /></td>");
			} else {
				report.WriteLine ("        <tr>");
				report.WriteLine ("          <td style='width: 10px'></td>");
				report.WriteLine ("          <td style='width: 16px'><img src='Media/pass.png' /></td>");
			}

			report.WriteLine ("          <td>{0}</td>", assembly);
			report.WriteLine ("          <td>{0}</td>", version);
			report.WriteLine ("          <td>{0}</td>", miss);
			report.WriteLine ("          <td>{0}</td>", niex);
			report.WriteLine ("          <td>{0}</td>", todo);
			report.WriteLine ("          <td>{0}</td>", pinv);

			report.WriteLine ("        </tr>");
		}
		#endregion
	}
}
