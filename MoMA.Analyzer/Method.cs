using System;
using System.Collections.Generic;
using System.Text;

namespace MoMA.Analyzer
{
	public class Method
	{
		private string raw_method;
		private string method_output;
		private string method_output_with_class;
		private string method_class;
		private string data;
		
		public Method (string method)
		{
			raw_method = method;
			
			ParseMethod();
		}

		public Method (string method, string data)
		{
			this.raw_method = method;
			this.data = data;

			ParseMethod ();
		}

		public string RawMethod
		{
			get { return raw_method; }
			set { raw_method = value; }
		}

		public string Data
		{
			get { return data; }
			set { data = value; }
		}

		public string Class
		{
			get { return method_class; }
			set { method_class = value; }
		}

		private void ParseMethod ()
		{
			string return_type;
			string function_name;
			string[] parameters;
			
			if (raw_method.Contains ("modopt("))
			{
				int mod_start = raw_method.IndexOf ("modopt(");
				int mod_end = raw_method.IndexOf (")", mod_start);
				
				raw_method = raw_method.Substring (0, mod_start) + raw_method.Substring (mod_end + 2);
			}

			return_type = raw_method.Substring (0, raw_method.IndexOf (" "));
			
			int colons = raw_method.IndexOf ("::");
			int function_end = raw_method.IndexOf ("(", colons);

			function_name = raw_method.Substring (colons + 2, function_end - colons - 2).Replace ("::", ".");
			
			string parameter_string = raw_method.Substring (function_end + 1, raw_method.Length - function_end - 2);
			
			parameters = parameter_string.Split (',');
			
			string final_parameters = string.Empty;
			
			foreach (string p in parameters)
				final_parameters += (ConvertType (p) + ", ");
				
			final_parameters = final_parameters.Substring (0, final_parameters.Length - 2);
			method_output = string.Format ("{0} {1}({2})", ConvertType (return_type), function_name, final_parameters);
			method_class = raw_method.Substring (raw_method.IndexOf (" ") + 1, colons - raw_method.IndexOf (" ") - 1);
			method_output_with_class = string.Format ("{0} {1}.{2}({3})", ConvertType (return_type), method_class.Substring (method_class.LastIndexOf (".") + 1), function_name, final_parameters);
		
		}
		public override string ToString ()
		{
			return method_output;
		}
		
		public string ToStringWithClass ()
		{
			return method_output_with_class;
		}
		
		private string ConvertType (string type)
		{
			switch (type) {
				case "System.Void":
					return "void";
				case "System.Boolean":
					return "bool";
				case "System.Int32":
					return "int";
				case "System.String":
					return "string";
				case "System.Double":
					return "double";
				case "System.Decimal":
					return "decimal";
				case "System.Char":
					return "char";
				case "System.UInt32":
					return "uint";
				case "System.Void*":
					return "void*";
				case "System.Byte":
					return "byte";
			}
			
			return type.Substring (type.LastIndexOf (".") + 1);
		}
	}
}
