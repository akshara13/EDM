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

public partial class StudHome : System.Web.UI.Page
{
    String S = "";
    CodeClass Ws = new CodeClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        LblDisp.Text = Session["UN"].ToString();
        Lbl.Text = Ws.GetStuName(LblDisp.Text);
        Session["UN"] = LblDisp.Text;

        LoadPost();
    }

    private void LoadPost()
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        SqlDataReader dr;

        String post = "";

        S = "Select * From Post Where Active=1";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while(dr.Read())
        {
            post = post + "<b><u><font size=4 color=brown>" + Ws.GetStuName(dr[2].ToString()) + "</font>&nbsp;&nbsp;&nbsp;&nbsp;<i>Posted On :</i> " + dr[3].ToString() + "</b></u><br>" + dr[1].ToString() + "<hr size=1 color='red'>";
        }
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        Cn.Close();

        LblPosts.Text = "<Marquee direction='up' scrollamount=3>" + post + "</Marquee>";
    }
}