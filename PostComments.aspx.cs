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

public partial class PostComments : System.Web.UI.Page
{

    CodeClass Ws = new CodeClass();
    String S = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            LblDisp.Text = Session["UN"].ToString();
            Session["UN"] = LblDisp.Text;
        }
    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        TxtTitle.Text = "";
        TxtPost.Text = "";
    }
    
    public long IncrID()
    {
        long ID = 0;
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Max(PID) From Post";
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
        if (((TxtTitle.Text.Trim()) == ""))
        {
            Str = Str + "Enter Title\\n";
        }
        if (((TxtPost.Text.Trim()) == ""))
        {
            Str = Str + "Enter Message to Post\\n";
        }
        if (Str.Trim() != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + Str + "');", true);
            return;
        }
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        long AID = 0;

        S = "Select AID From Attribute Where @Post Like '%' + Attr + '%' And Active=1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@Post",TxtPost.Text));
        if (Convert.ToString(Cmd.ExecuteScalar()).Trim() != "")
        {
            AID = Convert.ToInt64(Convert.ToString(Cmd.ExecuteScalar()));
        }
        Cmd.Parameters.Clear();
        Cmd.Dispose();
        

        long ID1 = IncrID();
        S = "Insert Into Post Values(@ID,@Post,@PBY,(GetDate()),@AID,1)";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@ID", ID1));
        Cmd.Parameters.Add(new SqlParameter("@Post", TxtPost.Text));
        Cmd.Parameters.Add(new SqlParameter("@PBY", LblDisp.Text));
        Cmd.Parameters.Add(new SqlParameter("@AID", AID));
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        Cn.Close();

        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Message Posted Successfully');", true);
        Clear();
    }
}