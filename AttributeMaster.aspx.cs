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
using System.Data;

public partial class AttributeMaster : System.Web.UI.Page
{
    CodeClass Ws = new CodeClass();
    String S = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == false)
        {
            Clear();
        }
    }

    private void IncrID()
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);
        S = "Select Max(AID) From Attribute";
        Cmd = new SqlCommand(S, Cn);
        if ((Convert.ToString(Cmd.ExecuteScalar())) == "")
        {
            TxtAID.Text = "1";
        }
        else if (Convert.ToString(Cmd.ExecuteScalar()) != "")
        {
            TxtAID.Text = (Convert.ToInt64(Convert.ToString(Cmd.ExecuteScalar())) + 1).ToString();
        }
        Cmd.Dispose();
        Cn.Close();
    }
    protected void CmdReset_Click(object sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        IncrID();
        Disp();
        TxtAttribute.Text = "";
    }
    protected void CmdSubmit_Click(object sender, EventArgs e)
    {
        if (TxtAttribute.Text.Trim() == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Enter Attribute');", true);
            return;
        }
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Select Count(*) From Attribute Where Attr=@UN1";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@UN1", TxtAttribute.Text));
        if (Convert.ToInt32((Convert.ToString(Cmd.ExecuteScalar()))) >= 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Attribute already exists.');", true);
            return;
        }
        Cmd.Dispose();
        Cmd.Parameters.Clear();


        S = "Insert Into Attribute Values(@AID,@A1,1)";
        Cmd = new SqlCommand(S, Cn);
        Cmd.Parameters.Add(new SqlParameter("@AID", TxtAID.Text));
        Cmd.Parameters.Add(new SqlParameter("@A1", TxtAttribute.Text));
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cmd.Parameters.Clear();
        Cn.Close();
        Clear();


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

        S = "Select * From Attribute Where Active=1";
        Cmd = new SqlCommand(S, Cn);
        dr = Cmd.ExecuteReader();
        while (dr.Read())
        {
            row = dt.NewRow();
            row[0] = dr["AID"].ToString();
            row[1] = dr["Attr"].ToString();
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
        }
        Cn.Close();
    }
    protected void DG_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlConnection Cn = new SqlConnection(Ws.Con);
        Cn.Open();
        SqlCommand Cmd = default(SqlCommand);

        S = "Update Attribute Set Active=0 Where AID=" + Convert.ToInt32(Convert.ToString(DG.Rows[Convert.ToInt16(e.CommandArgument)].Cells[0].Text)) + "";
        Cmd = new SqlCommand(S, Cn);
        Cmd.ExecuteNonQuery();
        Cmd.Dispose();
        Cn.Close();

        Disp();
    }
}