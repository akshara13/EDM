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


public partial class StudentDetails : System.Web.UI.Page
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

    private void IncrID()
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Max(SID) From StuDtls";
        Cmd = new SqlCommand(S, Cn);
        if ((Convert.ToString(Cmd.ExecuteScalar())) == "")
        {
            TxtSID.Text = "1";
        }
        else if (Convert.ToString(Cmd.ExecuteScalar()) != "")
        {
            TxtSID.Text = (Convert.ToInt64(Convert.ToString(Cmd.ExecuteScalar())) + 1).ToString();
        }
        Cmd.Dispose();
        Cn.Close();
    }

    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        String Str = "";
        if (((TxtName.Text.Trim()) == ""))
        {
            Str = Str + "Enter Student Name \\n";
        }
        if (((TxtFName.Text.Trim()) == ""))
        {
            Str = Str + "Enter Father's Name \\n";
        }
        if (((TxtMName.Text.Trim()) == ""))
        {
            Str = Str + "Enter Mother's Name \\n";
        }
        if (((TxtAge.Text.Trim()) == ""))
        {
            Str = Str + "Enter Age\\n";
        }
        if (((TxtDOB.Text.Trim()) == ""))
        {
            Str = Str + "Enter Date of Birth\\n";
        }
        if (((TxtHighQual.Text.Trim()) == ""))
        {
            Str = Str + "Enter Student's Highest Qualification\\n";
        }
        if (((TxtLastStd.Text.Trim()) == ""))
        {
            Str = Str + "Enter Student's Last Studied Institution Name\\n";
        }
        if (((TxtCQual.Text.Trim()) == ""))
        {
            Str = Str + "Enter Student's Current Qualification\\n";
        }
        if (((TxtDOJ.Text.Trim()) == ""))
        {
            Str = Str + "Enter Date of Joining\\n";
        }
        if (((TxtMobile.Text.Trim()) == ""))
        {
            Str = Str + "Enter Mobile Number\\n";
        }
        if (((TxtMail.Text.Trim()) == ""))
        {
            Str = Str + "Enter Mail-ID\\n";
        }
        if (((TxtCity.Text.Trim()) == ""))
        {
            Str = Str + "Enter City\\n";
        }
        if (((TxtState.Text.Trim()) == ""))
        {
            Str = Str + "Enter State\\n";
        }
        if (((TxtCountry.Text.Trim()) == ""))
        {
            Str = Str + "Enter Country\\n";
        }
        if (Str.Trim() != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Str + "');", true);
            return;
        }
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Select Count(*) From StuDtls Where Mail=@UN1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@UN1", TxtMail.Text));
        if (Convert.ToInt32((Convert.ToString(Cmd.ExecuteScalar()))) >= 1)
        {
            Cn.Close();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mail-ID already exists.');", true);
            return;
        }
        Cmd.Dispose();
        Cmd.Parameters.Clear();


        string Pwd = "";
        Pwd = TxtName.Text.Substring(0, 3).ToString();
        Pwd = Pwd + Ws.RandomNumber(343434, 545454).ToString();

        S = "Insert Into StuDtls Values(@ID,@Nm,@FNm,@MNm,@Age,@DOB,@HQ,@LS,@Mb,@Mail,@Pwd,@City,@St,@Cntry,@CQ,@DOJ,1)";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@ID", TxtSID.Text));
        Cmd.Parameters.Add(new SqlParameter("@Nm", TxtName.Text));
        Cmd.Parameters.Add(new SqlParameter("@FNm", TxtFName.Text));
        Cmd.Parameters.Add(new SqlParameter("@MNm", TxtMName.Text));
        Cmd.Parameters.Add(new SqlParameter("@Age", TxtAge.Text));
        Cmd.Parameters.Add(new SqlParameter("@DOB", TxtDOB.Text));
        Cmd.Parameters.Add(new SqlParameter("@HQ", TxtHighQual.Text));
        Cmd.Parameters.Add(new SqlParameter("@LS", TxtLastStd.Text));
        Cmd.Parameters.Add(new SqlParameter("@Mb", TxtMobile.Text));
        Cmd.Parameters.Add(new SqlParameter("@Mail", TxtMail.Text));
        Cmd.Parameters.Add(new SqlParameter("@Pwd", Pwd));
        Cmd.Parameters.Add(new SqlParameter("@City", TxtCity.Text));
        Cmd.Parameters.Add(new SqlParameter("@St", TxtState.Text));
        Cmd.Parameters.Add(new SqlParameter("@Cntry", TxtCountry.Text));
        Cmd.Parameters.Add(new SqlParameter("@CQ", TxtCQual.Text));
        Cmd.Parameters.Add(new SqlParameter("@DOJ", TxtDOJ.Text));
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        
        Cn.Close();


        string Msg = "";
        Msg = "<b>Dear " + TxtName.Text + "</b><br>Your Details Created Successfully to Our Institution Registry and the details are created by :" + Ws.GetOwnerName(LblDisp.Text) + ".<br><b>Your Student-ID is :</b> " + TxtSID.Text + ";<br><b>Your Password is :</b> " + Pwd + ".<br><br><font color=red>Kindly keep this mail carefully for entering into the site properly with your correct identification.</font>";
        Ws.MailSending(TxtMail.Text, "Admin - Registration Created", Msg);

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Student Details Added Successfully');", true);
        Clear();

    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        IncrID();
        TxtAge.Text = "";
        TxtCity.Text = "";
        TxtCountry.Text = "";
        TxtCQual.Text = "";
        TxtDOB.Text = "";
        TxtDOJ.Text = "";
        TxtFName.Text = "";
        TxtHighQual.Text = "";
        TxtLastStd.Text = "";
        TxtMail.Text = "";
        TxtMName.Text = "";
        TxtMobile.Text = "";
        TxtName.Text = "";
        TxtState.Text = "";
    }
}
