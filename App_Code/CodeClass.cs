using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


/// <summary>
/// Summary description for CodeClass
/// </summary>
public class CodeClass
{
    string S = "";
    public string Con = "Data Source=VENKAT-PC\\SQLEXPRESS;Initial Catalog=MiningStudentPerformance;Integrated Security=True";

	public CodeClass()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
    public void MailSending(string TOAddr, string Subject, string MailMsg)
    {
        string gMailAccount = "project2014demo@gmail.com";
        string password = "project2014demo#123";
        NetworkCredential loginInfo = new NetworkCredential(gMailAccount, password);
        MailMessage msg = new MailMessage();
        msg.From = new MailAddress(gMailAccount);
        msg.To.Add(new MailAddress(TOAddr));
        msg.Subject = Subject;
        msg.Body = MailMsg;
        msg.IsBodyHtml = true;
        try
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;
            client.Send(msg);
        }
        catch (Exception ex)
        {
        }
    }
    public string GetOwnerName(string UN)
    {
        string functionReturnValue = null;
        functionReturnValue = "";
        SqlConnection Cn = new SqlConnection(Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Name From Register Where Mail=@Ml";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@Ml", UN));
        if (!string.IsNullOrEmpty(Convert.ToString(Cmd.ExecuteScalar())))
        {
            functionReturnValue = Convert.ToString(Cmd.ExecuteScalar());
        }
        else if (string.IsNullOrEmpty(Convert.ToString(Cmd.ExecuteScalar())))
        {
            functionReturnValue = UN;
        }
        Cmd.Dispose();
        Cn.Close();
        return functionReturnValue;
    }


    public string GetStuName(string UN)
    {
        string functionReturnValue = null;
        functionReturnValue = "";
        SqlConnection Cn = new SqlConnection(Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select SName From StuDtls Where Mail=@Ml";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@Ml", UN));
        if (!string.IsNullOrEmpty(Convert.ToString(Cmd.ExecuteScalar())))
        {
            functionReturnValue = Convert.ToString(Cmd.ExecuteScalar());
        }
        else if (string.IsNullOrEmpty(Convert.ToString(Cmd.ExecuteScalar())))
        {
            functionReturnValue = UN;
        }
        Cmd.Dispose();
        Cn.Close();
        return functionReturnValue;
    }
}
