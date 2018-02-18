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

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        if (((TxtUN.Text.Trim()) == "") | ((TxtPwd.Text.Trim()) == ""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Username and Passsword Properly to Proceed.');", true);
            return;
        }
        if ((TxtUN.Text) == "Admin" & (TxtPwd.Text) == "Admin")
        {
            Response.Redirect("AdminHome.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Invalid Authentication.');", true);
        }
    }
}
