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

public partial class ViewInstructions : System.Web.UI.Page
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
        dt.Columns.Add("d");

        S = "Select AlID,Subj,Alert,DT From Alert Where Active=1 And StaffMail=@M1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@M1", LblDisp.Text));
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["AlID"].ToString();
            row[1] = dr["Subj"].ToString();
            row[2] = dr["Alert"].ToString();
            row[3] = dr["DT"].ToString();
            dt.Rows.Add(row);
        }
        dr.Close();
        Cmd.Dispose();

        DG.DataSource = dt;
        DG.DataBind();

        int Flg = 0;
        int i = 0;

        String Msg="";

        for (i = 0; i <= dt.Rows.Count - 1; i++)
        {
            Msg = dt.Rows[i][2].ToString();
            if (Msg.Length >= 50)
            {
                Msg = Msg.Substring(0, 49).ToString() + "...";
            }

            DG.Rows[i].Cells[0].Text = dt.Rows[i][0].ToString();
            DG.Rows[i].Cells[1].Text = dt.Rows[i][1].ToString();
            DG.Rows[i].Cells[2].Text = Msg;
            DG.Rows[i].Cells[3].Text = dt.Rows[i][3].ToString();
        }

        DG.Columns[0].Visible = false;
        Cn.Close();
    }
    protected void DG_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        long ID = 0;
        ID = Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text));
        Disp1(ID);

        Panel1.Visible = false;
        Panel2.Visible = true;
    }

    private void Disp1(long AID)
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        SqlDataReader dr = default(SqlDataReader);

        S = "Select * From Alert Where AlID=" + AID + "";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        if (dr.Read())
        {
            TxtSubject.Text = dr["Subj"].ToString();
            TxtInfm.Text = dr["Alert"].ToString();
        }
        dr.Close();
        Cmd.Dispose();
        Cn.Close();
    }
}
