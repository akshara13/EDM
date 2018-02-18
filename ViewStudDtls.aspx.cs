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

public partial class ViewStudDtls : System.Web.UI.Page
{
    String a = "";
    String S = "";
    CodeClass Ws = new CodeClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
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
        dt.Columns.Add("d");

        S = "Select * From StuDtls";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["SID"].ToString();
            row[1] = dr["SName"].ToString();
            row[2] = dr["Mail"].ToString();
            row[3] = dr["Active"].ToString();
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
            if (Convert.ToInt16(Convert.ToString(dt.Rows[i][3].ToString())) == 1)
            {
                DG.Rows[i].BackColor = System.Drawing.Color.LightGreen;
            }
            else if (Convert.ToInt16(Convert.ToString(dt.Rows[i][3].ToString())) == 0)
            {
                DG.Rows[i].BackColor = System.Drawing.Color.LightPink;
            }
        }
        Cn.Close();
    }
    protected void DG_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "a")
        {
            SqlConnection Cn = new SqlConnection(Ws.Con);
            Cn.Open();
            SqlCommand Cmd = default(SqlCommand);

            S = "Update StuDtls Set Active=1 Where SID=" + Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text)) + "";
            Cmd = new SqlCommand(S, Cn);
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Cn.Close();

            Disp();
        }
        else if (e.CommandName.ToString() == "b")
        {
            SqlConnection Cn = new SqlConnection(Ws.Con);
            Cn.Open();
            SqlCommand Cmd = default(SqlCommand);

            S = "Update StuDtls Set Active=0 Where SID=" + Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text)) + "";
            Cmd = new SqlCommand(S, Cn);
            Cmd.ExecuteNonQuery();
            Cmd.Dispose();
            Cn.Close();

            Disp();
        }
    }
}