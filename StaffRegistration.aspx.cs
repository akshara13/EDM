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


public partial class StaffRegistration : System.Web.UI.Page
{
    CodeClass Ws = new CodeClass();
    String S = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Clear();
        }
    }

    private void IncrID()
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Max(EmpID) From Register";
        Cmd = new SqlCommand(S, Cn);
        if ((Convert.ToString(Cmd.ExecuteScalar())) == "")
        {
            TxtUID.Text = "1";
        }
        else if (Convert.ToString(Cmd.ExecuteScalar()) != "")
        {
            TxtUID.Text = (Convert.ToInt64(Convert.ToString(Cmd.ExecuteScalar())) + 1).ToString();
        }
        Cmd.Dispose();
        Cn.Close();
    }
    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        String Str = "";
        if (((TxtName.Text.Trim()) == ""))
        {
            Str = Str + "Enter Staff Name \\n";
        }
        if (((TxtMail.Text.Trim()) == ""))
        {
            Str = Str + "Enter Mail-ID\\n";
        }
        if (((TxtAge.Text.Trim()) == ""))
        {
            Str = Str + "Enter Age\\n";
        }
        if (((TxtDOB.Text.Trim()) == ""))
        {
            Str = Str + "Enter Date of Birth\\n";
        }
        if (((TxtMobile.Text.Trim()) == ""))
        {
            Str = Str + "Enter Mobile Number\\n";
        }
        if (((TxtQual.Text.Trim()) == ""))
        {
            Str = Str + "Enter Qualification\\n";
        }
        if (((TxtPwd.Text.Trim()) == ""))
        {
            Str = Str + "Enter Password\\n";
        }
        if (((TxtAddress.Text.Trim()) == ""))
        {
            Str = Str + "Enter Address\\n";
        }
        if (Str.Trim() != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Str + "');", true);
            return;
        }
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Select Count(*) From Register Where Mail=@UN1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@UN1", TxtMail.Text));
        if (Convert.ToInt32((Convert.ToString(Cmd.ExecuteScalar()))) >= 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mail-ID already exists.');", true);
            return;
        }
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        Cn.Close();

        Session["Nm"] = TxtName.Text;
        Session["Age"] = TxtAge.Text;
        Session["DOB"] = TxtDOB.Text;
        Session["Qual"] = TxtQual.Text;
        Session["Mb"] = TxtMobile.Text;
        Session["Mail"] = TxtMail.Text;
        Session["Pwd"] = TxtPwd.Text;
        Session["Addr"] = TxtAddress.Text;

        long RN = 0;
        RN = Ws.RandomNumber(2332, 4548);
        Session["Cd"] = RN.ToString();
        Ws.MailSending(TxtMail.Text, "Admin - Security Code " + DateTime.Now + "", "Your Security Code is : " + RN.ToString() + "");

        P1.Visible = false;
        P2.Visible = false;
        P3.Visible = true;
      
    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {

        P1.Visible = true;
        P2.Visible = false;
        P3.Visible = false;

        IncrID();
        TxtAddress.Text = "";
        TxtAge.Text = "";
        TxtDOB.Text = "";
        TxtMail.Text = "";
        TxtMobile.Text = "";
        TxtName.Text = "";
        TxtPwd.Text = "";
        TxtQual.Text = "";
    }
    protected void CmdCheck_Click(object sender, EventArgs e)
    {
        if (Session["Cd"].ToString() == TxtSecCd.Text.ToString())
        {
            SqlConnection Cn = new SqlConnection(Ws.Con);
            Cn.Open();
            SqlCommand Cmd = default(SqlCommand);

            S = "Insert Into Register Values(@ID,@Name,@Age,@DOB,@Qual,@Mb,@Mail,@Pwd,@Addr,0,1)";
            Cmd = new SqlCommand(S, Cn);
            Cmd.Parameters.Add(new SqlParameter("@ID", TxtUID.Text));
            Cmd.Parameters.Add(new SqlParameter("@Name", Session["Nm"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Age", Session["Age"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@DOB", Session["DOB"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Qual", Session["Qual"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Mb", Session["Mb"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Mail", Session["Mail"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Pwd", Session["Pwd"].ToString()));
            Cmd.Parameters.Add(new SqlParameter("@Addr", Session["Addr"].ToString()));
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Cmd.Parameters.Clear();
            Cn.Close();
            Clear();

            P1.Visible = false;
            P3.Visible = false;
            P2.Visible = true;
          
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Security Code');", true);
        }
    }
}
