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

public partial class StudentLogin : System.Web.UI.Page
{
    String S = "";
    CodeClass Ws = new CodeClass();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        SqlCommand Cmd;
        Cn.Open();

        S = "Select Count(*) From StuDtls Where Mail=@UN and Pwd=@Pwd And Active=1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@UN", TxtUN.Text));
        Cmd.Parameters.Add(new SqlParameter("@Pwd", TxtPwd.Text));
        if (Convert.ToInt32(Convert.ToString(Cmd.ExecuteScalar())) >= 1)
        {
            Session["UN"] = TxtUN.Text;
            Response.Redirect("StudHome.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Authentication');", true);
        }
        Cmd.Dispose();
        Cn.Close();
    }
}
