using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace MoMA.Analyzer
{
	public class DefinitionHandler
	{
		public static List<FileDefinition> FindAvailableVersions (string path)
		{
			List<FileDefinition> results = new List<FileDefinition> ();
		
			if (!Directory.Exists (path))
				return results;
				
			foreach (string s in Directory.GetFiles (path, "*.zip"))
			{
				try {
					FileDefinition fd = GetDefinitionFromFile (s);
					
					if (fd != null)
						results.Add (fd);
				}
				catch {
					// Swallow exceptions, file simply won't be available
				}
			}
			
			results.Sort ();
			return results;
		}
		
		private static FileDefinition GetDefinitionFromFile (string s)
		{
			ZipInputStream zs = new ZipInputStream (File.OpenRead (s));
			ZipEntry ze;
			
			while ((ze = zs.GetNextEntry()) != null)
			{
				if (ze.Name == "version.txt")
				{
					StreamReader sr = new StreamReader (zs);
					
					FileDefinition fd = new FileDefinition ();
					
					fd.Version = sr.ReadLine ();
					fd.Date = DateTime.ParseExact (sr.ReadLine (), "MM/dd/yy", new System.Globalization.CultureInfo("en-US").DateTimeFormat);
					fd.FileName = s;
					
					sr.Close ();
					zs.Close ();

					return fd;
				}
			}

			return null;
		}
		
		public static void GetDefinitionStreamsFromBundle (string bundlePath, out Stream monoTodoDefinitions, out Stream notImplementedDefinitions, out Stream missingDefinitions)
		{
			ZipInputStream zs = new ZipInputStream (File.OpenRead (bundlePath));
			ZipEntry ze;

			monoTodoDefinitions = null;
			notImplementedDefinitions = null;
			missingDefinitions = null;
			
			while ((ze = zs.GetNextEntry ()) != null) {
				switch (ze.Name) {
					case "monotodo.txt":
						StreamReader sr = new StreamReader (zs);
						string s = sr.ReadToEnd ();
						monoTodoDefinitions = new MemoryStream (ASCIIEncoding.ASCII.GetBytes (s));
						break;
					case "exception.txt":
						StreamReader sr2 = new StreamReader (zs);
						string s2 = sr2.ReadToEnd ();
						notImplementedDefinitions = new MemoryStream (ASCIIEncoding.ASCII.GetBytes (s2));
						break;
					case "missing.txt":
						StreamReader sr3 = new StreamReader (zs);
						string s3 = sr3.ReadToEnd ();
						missingDefinitions = new MemoryStream (ASCIIEncoding.ASCII.GetBytes (s3));
						break;
					default:
						break;
				}
			}
		}
		
		public static FileDefinition CheckLatestVersionFromInternet ()
		{
			MoMAWebService.MoMASubmit ws = new MoMA.Analyzer.MoMAWebService.MoMASubmit ();
			
			string result = ws.GetLatestDefinitionsVersion ();
			string[] results = result.Split ('|');
			
			FileDefinition fd = new FileDefinition (results[0], results[1], results[2]);
			
			return fd;
		}
	}
}
