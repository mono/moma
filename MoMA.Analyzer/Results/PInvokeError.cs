using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace MoMA.Analyzer
{
	class PInvokeError : BaseError
	{
		public PInvokeError (Method caller, Method callee)
		{
			this.caller = caller;
			this.callee = callee;
		}

		public override void WriteHtml (System.Web.UI.XhtmlTextWriter tw, bool odd)
		{
			if (odd)
			{
			tw.WriteBeginTag ("tr");
			tw.WriteAttribute ("class", "odd");
			tw.Write (HtmlTextWriter.TagRightChar);
			}
			else
				tw.WriteFullBeginTag ("tr");
				
			tw.WriteFullBeginTag ("td");
			tw.WriteEncodedText (caller.ToString ());
			tw.WriteEndTag ("td");
			tw.WriteFullBeginTag ("td");
			tw.WriteEncodedText (callee.ToString ());
			tw.WriteEndTag ("td");
			tw.WriteFullBeginTag ("td");
			tw.WriteEncodedText (callee.Data.ToString ());
			tw.WriteEndTag ("td");
			tw.WriteEndTag ("tr");
		}

		public override void WriteText (System.IO.StreamWriter results)
		{
			results.WriteLine ("{0}-{1}", callee.ToString (), this.callee.Data);
		}
	}
}
