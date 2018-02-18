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

using System.Data;
using System.Data.SqlClient;

public partial class ViewPosts : System.Web.UI.Page
{
    String a = "";
    String S = "";
    CodeClass Ws = new CodeClass();

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
        DG.DataSource = null;
        DG.DataBind();
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        SqlDataReader dr = default(SqlDataReader);
        DataTable dt = new DataTable();
        DataRow row = null;

        dt.Columns.Add("a");
        dt.Columns.Add("b");
        dt.Columns.Add("c");

        S = "Select * From Post Where Active=1";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["PID"].ToString();
            row[1] = dr["PostedDT"].ToString();
            row[2] = dr["Post"].ToString();
            dt.Rows.Add(row);
        }
        dr.Close();
        Cmd.Dispose();

        DG.DataSource = dt;
        DG.DataBind();

        int Flg = 0;
        int i = 0;

        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            DG.Rows[i].Cells[0].Text = dt.Rows[i][0].ToString();
            DG.Rows[i].Cells[1].Text = dt.Rows[i][1].ToString();
            DG.Rows[i].Cells[2].Text = dt.Rows[i][2].ToString();
        }
        Cn.Close();
        DG.Columns[0].Visible = false;
    }
    protected void DG_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Update Post Set Active=0 Where PID=" + Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text)) + "";
        Cmd = new SqlCommand(S, Cn);
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cn.Close();

        Disp();
    }
}