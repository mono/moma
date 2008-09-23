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
using System.Text;
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
					string date = sr.ReadLine();

					// Yes, this will fail in the year 2100, find one of my grandchildren to complain to...
					fd.Date = new DateTime(int.Parse(date.Substring(6, 2)) + 2000, int.Parse(date.Substring(0, 2)), int.Parse(date.Substring(3, 2)));

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
