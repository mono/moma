using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MoMAExtractor
{
	static class AssemblyManager
	{
		private static string mono_20 = @"C:\Program Files (x86)\Mono-1.9.1\lib\mono\2.0";
		private static string mono_30 = @"C:\Program Files (x86)\Mono-1.9.1\lib\mono\3.0";
		private static string mono_35 = @"C:\Program Files (x86)\Mono-1.9.1\lib\mono\3.5";

		private static string net_20 = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";
		private static string net_30 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0";
		private static string net_35 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5";

		public static List<string> GetAssemblies (bool is_mono, bool use_20, bool use_30, bool use_35, bool use_design, bool mwf_only)
		{
			string path20 = is_mono ? mono_20 : net_20;
			string path30 = is_mono ? mono_30 : net_30;
			string path35 = is_mono ? mono_35 : net_35;

			List<string> assemblies = new List<string> ();

			// I often am only interested in MWF
			if (mwf_only) {
				assemblies.Add (Path.Combine (path20, "System.Windows.Forms.dll"));
				return assemblies;
			}

			// Add 2.0 assemblies
			if (use_20) {
				assemblies.Add (Path.Combine (path20, "Accessibility.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.Build.Engine.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.Build.Framework.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.Build.Tasks.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.Build.Utilities.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.JScript.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.VisualBasic.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.VisualC.dll"));
				assemblies.Add (Path.Combine (path20, "Microsoft.Vsa.dll"));
				assemblies.Add (Path.Combine (path20, "mscorlib.dll"));
				assemblies.Add (Path.Combine (path20, "System.Configuration.dll"));
				assemblies.Add (Path.Combine (path20, "System.Configuration.Install.dll"));
				assemblies.Add (Path.Combine (path20, "System.Data.dll"));
				assemblies.Add (Path.Combine (path20, "System.Data.OracleClient.dll"));
				assemblies.Add (Path.Combine (path20, "System.DirectoryServices.dll"));
				assemblies.Add (Path.Combine (path20, "System.dll"));
				assemblies.Add (Path.Combine (path20, "System.Drawing.dll"));
				assemblies.Add (Path.Combine (path20, "System.EnterpriseServices.dll"));
				assemblies.Add (Path.Combine (path20, "System.Management.dll"));
				assemblies.Add (Path.Combine (path20, "System.Messaging.dll"));
				assemblies.Add (Path.Combine (path20, "System.Runtime.Remoting.dll"));
				assemblies.Add (Path.Combine (path20, "System.Runtime.Serialization.Formatters.Soap.dll"));
				assemblies.Add (Path.Combine (path20, "System.Security.dll"));
				assemblies.Add (Path.Combine (path20, "System.ServiceProcess.dll"));
				assemblies.Add (Path.Combine (path20, "System.Transactions.dll"));
				assemblies.Add (Path.Combine (path20, "System.Web.dll"));
				assemblies.Add (Path.Combine (path20, "System.Web.Services.dll"));
				assemblies.Add (Path.Combine (path20, "System.Windows.Forms.dll"));
				assemblies.Add (Path.Combine (path20, "System.Xml.dll"));

				if (use_design) {
					assemblies.Add (Path.Combine (path20, "System.Design.dll"));
					assemblies.Add (Path.Combine (path20, "System.Drawing.Design.dll"));
				}
			}
			
			// Add 3.0 assemblies
			if (use_30) {
				assemblies.Add (Path.Combine (path30, "PresentationBuildTasks.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationCore.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationFramework.Aero.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationFramework.Classic.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationFramework.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationFramework.Luna.dll"));
				assemblies.Add (Path.Combine (path30, "PresentationFramework.Royale.dll"));
				assemblies.Add (Path.Combine (path30, "ReachFramework.dll"));
				assemblies.Add (Path.Combine (path30, "System.IdentityModel.dll"));
				assemblies.Add (Path.Combine (path30, "System.IdentityModel.Selectors.dll"));
				assemblies.Add (Path.Combine (path30, "System.IO.Log.dll"));
				assemblies.Add (Path.Combine (path30, "System.Printing.dll"));
				assemblies.Add (Path.Combine (path30, "System.Runtime.Serialization.dll"));
				assemblies.Add (Path.Combine (path30, "System.ServiceModel.dll"));
				assemblies.Add (Path.Combine (path30, "System.Speech.dll"));
				assemblies.Add (Path.Combine (path30, "System.Workflow.Activities.dll"));
				assemblies.Add (Path.Combine (path30, "System.Workflow.ComponentModel.dll"));
				assemblies.Add (Path.Combine (path30, "System.Workflow.Runtime.dll"));
				assemblies.Add (Path.Combine (path30, "UIAutomationClient.dll"));
				assemblies.Add (Path.Combine (path30, "UIAutomationClientsideProviders.dll"));
				assemblies.Add (Path.Combine (path30, "UIAutomationProvider.dll"));
				assemblies.Add (Path.Combine (path30, "UIAutomationTypes.dll"));
				assemblies.Add (Path.Combine (path30, "WindowsBase.dll"));
				assemblies.Add (Path.Combine (path30, "WindowsFormsIntegration.dll"));
			}
			
			// Add 3.5 assemblies
			if (use_35) {
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Engine.dll"));
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Framework.dll"));
				
				// Mono puts assemblies before this in \3.5, things after this in \2.0
				if (is_mono)
					path35 = path20;
					
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Conversion.v3.5.dll"));
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Utilities.v3.5.dll"));
				assemblies.Add (Path.Combine (path35, "Microsoft.VisualC.STLCLR.dll"));
				assemblies.Add (Path.Combine (path35, "System.AddIn.Contract.dll"));
				assemblies.Add (Path.Combine (path35, "System.AddIn.dll"));
				assemblies.Add (Path.Combine (path35, "System.Core.dll"));
				assemblies.Add (Path.Combine (path35, "System.Data.DataSetExtensions.dll"));
				assemblies.Add (Path.Combine (path35, "System.Data.Linq.dll"));
				assemblies.Add (Path.Combine (path35, "System.DirectoryServices.AccountManagement.dll"));
				assemblies.Add (Path.Combine (path35, "System.Management.Instrumentation.dll"));
				assemblies.Add (Path.Combine (path35, "System.Net.dll"));
				assemblies.Add (Path.Combine (path35, "System.ServiceModel.Web.dll"));
				assemblies.Add (Path.Combine (path35, "System.Web.Extensions.dll"));
				assemblies.Add (Path.Combine (path35, "System.Windows.Presentation.dll"));
				assemblies.Add (Path.Combine (path35, "System.WorkflowServices.dll"));
				assemblies.Add (Path.Combine (path35, "System.Xml.Linq.dll"));

				if (use_design)
					assemblies.Add (Path.Combine (path35, "System.Web.Extensions.Design.dll"));
			}
			
			for (int i = assemblies.Count - 1; i >= 0; i--)
				if (!File.Exists (assemblies[i]))
					assemblies.RemoveAt (i);
					
			return assemblies;
		}
	}
}
