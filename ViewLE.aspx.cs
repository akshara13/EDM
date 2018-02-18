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

public partial class ViewLE : System.Web.UI.Page
{
    String a = "";
    String S = "";
    CodeClass Ws = new CodeClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Disp();
            Panel1.Visible = true;
            Panel2.Visible = false;
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

        S = "Select AID,Attr,(Select Count(*) From Post Where AttriD=a.AID) Cnt From Attribute a Order By 3 DESC";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["AID"].ToString();
            row[1] = dr["Attr"].ToString();
            row[2] = dr["Cnt"].ToString();
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
            if (Convert.ToInt16(Convert.ToString(dt.Rows[i][2].ToString())) <=0)
            {
                DG.Rows[i].Cells[2].BackColor = System.Drawing.Color.LightPink;
                DG.Rows[i].Cells[2].Text = "0";
            }
            else if (Convert.ToInt16(Convert.ToString(dt.Rows[i][2].ToString())) >=1)
            {
                DG.Rows[i].Cells[2].BackColor = System.Drawing.Color.LightGreen;
            }
        }

        DG.Columns[0].Visible = false;
        Cn.Close();
    }
    protected void DG_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].Text)) <= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('No Posts are Updated yet for this Attribute.');", true);
            return;
        }

        long ID = 0;
        ID = Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text));
        Disp1(ID);

        Panel1.Visible = false;
        Panel2.Visible = true;
    }

    private void Disp1(long AID)
    {
        DG1.DataSource = null;
        DG1.DataBind();
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        SqlDataReader dr = default(SqlDataReader);
        DataTable dt = new DataTable();
        DataRow row = null;

        dt.Columns.Add("a");
        dt.Columns.Add("b");
        dt.Columns.Add("c");

        S = "Select Post,PostedBy,PostedDT From Post Where AttrID=" + AID + " And Active=1";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["Post"].ToString();
            row[1] = dr["PostedBy"].ToString();
            row[2] = dr["PostedDT"].ToString();
            dt.Rows.Add(row);
        }
        dr.Close();
        Cmd.Dispose();
       
        DG1.DataSource = dt;
        DG1.DataBind();

        int i = 0;
        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            DG1.Rows[i].Cells[0].Text = dt.Rows[i][0].ToString();
            DG1.Rows[i].Cells[1].Text = dt.Rows[i][1].ToString();
            DG1.Rows[i].Cells[2].Text = dt.Rows[i][2].ToString();
        }
        Cn.Close();
    }
}