using System;
using System.Collections.Generic;
using System.Text;

namespace MoMA.Analyzer
{
	public abstract class BaseError
	{
		protected Method caller;
		protected Method callee;

		public abstract void WriteHtml (System.Web.UI.XhtmlTextWriter tw, bool odd);
		public abstract void WriteText (System.IO.StreamWriter results);

		public virtual Method GetCaller ()
		{
			return caller;
		}

	}
}
