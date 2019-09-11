// downloadfile
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;

public class downloadfile : Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (base.Request.QueryString["f"] == null)
		{
			return;
		}
		string text = base.Request.QueryString["f"].ToString();
		base.Response.Clear();
		if (text.Contains("https"))
		{
			ServicePointManager.ServerCertificateValidationCallback = ((object <p0>, X509Certificate <p1>, X509Chain <p2>, SslPolicyErrors <p3>) => true);
			WebRequest webRequest = WebRequest.Create(text);
			webRequest.Method = "HEAD";
			webRequest.Timeout = 1000;
			string s = WebConfigurationManager.AppSettings["credz"].ToString();
			string str = Convert.ToBase64String(Encoding.Default.GetBytes(s));
			webRequest.Headers["Authorization"] = "Basic " + str;
			webRequest.GetResponse().Close();
		}
		else if (text.Contains("config") || text.Contains("gopher") || text.Contains("http:") || text.Contains("aspx") || text.Contains("localhost") || text.Contains("127.0.0.1") || text.Contains("ftp") || text.Contains("\\") || text.Contains("//") || text.Contains("~"))
		{
			base.Response.Write("<h1>HERP, HACKING ATTEMPT DETECTED, DERP!</h1>");
		}
		else
		{
			if (File.Exists(base.Server.MapPath(text)))
			{
				base.Response.ContentType = base.ContentType;
				base.Response.ContentType = "application/octet-stream";
				base.Response.AddHeader("Content-Disposition", "attachment; filename=HerpDerp.exe");
				FileStream fileStream = new FileStream(base.Server.MapPath(text), FileMode.Open);
				long length = fileStream.Length;
				byte[] buffer = new byte[(int)length];
				fileStream.Read(buffer, 0, (int)length);
				fileStream.Close();
				base.Response.BinaryWrite(buffer);
				base.Response.Flush();
				base.Response.Close();
				base.Response.End();
			}
			base.Response.Write(text + " does not exist!");
		}
		base.Response.End();
	}
}
