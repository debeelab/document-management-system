using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Masterpages_Default : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader dr;
    SqlDataAdapter adapt;

    String sqlstr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetConfidentialMemo();
        GetALLMemo();
        GetTreatedMemo();
        GetPendingMemo();

        GetAlloutgoing();
        GetTreatedOutgoing();
        GetUntreatedOutgoing();
        GetConfidentialoutgoing();
       
    }
    
    public void GetALLMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        //string sql = "select * from MM_Memo where CreatedBy =@staff ";
        string sql = "select Count (MemoID) from MM_Memo ";
        cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["Usrid"]);
        Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
        if (count > 0)
        {
            lblnewmemo.Text = Convert.ToString(count.ToString());
        }
        else {
            lblnewmemo.Text = "0";
        }
    }
    public void GetTreatedMemo()
    {

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "select count (StatusID) from MM_Memo where statusID='1'";
        cmd = new SqlCommand(sql, conn);
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
        string sql = "select count (StatusID) from MM_Memo where statusID=2";
        cmd = new SqlCommand(sql, conn);
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
        //string sql = "select Count (*) from MM_Memo where DepartmentToID = 9";
        string sql = "select count (DocumentTypeID) from MM_Memo where DocumentTypeID=3 ";
        cmd = new SqlCommand(sql, conn);
        int count = Convert.ToInt32(cmd.ExecuteScalar());

        DataTable dt = new DataTable();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            lblconf.Text = Convert.ToString(count.ToString());
        }
        else
        {
            lblconf.Text = "0";
        }


    }


    public void GetAlloutgoing()
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Select count (DepartmentfromID) from MM_Memo ";
        cmd = new SqlCommand(sql, conn);
       // cmd.Parameters.AddWithValue("@Usr", Session["StaffID"]);
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
        string sql = "SELECT Count (StatusID) from MM_Memo Where StatusID='1'";
        cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
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
        string sql = "select Count (StatusID) from MM_Memo where StatusID = 2";
        cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
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
        string sql = "select count (DocumentTypeID) from MM_Memo where DocumentTypeID = 3 ";
        cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["StaffID"]);
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

    protected void lnktreated_Click(object sender, System.EventArgs e)
    {
        try
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
        //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= MM_Memo.Status";
        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
            "DepartmentToID=ADM_Department_1.DepartmentName,DocumentTypeID=ADM_DocumentType.DocumentType, MM_Memo.CreatedBy, " +
            "RecievedBy, StatusID=ADM_Status.StatusName, MM_Memo.DateCreated, (SELECT DateTreated FROM ADM_ReplyMessage WHERE Res_MemoID='" + Session["treateddate"] + "' ) AS [DateTreated] " +
            "FROM MM_Memo " +
            "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
            "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
            "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
            "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
            "WHERE MM_Memo.StatusID=1 ORDER BY MemoID ";
        cmd = new SqlCommand(str, conn);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvwTreatedmemo.DataSource = ds.Tables[0];
            gvwTreatedmemo.DataBind();
            PnlTreated.Visible = true;
            PnlAllMemo.Visible = false;
            PnlPending.Visible = false;
            PnlConfidential.Visible = false;

        }
        else
        {
            gvwTreatedmemo.EmptyDataText = "No data available";
            gvwTreatedmemo.DataSource = null;
            gvwTreatedmemo.DataBind();
        }
        }
        catch (Exception) { 
        }
       
        
        
    }
    protected void lnkUntreated_Click(object sender, System.EventArgs e)
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= MM_Memo.Status";
        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
            "DepartmentToID=ADM_Department_1.DepartmentName,DocumentTypeID=ADM_DocumentType.DocumentTypeID, MM_Memo.CreatedBy, " +
            "RecievedBy, StatusID=ADM_Status.StatusName, MM_Memo.DateCreated " +
            "FROM MM_Memo " +
            "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
            "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
            "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
            "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
            "WHERE MM_Memo.StatusID=2 ORDER BY MemoID ";
        cmd = new SqlCommand(str, conn);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvPending.DataSource = ds.Tables[0];
            gvPending.DataBind();
            PnlPending.Visible = true;
            PnlAllMemo.Visible = false;
            PnlTreated.Visible = false;
            PnlConfidential.Visible = false;

        }
        else
        {
        }
    }
    protected void lnkConfidential_Click(object sender, System.EventArgs e)
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= MM_Memo.Status";
        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName," +
            "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType,MM_memo.CreatedBy," +
            "RecievedBy, StatusID=ADM_Status.StatusName, MM_Memo.DateCreated " +
            "FROM MM_Memo " + 
            "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
            "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
            "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
            "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
            "WHERE MM_Memo.DocumentTypeID=3 " +
            "ORDER BY MemoID ";
        cmd = new SqlCommand(str, conn);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvConfidential.DataSource = ds.Tables[0];
            gvConfidential.DataBind();
            PnlConfidential.Visible = true;
            PnlAllMemo.Visible = false;
            PnlPending.Visible = false;
            PnlTreated.Visible = false;

        }
        else
        {
        }
    }
    protected void lnkbtnDisplayAllMemo_Click(object sender, EventArgs e)
    {
        try
        {
            //Check Roles
            conn = new SqlConnection(sqlstr);
            conn.Open();
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " + 
						 "DepartmentToID=ADM_Department_1.DepartmentName, " +
                         "DocumentTypeID=ADM_DocumentType.DocumentType,MM_memo.CreatedBy, RecievedBy, StatusID=ADM_Status.StatusName, PriorityID=ADM_PRIORITY.PriorityName," +
						 "MM_Memo.DateCreated, DateTreated " +
						 "FROM MM_Memo " +
						 "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
						 "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
						 "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
						 "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
                         "INNER JOIN ADM_PRIORITY on ADM_PRIORITY.PriorityID = MM_Memo.PriorityID " +
						 "ORDER BY PriorityID ";
            cmd = new SqlCommand(str, conn);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvwdisplayallmemo.DataSource = ds.Tables[0];
                gvwdisplayallmemo.DataBind();
                PnlAllMemo.Visible = true;
                PnlTreated.Visible = false;
                PnlPending.Visible = false;
                PnlConfidential.Visible = false;

            }
            else
            {
            }
        }
        catch (Exception)
        {
        }
       

    }
    protected void gvwdisplayallmemo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAllstatus = (Label)e.Row.FindControl("lblstatus");
            Label lblAllpriority = (Label)e.Row.FindControl("lblpriority");

            if (lblAllstatus.Text == "Untreated")
            {
                lblAllstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
            }
            else
            {
                lblAllstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");

            }
            if (lblAllpriority.Text == "High")
            {
                lblAllpriority.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
            }
            else
            {
                lblAllpriority.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }
}