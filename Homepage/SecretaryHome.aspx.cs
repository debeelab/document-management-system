using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Masterpages_Default : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    SqlDataReader dr;

    String sqlstr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["StaffID"] == null){
            Response.Redirect("Homepage/SecretaryHome.aspx", true);
        }
        GetAllMemo();
        GetNewMemo();
        GetTreatedMemo();
        GetPendingMemo();
    }
    public void GetAllMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (DocumentTypeID) from MM_Memo where MemoUsrID= @staff and DocumentTypeID=3 ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblconfi.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblconfi.Text = "0";
        }


    }
    public void GetNewMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (DepartmentToID) from MM_Memo where MemoUsrID = @staff ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblnewmemo.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblnewmemo.Text = "0";
        }


    }
    public void GetTreatedMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (StatusID) from MM_Memo where statusID='1' and MemoUsrID = @staff";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lbltreated.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lbltreated.Text = "0";
        }


    }
    public void GetPendingMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (StatusID) from MM_Memo where statusID=2 and MemoUsrID = @staff ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblpending.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblpending.Text = "0";
        }


    }
    }

