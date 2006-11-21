<%@ WebService Language="C#" Class="MoMASubmit" %>

using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;

[WebService(Namespace = "http://mono-project.com/MoMASubmit/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class MoMASubmit  : System.Web.Services.WebService {

    [WebMethod]
    public bool SubmitResults (string results) 
    {
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
    
}

