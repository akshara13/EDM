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

public partial class EditStudentDetails : System.Web.UI.Page
{
    CodeClass Ws = new CodeClass();
    String S = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LblDisp.Text = Session["UN"].ToString();
            Session["UN"] = LblDisp.Text;
            Disp();
        }
    }

    private void Disp()
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        SqlDataReader dr = default(SqlDataReader);

        S = "Select * From StuDtls Where Mail=@M1 And Active=1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@M1", LblDisp.Text));
        dr = Cmd.ExecuteReader();
        if (dr.Read())
        {
            TxtAge.Text = dr["Age"].ToString();
            TxtCity.Text = dr["City"].ToString();
            TxtCountry.Text = dr["Country"].ToString();
            TxtCQual.Text = dr["CurQual"].ToString();
            TxtDOB.Text = dr["DOB"].ToString();
            TxtDOJ.Text = dr["DOJ"].ToString();
            TxtFName.Text = dr["FName"].ToString();
            TxtHighQual.Text = dr["HighQual"].ToString();
            TxtLastStd.Text = dr["LastStudied"].ToString();
            TxtMail.Text = dr["Mail"].ToString();
            TxtMName.Text = dr["MName"].ToString();
            TxtMobile.Text = dr["MbNo"].ToString();
            TxtName.Text = dr["SName"].ToString();
            TxtSID.Text = dr["SID"].ToString();
            TxtState.Text = dr["State"].ToString();            
        }
        dr.Close();
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

        S = "Update StuDtls Set SName=@Nm,FName=@FNm,MName=@MNm,Age=@Age,DOB=@DOB,HighQual=@HQ,LastStudied=@LS,MbNo=@Mb,City=@City,State=@St,Country=@Cntry,CurQual=@CQ Where SID=@ID";
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
        Cmd.Parameters.Add(new SqlParameter("@City", TxtCity.Text));
        Cmd.Parameters.Add(new SqlParameter("@St", TxtState.Text));
        Cmd.Parameters.Add(new SqlParameter("@Cntry", TxtCountry.Text));
        Cmd.Parameters.Add(new SqlParameter("@CQ", TxtCQual.Text));
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        Cn.Close();

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Personal Details Updated Successfully');", true);
        Clear();
    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        Disp();
    }
}