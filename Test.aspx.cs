using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.ComponentModel;

public partial class Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
            string filename = Server.MapPath("~/Upload/") + "Test.pdf";

            Process p = new System.Diagnostics.Process();
            p.StartInfo.Arguments = "http://www.google.co.in " + filename;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            p.StartInfo.FileName = Server.MapPath("~/Bin/wkhtmltopdf.exe");

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.Start();
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit(60000);

            // read the exit code, close process
            int returnCode = p.ExitCode;
            p.Close();

            
        
        }
        catch(Exception ex){

            Response.Write(ex);
        }
       
    }

    
}