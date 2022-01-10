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
    SqlDataReader dr ;
    SqlDataAdapter adapt;
    
    String sqlstr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        GetNewMemo();
        GetTreatedMemo();
        GetUntreatedMemo();
        GetConfidentialMemo();

        GetAlloutgoing();
        GetTreatedOutgoing();
        GetUntreatedOutgoing();
        GetConfidentialoutgoing();

        PnlOffice.Visible = false;

        LinkButton vdmemo = (LinkButton)Master.FindControl("vwDirectorMemo");
        LinkButton Treated = (LinkButton)Master.FindControl("lnkTreated");
        LinkButton UnTreated = (LinkButton)Master.FindControl("lnkUntreated");
        LinkButton vwAll = (LinkButton)Master.FindControl("lnkvwAll");
    }
    
    public void GetNewMemo()
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Select count (DepartmentToID) from MM_Memo where MemoUsrID = @staff ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblallmemo.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblallmemo.Text = "0";
        }

    }

    public void GetTreatedMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "SELECT Count (StatusID) from MM_Memo Where StatusID='1' and MemoUsrID = @staff";
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

    public void GetUntreatedMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select Count (StatusID) from MM_Memo where StatusID = 2 and MemoUsrID = @staff ";
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

    public void GetConfidentialMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (DocumentTypeID) from MM_Memo where MemoUsrID = @staff AND DocumentTypeID = 3 ";
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

    public void GetAlloutgoing() 
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Select count (DepartmentfromID) from MM_Memo where CreatedBy=@Usr ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Usr", Session["StaffID"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblalloutgoing.Text = Convert.ToString(count.ToString());
           
        }
        else
        {
            lblalloutgoing.Text = "0";
        }

    }

    public void GetTreatedOutgoing()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "SELECT Count (StatusID) from MM_Memo Where StatusID='1' and CreatedBy = @staff";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblTreatedOutgoing.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblTreatedOutgoing.Text = "0";
        }


    }

    public void GetUntreatedOutgoing()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select Count (StatusID) from MM_Memo where StatusID = 2 and CreatedBy = @staff ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblUntreatedOutgoing.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblUntreatedOutgoing.Text = "0";
        }


    }

    public void GetConfidentialoutgoing()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (DocumentTypeID) from MM_Memo where CreatedBY = @staff AND DocumentTypeID = 3 ";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblconfidentialoutgoing.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblconfidentialoutgoing.Text = "0";
        }


    }

    protected void lnkTreated_Click(object sender, EventArgs e)
    {
       
        //Check Roles
        if (Session["RoleName"].ToString() == "Director") 
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            //string str = "SELECT * FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentToID Where MemoUsrId=@Usr";
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                         "DepartmentToID = ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType, " +
                         "StatusID=ADM_Status.StatusName, DateTreated " +
                         "FROM MM_Memo " +
                         "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " + 
                         "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                         "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                         "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
                         "WHERE MemoUsrId=@Usr AND MM_Memo.StatusID=1";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@Usr", Session["LoginID"]);
            //cmd.Parameters.AddWithValue("@memo", Session["MemoID"]);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvTreatedmemo.DataSource = ds.Tables[0];
                gvTreatedmemo.DataBind();
                PnlTreated.Visible = true;

                PnlUntreated.Visible = false;
                PnlConfidential.Visible = false;
                PnlViewAll.Visible = false;
                PnlOffice.Visible = false;
                Pnlmoreinfo.Visible = true;
                PnlOutgoingmail.Visible = false;
            }
            else
            {
                gvTreatedmemo.EmptyDataText = "No data available";
                gvTreatedmemo.DataSource = null;
                gvTreatedmemo.DataBind();
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found.')", true);
              
            }
        }

    }
    protected void lnkUntreated_Click(object sender, EventArgs e)
    {
        //Check Roles
        if ((Session["RoleName"].ToString() == "Director") || (Session["RoleName"].ToString() == "Secretary") || (Session["RoleName"].ToString() == "Unit Head"))
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            //string str = "SELECT * FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentToID Where MemoUsrId=@Usr";
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, MM_Memo.MemoBody, DepartmentfromID=ADM_Department.DepartmentName, " +
                         "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType,MM_Memo.DateCreated," +
                         "StatusID=ADM_Status.StatusName " + 
                         "FROM MM_Memo " +
                         "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " + 
                         "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                         "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                         "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
                         "WHERE MemoUsrId=@Usr AND MM_Memo.StatusID=2 ORDER BY MemoID";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@Usr", Session["LoginID"]);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvUntreated.DataSource = ds.Tables[0];
                gvUntreated.DataBind(); 
                PnlUntreated.Visible = true;

                PnlTreated.Visible = false;
                PnlConfidential.Visible = false;
                PnlViewAll.Visible = false;
                PnlOffice.Visible = false;
                Pnlmoreinfo.Visible = true;
                PnlOutgoingmail.Visible = false;
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found.')", true);
                
            }
        }

    }
    protected void lnkConfidential_Click(object sender, EventArgs e)
    {
       
        //Check Roles
        if ((Session["RoleName"].ToString() == "Director") || (Session["RoleName"].ToString() == "Secretary") || (Session["RoleName"].ToString() == "Unit Head"))
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            //string str = "SELECT * FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentToID Where MemoUsrId=@Usr";
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                         "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType, " +
                         "StatusID=ADM_Status.StatusName FROM MM_Memo " +
                         "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
                         "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                         "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                         "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId WHERE MemoUsrId=@Usr AND MM_Memo.DocumentTypeID=3 ORDER BY MemoID";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@Usr", Session["LoginID"]);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvConfidential.DataSource = ds.Tables[0];
                gvConfidential.DataBind();

                PnlConfidential.Visible = true;

                PnlTreated.Visible = false;
                PnlUntreated.Visible = false;
                PnlViewAll.Visible = false;
                PnlOffice.Visible = false;
                Pnlmoreinfo.Visible = true;
                PnlOutgoingmail.Visible = false;
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found.')", true);
               
            }
        }

    }
    protected void lnkvwAll_Click(object sender, EventArgs e)
    {
       
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                     "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType," + 
                     "MM_memo.CreatedBy, UploadPath, StatusID=ADM_Status.StatusName " +
                     "FROM MM_Memo " +
                     "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
                     "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                     "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                     "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId WHERE MemoUsrID=@usr ORDER BY MemoID";
        cmd = new SqlCommand(str, conn);
        cmd.Parameters.AddWithValue("@usr", Session["LoginID"]);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvwdisplayallmemo.DataSource = ds.Tables[0];
            gvwdisplayallmemo.DataBind();

            PnlViewAll.Visible = true;

            PnlUntreated.Visible = false;
            PnlTreated.Visible = false;
            PnlConfidential.Visible = false;
            PnlOffice.Visible = false;
            Pnlmoreinfo.Visible = true;
            PnlOutgoingmail.Visible = false;

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found.')", true);
            
        }
        conn.Close();
    }
    protected void gvConfidential_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowvw = (DataRowView)e.Row.DataItem;


            Label lblstatus = (Label)e.Row.FindControl("lblconfstatus");


            if (lblstatus.Text == "Untreated")
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
            }
            else
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");

            }

        }
    }
    protected void gvwdisplayallmemo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView rowvw = (DataRowView)e.Row.DataItem;


            Label lblstatus = (Label)e.Row.FindControl("lblvwallstatus");


            if (lblstatus.Text == "Untreated")
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
            }
            else
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");

            }

        }

    }
}