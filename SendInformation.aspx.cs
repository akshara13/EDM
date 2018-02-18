using System;
using System.Collections;
using System.Configuration;
using System.Data;
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

public partial class SendInformation : System.Web.UI.Page
{
    CodeClass Ws = new CodeClass();
    String S = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Clear();
            LblDisp.Text = Session["UN"].ToString();
            Session["UN"] = LblDisp.Text;
        }
    }

    public long IncrID()
    {
        long ID = 0;
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Max(IID) From StuInfm";
        Cmd = new SqlCommand(S, Cn);
        if ((Convert.ToString(Cmd.ExecuteScalar())) == "")
        {
            ID = 1;
        }
        else if (Convert.ToString(Cmd.ExecuteScalar()) != "")
        {
            ID = Convert.ToInt64(Convert.ToString(Cmd.ExecuteScalar())) + 1;
        }
        Cmd.Dispose();
        Cn.Close();

        return ID;
    }
    protected void CmdSend_Click(object sender, EventArgs e)
    {
        String Str = "";
        if (((TxtMail.Text.Trim()) == ""))
        {
            Str = Str + "Enter Student Mail-ID\\n";
        }
        if (((TxtSubject.Text.Trim()) == ""))
        {
            Str = Str + "Enter Subject \\n";
        }
        if (((TxtInfm.Text.Trim()) == ""))
        {
            Str = Str + "Enter Information \\n";
        }
        if (Str.Trim() != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Str + "');", true);
            return;
        }
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Select Count(*) From StuDtls Where Mail=@UN1 And Active=1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@UN1", TxtMail.Text));
        if (Convert.ToInt32((Convert.ToString(Cmd.ExecuteScalar()))) <= 0)
        {
            Cn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Student Mail-ID.');", true);
            return;
        }
        Cmd.Dispose();
        Cmd.Parameters.Clear();

        long ID1 = IncrID();

        S = "Insert Into StuInfm Values(@ID,@SM,@Subj,@Infm,@SBY,(GetDate()),1)";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@ID", ID1));
        Cmd.Parameters.Add(new SqlParameter("@SM", TxtMail.Text));
        Cmd.Parameters.Add(new SqlParameter("@Subj", TxtSubject.Text));
        Cmd.Parameters.Add(new SqlParameter("@Infm", TxtInfm.Text));
        Cmd.Parameters.Add(new SqlParameter("@SBY", LblDisp.Text));
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cmd.Parameters.Clear();

        Cn.Close();

        string Msg = "";
        Msg = "<b>Dear Student</b><br>You received an information from the satff :" + Ws.GetOwnerName(LblDisp.Text) + ".<br>Kindly Login into your portal for further details.";
        Ws.MailSending(TxtMail.Text, "Admin - Receive Information", Msg);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Information Sent Successfully');", true);
        Clear();
    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {        
        TxtInfm.Text = "";
        TxtMail.Text = "";
        TxtSubject.Text = "";
    }
}