<%@ WebService Language="C#" Class="MoMASubmit" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;

[WebService(Namespace = "http://mono-project.com/MoMASubmit/")]
public class MoMASubmit  : System.Web.Services.WebService {

    [WebMethod]
    public bool SubmitResults (string results) 
    {
        // QA would like to submit reports as part of testing MoMA/SWF/Mono, but
        // the reports should not affect our totals, so drop them like a bad habit.
        if (results.IndexOf ("qa@novell.com") > 0)
            return true;
            
        StreamWriter sw = null;
        
        try {
            string output_path = this.Server.MapPath ("./Results");
            
            sw = new StreamWriter (Path.Combine (output_path, Guid.NewGuid ().ToString ().Replace ("-", string.Empty) + ".txt"));
            
            sw.WriteLine (DateTime.Now.ToString ());
            sw.WriteLine (this.Context.Request.UserHostAddress.ToString ());
            
            sw.WriteLine (results);
            
            return true;
        }
        catch (Exception) {
            return false;
        }
        finally {
            if (sw != null)
                sw.Close ();
        }
    }
    
    [WebMethod]
    public string GetLatestDefinitionsVersion ()
    {
        // YOU MUST UPDATE THE FOLLOWING 3 STRINGS FOR EACH NEW DEFINITION PACK!!!
        // Note: None of the strings may contain the pipe character "|"
        
        // Opaque user visible string denoting the version on Mono these defs are for, ex: "Mono 1.2.2"
        // MUST match the first line in the version.txt file of the def .zip
        
        string latest_version = "Mono 1.2.6 (Revised)";
        
        // Date the defs were built, used to sort the defs chronologically for the user, ex: "12/01/06"
        // MUST match the second line in the version.txt file of the def .zip
        //string version_date = "12/01/06";
        //string version_date = "02/07/07";
        //string version_date = "05/03/07";
        //string version_date = "08/02/07";
        //string version_date = "11/22/07";
        
        string version_date = "12/18/07";
        
        // http path to download defs from, ex: "http://www.go-mono.com/archive/moma/defs/1.2.2-defs.zip"
        
        string file_path = "http://www.go-mono.com/archive/moma/defs/1.2.6.1-defs.zip";
        
        return string.Format ("{0}|{1}|{2}", latest_version, version_date, file_path);
    }
}

