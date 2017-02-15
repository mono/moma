using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MoMAExtractor
{
	static class AssemblyManager
	{
		private static string mono_20 = @"C:\Program Files (x86)\Mono\lib\mono\2.0";
		private static string mono_30 = @"C:\Program Files (x86)\Mono\lib\mono\3.0";
		private static string mono_35 = @"C:\Program Files (x86)\Mono\lib\mono\3.5";
		private static string mono_40 = @"C:\Program Files (x86)\Mono\lib\mono\4.0";
		private static string mono_droid = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\MonoDroid\v2.0";

		private static string net_20 = @"C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727";
		private static string net_30 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0";
		private static string net_35 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.5";
		private static string net_40 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0";
		private static string net_wp7 = @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\Profile\WindowsPhone";

		public static List<string> GetAssemblies (bool is_mono, bool use_20, bool use_30, bool use_35, bool use_40, bool use_mobile, bool use_design, bool mwf_only)
		{
			string path20 = is_mono ? mono_20 : net_20;
			string path30 = is_mono ? mono_30 : net_30;
			string path35 = is_mono ? mono_35 : net_35;
			string path40 = is_mono ? mono_40 : net_40;
			string pathmobile = is_mono ? mono_droid : net_wp7;

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
				// Mono puts all 3.0 assemblies in \2.0
				if (is_mono)
					path30 = path20;
					
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

				if (use_design)
					assemblies.Add (Path.Combine (path35, "System.Web.Extensions.Design.dll"));
				
				// Mono puts assemblies before this in \3.5, things after this in \2.0
				if (is_mono)
					path35 = path20;
					
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Conversion.v3.5.dll"));
				assemblies.Add (Path.Combine (path35, "Microsoft.Build.Utilities.v3.5.dll"));
				assemblies.Add (Path.Combine (path35, "System.Xml.Linq.dll"));
				assemblies.Add (Path.Combine (path35, "System.Core.dll"));
				assemblies.Add (Path.Combine (path35, "Microsoft.VisualC.STLCLR.dll"));
				assemblies.Add (Path.Combine (path35, "System.AddIn.Contract.dll"));
				assemblies.Add (Path.Combine (path35, "System.AddIn.dll"));
				assemblies.Add (Path.Combine (path35, "System.Data.DataSetExtensions.dll"));
				assemblies.Add (Path.Combine (path35, "System.Data.Linq.dll"));
				assemblies.Add (Path.Combine (path35, "System.DirectoryServices.AccountManagement.dll"));
				assemblies.Add (Path.Combine (path35, "System.Management.Instrumentation.dll"));
				assemblies.Add (Path.Combine (path35, "System.Net.dll"));
				assemblies.Add (Path.Combine (path35, "System.ServiceModel.Web.dll"));
				assemblies.Add (Path.Combine (path35, "System.Web.Extensions.dll"));
				assemblies.Add (Path.Combine (path35, "System.Windows.Presentation.dll"));
				assemblies.Add (Path.Combine (path35, "System.WorkflowServices.dll"));
			}
			
			// Add 4.0 assemblies
			if (use_40) {
				assemblies.Add (Path.Combine (path40, "Accessibility.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.Conversion.v4.0.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.Engine.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.Framework.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.Tasks.v4.0.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.Build.Utilities.v4.0.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.CSharp.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.JScript.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.VisualBasic.Compatibility.Data.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.VisualBasic.Compatibility.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.VisualBasic.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.VisualC.dll"));
				assemblies.Add (Path.Combine (path40, "Microsoft.VisualC.STLCLR.dll"));
				assemblies.Add (Path.Combine (path40, "mscorlib.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationCore.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationFramework.Aero.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationFramework.Classic.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationFramework.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationFramework.Luna.dll"));
				assemblies.Add (Path.Combine (path40, "PresentationFramework.Royale.dll"));
				assemblies.Add (Path.Combine (path40, "ReachFramework.dll"));
				assemblies.Add (Path.Combine (path40, "sysglobl.dll"));
				assemblies.Add (Path.Combine (path40, "System.Activities.Core.Presentation.dll"));
				assemblies.Add (Path.Combine (path40, "System.Activities.dll"));
				assemblies.Add (Path.Combine (path40, "System.Activities.DurableInstancing.dll"));
				assemblies.Add (Path.Combine (path40, "System.Activities.Presentation.dll"));
				assemblies.Add (Path.Combine (path40, "System.AddIn.Contract.dll"));
				assemblies.Add (Path.Combine (path40, "System.AddIn.dll"));
				assemblies.Add (Path.Combine (path40, "System.ComponentModel.Composition.dll"));
				assemblies.Add (Path.Combine (path40, "System.ComponentModel.DataAnnotations.dll"));
				assemblies.Add (Path.Combine (path40, "System.Configuration.dll"));
				assemblies.Add (Path.Combine (path40, "System.Configuration.Install.dll"));
				assemblies.Add (Path.Combine (path40, "System.Core.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.DataSetExtensions.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.Entity.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.Linq.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.OracleClient.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.Services.Client.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.Services.dll"));
				assemblies.Add (Path.Combine (path40, "System.Data.SqlXml.dll"));
				assemblies.Add (Path.Combine (path40, "System.Deployment.dll"));
				assemblies.Add (Path.Combine (path40, "System.Device.dll"));
				assemblies.Add (Path.Combine (path40, "System.DirectoryServices.AccountManagement.dll"));
				assemblies.Add (Path.Combine (path40, "System.DirectoryServices.dll"));
				assemblies.Add (Path.Combine (path40, "System.DirectoryServices.Protocols.dll"));
				assemblies.Add (Path.Combine (path40, "System.dll"));
				assemblies.Add (Path.Combine (path40, "System.Drawing.dll"));
				assemblies.Add (Path.Combine (path40, "System.EnterpriseServices.dll"));
				assemblies.Add (Path.Combine (path40, "System.IdentityModel.dll"));
				assemblies.Add (Path.Combine (path40, "System.IdentityModel.Selectors.dll"));
				assemblies.Add (Path.Combine (path40, "System.IO.Log.dll"));
				assemblies.Add (Path.Combine (path40, "System.Management.dll"));
				assemblies.Add (Path.Combine (path40, "System.Management.Instrumentation.dll"));
				assemblies.Add (Path.Combine (path40, "System.Messaging.dll"));
				assemblies.Add (Path.Combine (path40, "System.Net.dll"));
				assemblies.Add (Path.Combine (path40, "System.Numerics.dll"));
				assemblies.Add (Path.Combine (path40, "System.Printing.dll"));
				assemblies.Add (Path.Combine (path40, "System.Runtime.Caching.dll"));
				assemblies.Add (Path.Combine (path40, "System.Runtime.DurableInstancing.dll"));
				assemblies.Add (Path.Combine (path40, "System.Runtime.Remoting.dll"));
				assemblies.Add (Path.Combine (path40, "System.Runtime.Serialization.dll"));
				assemblies.Add (Path.Combine (path40, "System.Runtime.Serialization.Formatters.Soap.dll"));
				assemblies.Add (Path.Combine (path40, "System.Security.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Activation.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Activities.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Channels.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Discovery.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Routing.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceModel.Web.dll"));
				assemblies.Add (Path.Combine (path40, "System.ServiceProcess.dll"));
				assemblies.Add (Path.Combine (path40, "System.Speech.dll"));
				assemblies.Add (Path.Combine (path40, "System.Transactions.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Abstractions.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.ApplicationServices.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.DataVisualization.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.DynamicData.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Entity.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Extensions.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Mobile.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.RegularExpressions.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Routing.dll"));
				assemblies.Add (Path.Combine (path40, "System.Web.Services.dll"));
				assemblies.Add (Path.Combine (path40, "System.Windows.Forms.DataVisualization.dll"));
				assemblies.Add (Path.Combine (path40, "System.Windows.Forms.dll"));
				assemblies.Add (Path.Combine (path40, "System.Windows.Input.Manipulations.dll"));
				assemblies.Add (Path.Combine (path40, "System.Windows.Presentation.dll"));
				assemblies.Add (Path.Combine (path40, "System.Workflow.Activities.dll"));
				assemblies.Add (Path.Combine (path40, "System.Workflow.ComponentModel.dll"));
				assemblies.Add (Path.Combine (path40, "System.Workflow.Runtime.dll"));
				assemblies.Add (Path.Combine (path40, "System.WorkflowServices.dll"));
				assemblies.Add (Path.Combine (path40, "System.Xaml.dll"));
				assemblies.Add (Path.Combine (path40, "System.XML.dll"));
				assemblies.Add (Path.Combine (path40, "System.Xml.Linq.dll"));
				assemblies.Add (Path.Combine (path40, "UIAutomationClient.dll"));
				assemblies.Add (Path.Combine (path40, "UIAutomationClientsideProviders.dll"));
				assemblies.Add (Path.Combine (path40, "UIAutomationProvider.dll"));
				assemblies.Add (Path.Combine (path40, "UIAutomationTypes.dll"));
				assemblies.Add (Path.Combine (path40, "WindowsBase.dll"));
				assemblies.Add (Path.Combine (path40, "WindowsFormsIntegration.dll"));
				assemblies.Add (Path.Combine (path40, "XamlBuildTask.dll"));

				if (use_design) {
					assemblies.Add (Path.Combine (path40, "System.Data.Services.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Windows.Forms.DataVisualization.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Web.Extensions.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Web.Entity.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Web.DynamicData.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Drawing.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Web.DataVisualization.Design.dll"));
					assemblies.Add (Path.Combine (path40, "System.Data.Entity.Design.dll"));	
				}
			}
			
			if (use_mobile) {
				assemblies.Add (Path.Combine (pathmobile, "mscorlib.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Core.dll"));
				//assemblies.Add (Path.Combine (pathmobile, "System.Device.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Net.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Observable.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Runtime.Serialization.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Servicemodel.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Servicemodel.Web.dll"));
				//assemblies.Add (Path.Combine (pathmobile, "System.Windows.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Xml.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Xml.Linq.dll"));
				assemblies.Add (Path.Combine (pathmobile, "System.Xml.Serialization.dll"));
			}
			
			for (int i = assemblies.Count - 1; i >= 0; i--)
				if (!File.Exists (assemblies[i])) {
					Console.WriteLine (string.Format ("{0} doesn't have: {1}", is_mono ? "Mono" : "MS", Path.GetFileName (assemblies[i])));
					assemblies.RemoveAt (i);
				}
					
			return assemblies;
		}
	}
}
