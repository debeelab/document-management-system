using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Drawing;

public partial class Masterpages_Default : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            Session["MemoID"] = null;
            Session["downloadreplied"] = null;
            //GetUntreatedMemo();
           // DisplayAllMemo();
            //vwAll_Click(sender, e);

            //this.lnkbtnfiledwn.Click += new EventHandler(this.lnkbtnfiledwn_Click);
        }
        //lnkTreated_Click(sender, e);
        Pnldisplay.Visible = false;
        PnlvwAllMemo.Visible = false;
        PnlTreated.Visible = false;
        PnlUntreated.Visible = false;
        pnlTimeline.Visible = false;
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        LinkButton vdmemo = (LinkButton)Master.FindControl("vwDirectorMemo");
        LinkButton Treated = (LinkButton)Master.FindControl("lnkTreated");
        LinkButton UnTreated = (LinkButton)Master.FindControl("lnkUntreated");
        LinkButton vwAll = (LinkButton)Master.FindControl("lnkvwAll");
        vwAll.Click += new EventHandler(lnkvwAll_Click);
        Treated.Click += new EventHandler(lnkTreated_Click);
        UnTreated.Click += new EventHandler(lnkUntreated_Click);
    }

    public void ClearField()
    {
        //preplied.InnerText = string.Empty;
    }

    protected void lnkTreated_Click(object sender, EventArgs e)
    {
        //GetTreatedMemo();

         try
        {

            if (Session["RoleName"].ToString() == "Director")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, UploadPath, " +
                   "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType, MM_memo.CreatedBy, " +
                   "RecievedBy, StatusID=ADM_Status.StatusName,PriorityID=ADM_PRIORITY.PriorityName, " +
                   "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) AS comment " +
                   "FROM MM_Memo INNER JOIN ADM_Department ON " +
                   "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
                   "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " +
                   "MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                   "MM_Memo.StatusID = ADM_Status.StatusId INNER JOIN ADM_PRIORITY on ADM_PRIORITY.PriorityID = MM_Memo.PriorityID " +
                   "WHERE MM_Memo.StatusID=1 and MemoUsrID = @staff";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwTreated.DataSource = ds.Tables[0];
                    gvwTreated.DataBind();
                    PnlTreated.Visible = true;
                    
                }
                else
                {
                    gvwTreated.EmptyDataText = "No data available";
                    gvwTreated.DataSource = null;
                    gvwTreated.DataBind();
                   //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No data available.')", true);
                }
            }
            else if (Session["RoleName"].ToString() == "Administrator")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, PriorityID=ADM_PRIORITY.PriorityName," +
                   "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType,MM_memo.CreatedBy, UploadPath, " +
                   "RecievedBy, StatusID=ADM_Status.StatusName, MM_Memo.DateCreated, " +
                   "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) + (select count(memobody) " +
                   "From MM_Memo WHERE MemoID=81 ) AS comment " +
                   "FROM MM_Memo INNER JOIN ADM_Department ON " +
                   "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
                   "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " +
                   "MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                   "MM_Memo.StatusID = ADM_Status.StatusId INNER JOIN ADM_PRIORITY on ADM_PRIORITY.PriorityID = MM_Memo.PriorityID " +
                   "WHERE MM_Memo.StatusID=1";
                cmd = new SqlCommand(str, conn);
                //cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwTreated.DataSource = ds.Tables[0];
                    gvwTreated.DataBind();
                    PnlTreated.Visible = true;
                }
                else
                {
                    gvwTreated.EmptyDataText = "No data available";
                    gvwTreated.DataSource = null;
                    gvwTreated.DataBind();
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No data available.')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You do not have access to this module.!')", true);
            }

        }
         catch (Exception ex)
        {
            throw ex;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cannot connect to the database.')", true);
        }

        PnlTreated.Visible = true;
        PnlvwAllMemo.Visible = false;
        PnlUntreated.Visible = false;

    }

    protected void lnkUntreated_Click(object sender, EventArgs e)
    {
        GetUntreatedMemo();
        PnlUntreated.Visible = true;
        PnlvwAllMemo.Visible = false;
        PnlTreated.Visible = false;

    }

    protected void lnkvwAll_Click(object sender, EventArgs e)
    {
        DisplayAllMemo();
        PnlvwAllMemo.Visible = true;
        PnlUntreated.Visible = false;
        PnlTreated.Visible = false;

    }

    public void GetUntreatedMemo()
    {
        try
        {
            if (Session["RoleName"].ToString() == "Director")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string sql = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                    "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType, " +
                    "MM_Memo.DateCreated,MM_memo.CreatedBy,  UploadPath, PriorityID=ADM_PRIORITY.PriorityName, " +
                    "RecievedBy, StatusID=ADM_Status.StatusName, " +
                    "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) AS comment " +
                    "FROM MM_Memo " +
                    "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
                    "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " + 
                    "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " + 
                    "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " + 
                    "INNER JOIN ADM_PRIORITY on ADM_PRIORITY.PriorityID = MM_Memo.PriorityID " +
                    " WHERE MM_Memo.StatusID=2 and MemoUsrID = @staff order by DateCreated DESC";
                cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@staff", Session["LoginId"]);

                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwUntreated.DataSource = ds.Tables[0];
                    gvwUntreated.DataBind();
                }
                else
                {
                    gvwUntreated.EmptyDataText = "No data available";
                    gvwUntreated.DataSource = null;
                    gvwUntreated.DataBind();
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No Record Found.')", true);

                }

            }
            else if (Session["RoleName"].ToString() == "Administrator")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string sql = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, PriorityID=ADM_PRIORITY.PriorityName," +
                   "DepartmentToID=ADM_Department_1.DepartmentName, DocumentTypeID=ADM_DocumentType.DocumentType,MM_memo.CreatedBy, UploadPath, " +
                   "RecievedBy, StatusID=ADM_Status.StatusName, MM_Memo.DateCreated, " +
                   "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) + (select count(memobody) " +
                   "From MM_Memo WHERE MemoID=81 ) AS comment " +
                   "FROM MM_Memo INNER JOIN ADM_Department ON " +
                   "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
                   "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " +
                   "MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                   "MM_Memo.StatusID = ADM_Status.StatusId INNER JOIN ADM_PRIORITY on ADM_PRIORITY.PriorityID = MM_Memo.PriorityID " +
                   "WHERE MM_Memo.StatusID=2 ORDER BY DateCreated DESC";

                cmd = new SqlCommand(sql, conn);

                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvwUntreated.DataSource = ds.Tables[0];
                    gvwUntreated.DataBind();
                }
                else
                {
                    gvwUntreated.EmptyDataText = "No data available";
                    gvwUntreated.DataSource = null;
                    gvwUntreated.DataBind();
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No Record Found.')", true);

                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You do not have access to this module!')", true);

            }

        }
        catch(Exception ex)
        {
            throw ex;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Database Connection Failed!')", true);
        }
    }
    
    public void DisplayAllMemo()
    {
        try
        {
            if (Session["RoleName"].ToString() == "Administrator")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, memobody, " +
                                     "(SELECT DEPARTMENTNAME from Department Where DEPARTMENTID=MM_Memo.DepartmentfromID) AS [From], " +
                                     "(SELECT DEPARTMENTNAME from Department Where DEPARTMENTID=MM_Memo.DepartmentToID) AS [To], " +
                                     "(SELECT DocumentType FROM ADM_DocumentType WHERE DocumentTypeID=MM_Memo.DocumentTypeID) AS [Document]," +
                                    "(SELECT FullName FROM ADM_Users WHERE StaffID = MM_Memo.CreatedBy) AS [Sentby], " +
                                    "(SELECT FullName FROM ADM_Users WHERE UserID=MM_Memo.MemoUsrID) AS [Receiver],  " +
                                    "UploadPath, " +
                                    "(SELECT StatusName FROM ADM_Status WHERE StatusId=MM_Memo.StatusID) AS [STATUS], " +
                                    "(SELECT PriorityName FROM ADM_PRIORITY WHERE PriorityID= MM_Memo.PriorityID) AS[Priority], " +
                                    "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) AS Comment " +
                                    "FROM MM_Memo";
                cmd = new SqlCommand(str, conn);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvassignedmemo.DataSource = ds.Tables[0];
                    gvassignedmemo.DataBind();

                }
                else
                {
                    gvassignedmemo.EmptyDataText = "No data available";
                    gvassignedmemo.DataSource = null;
                    gvassignedmemo.DataBind();
                }
                conn.Close();
            }
            else if (Session["RoleName"].ToString() == "Director")
            {

                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, memobody, " +
                                     "(SELECT DEPARTMENTNAME from Department Where DEPARTMENTID=MM_Memo.DepartmentfromID) AS [From], " +
                                     "(SELECT DEPARTMENTNAME from Department Where DEPARTMENTID=MM_Memo.DepartmentToID) AS [To], " +
                                     "(SELECT DocumentType FROM ADM_DocumentType WHERE DocumentTypeID=MM_Memo.DocumentTypeID) AS [Document]," +
                                    "(SELECT FullName FROM ADM_Users WHERE StaffID = MM_Memo.CreatedBy) AS [Sentby], " +
                                    "(SELECT FullName FROM ADM_Users WHERE UserID=MM_Memo.MemoUsrID) AS [Receiver],  " +
                                    "UploadPath, " +
                                    "(SELECT StatusName FROM ADM_Status WHERE StatusId=MM_Memo.StatusID) AS [STATUS], " +
                                    "(SELECT PriorityName FROM ADM_PRIORITY WHERE PriorityID= MM_Memo.PriorityID) AS[Priority], " +
                                    "(SELECT Count(RepliedMessage) FROM ADM_ReplyMessage WHERE Res_MemoID=MM_Memo.MemoID ) AS Comment " +
                                    "FROM MM_Memo WHERE MemoUsrID=@usr";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@usr", Session["LoginID"]);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvassignedmemo.DataSource = ds.Tables[0];
                    gvassignedmemo.DataBind();

                }
                else
                {
                    gvassignedmemo.EmptyDataText = "No data available";
                    gvassignedmemo.DataSource = null;
                    gvassignedmemo.DataBind();
                }
                conn.Close();
            }
        
            }
        catch (Exception)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Failed connecting to database.')", true);
        }
        
    }

    protected void gvwTreated_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label treatedattachement = (Label)e.Row.FindControl("lbltreatedattachment");

            if (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")) == "")
            {
                treatedattachement.Visible = false;
            }
            else
            {
                treatedattachement.Visible = true;
                string filename = Path.GetFileName(System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
                treatedattachement.Text = filename;
                //divattachement.Text = (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
            }
        }
    }

    protected void gvwUntreated_RowDataBound(object sender, GridViewRowEventArgs e)
    {


        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblUntreatedstatus");

            Label lblpriority = (Label)e.Row.FindControl("lblUntreatedPriority");
            
            //Label untreatedcomment = (Label)e.Row.FindControl("lblattachment");
            Label divattachement = (Label)e.Row.FindControl("lbluntreatedattachment");

            if (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")) == "")
            {
                divattachement.Visible = false;
            }
            else
            {
                divattachement.Visible = true;
                string filename = Path.GetFileName(System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
                divattachement.Text = filename;
                //divattachement.Text = (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
            }

 


            if (lblstatus.Text == "Untreated")
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
            }
            else
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");

            }
            if (lblpriority.Text == "High")
            {
                lblpriority.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
            }
            else
            {
                lblpriority.BackColor = System.Drawing.Color.Transparent;
            }

        }
    }

    protected void gvassignedmemo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblwAllstatus");
            Label lblpriority = (Label)e.Row.FindControl("lblvwAllPriority");
            //Label lblvwreject = (Label)e.Row.FindControl("lnkbtnvwallReject");
            Label lblvwallreply = (Label)e.Row.FindControl("lnkbtnvwallReply");
            //Control divattachement = (Control)e.Row.FindControl("vwallattachement");
            //divattachement = new Label();

           Label  divattachement = (Label)e.Row.FindControl("lblvwalldwnpath");

           if (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")) == "")
           {
               divattachement.Visible = false;
           }
           else
           {
               divattachement.Visible = true;
               string filename = Path.GetFileName(System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
               divattachement.Text = filename;
               //divattachement.Text = (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));
           }


           if (lblstatus.Text == "Untreated")
           {
               lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
               //lblvwreject.Visible = true;
           }
           else
           {
               lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");
               //lblvwreject.Visible = false;

           }

           //if ((lblstatus.Text == "Untreated") || (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StatusID")) == "Untreated"))
           //{
           //    lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
           //    lblvwallreply.Visible = false;
           //    lblreject.Visible = false;
           //}
           //else
           //{
           //    lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");
           //    lblvwallreply.Visible = true;
           //    lblreject.Visible = true;
           //}
            if (lblpriority.Text == "High")
            {
                lblpriority.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
            }
            else
            {
                lblpriority.BackColor = System.Drawing.Color.Transparent;
            }
        }
    }

    protected void gvassignedmemo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        Session["MemoID"] = ID;

        lblSubject.Attributes.Add("readonly", "readonly");
        lblPriority.Attributes.Add("readonly", "readonly");
        txtdocType.Attributes.Add("readonly", "readonly");
        lblDeptTo.Attributes.Add("readonly", "readonly");
        psender.Attributes.Add("readonly", "readonly");
        //preplied.Attributes.Add("readonly", "readonly");

        if (e.CommandName == "Edit")
        {

            PnlvwAllMemo.Visible = false;
            PnlTreated.Visible = false;
            PnlUntreated.Visible = false;
            pnlTimeline.Visible = true;
            Pnldisplay.Visible = true;



            conn = new SqlConnection(sqlstr);
            conn.Open();
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, MemoUsrID=ADM_Users.FullName,DepartmentToID=ADM_Department_1.DepartmentName, " +
                         "DepartmentfromID=ADM_Department.DepartmentName, StatusID=ADM_Status.StatusName, MM_Memo.MemoBody, PriorityID=ADM_PRIORITY.PriorityName," +
                         "DocumentTypeID=ADM_DocumentType.DocumentType, CreatedBy=ADM_Users_1.FullName, MM_Memo.DateCreated, MM_Memo.DateTreated, UploadPath " +
                         "FROM MM_Memo  " +
                         "INNER JOIN ADM_Users ON MM_Memo.MemoUsrID = ADM_Users.UserID " +
                         "INNER JOIN ADM_Users AS ADM_Users_1 ON MM_Memo.CreatedBy = ADM_Users_1.StaffID " +
                         "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
                         "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                         "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
                         "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +     
                         "INNER JOIN ADM_PRIORITY ON ADM_PRIORITY.PriorityID = MM_Memo.PriorityID  " + 
                         "WHERE MemoID = @ID";

            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            conn.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblmemoid.Text = ds.Tables[0].Rows[0]["MemoID"].ToString();
                lblSubject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                lblPriority.Text = ds.Tables[0].Rows[0]["PriorityID"].ToString();
                txtdocType.Text = ds.Tables[0].Rows[0]["DocumentTypeID"].ToString();
                lblDeptTo.Text = ds.Tables[0].Rows[0]["DepartmentToID"].ToString() + " / " + ds.Tables[0].Rows[0]["MemoUsrID"].ToString();
                lblFrom.Text = ds.Tables[0].Rows[0]["DepartmentfromID"].ToString() + " / " + ds.Tables[0].Rows[0]["CreatedBy"].ToString();

                lblSender.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblDateCreated.Text = ds.Tables[0].Rows[0]["DateCreated"].ToString();

                if (!DBNull.Value.Equals(ds.Tables[0].Rows[0]["MemoBody"].ToString()))
                {
                    divsent.Visible = true;
                    psender.InnerHtml = ds.Tables[0].Rows[0]["MemoBody"].ToString();
                }
                if (!DBNull.Value.Equals(ds.Tables[0].Rows[0]["UploadPath"].ToString()))
                { 
                    lnkbtndwnpath.Visible = true;
                    string filepath = Path.GetFileName(ds.Tables[0].Rows[0]["UploadPath"].ToString());
                    lnkbtndwnpath.Text = filepath; 
                    Session["dwnload"] = lnkbtndwnpath.Text;
                }
                else
                {
                    lnkbtndwnpath.Visible = false;
                }

                if (ds.Tables[0].Rows[0]["StatusID"].ToString() == "Untreated")
                {

                    this.lblUntreated.ForeColor = System.Drawing.Color.White;
                    this.lblUntreated.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
                    lblUntreated.Text = ds.Tables[0].Rows[0]["StatusID"].ToString();
                }
                else
                {
                    this.lblUntreated.ForeColor = System.Drawing.Color.White;
                    this.lblUntreated.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");
                    lblUntreated.Text = ds.Tables[0].Rows[0]["StatusID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PriorityID"].ToString() == "High")
                {
                    this.lblPriority.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
                }
                else
                {
                    this.lblPriority.BackColor = System.Drawing.Color.Transparent;
                }


            }
            GetMssg();
        }
    }

    protected void gvassignedmemo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }

    public void GetMssg()
    {
        conn = new SqlConnection(sqlstr);
        string sql = "SELECT ADM_ReplyMessage.MessageID, Res_MemoID, RepliedMessage , " +
                     "'Re: '+(SELECT Subject FROM MM_Memo WHERE MemoID = ADM_ReplyMessage.Res_MemoID) AS Subject, " +
                     "DateTreated, " +
                     "(SELECT FileUploadpath FROM FileUpload WHERE Fileupload.MessageID=ADM_ReplyMessage.MessageID ) AS Fileupdpath, " +
                     "(SELECT Res_CreatedBy = ADM_Users.FullName FROM ADM_Users WHERE ADM_Users.StaffID = ADM_ReplyMessage.Res_CreatedBy) AS Sentby " +
                     "FROM ADM_ReplyMessage " +
                     "WHERE Res_MemoID=@mssg_Memoid ORDER BY DateTreated ASC ";

        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@mssg_Memoid", Session["MemoID"]);

        conn.Open();
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            //divresponse.Visible = true;
            //divreplied.Visible = true;
            //for (int i= 0; i<ds.Tables[0].Rows.Count; i++)
            //{
            //    //preplied.InnerHtml = ds.Tables[0].Rows[i]["RepliedMessage"].ToString();=

            //}

            rpMessages.DataSource = ds;
            rpMessages.DataBind();


            Session["treateddate"] = ds.Tables[0].Rows[0]["DateTreated"].ToString();
          
        }
        else
        {
            //divreplied.Visible = false;
            //divresponse.Visible = false;
        }
        conn.Close();
    }

    protected void rpMessages_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton downloadlink = (LinkButton)e.Item.FindControl("lnkgetdownloadreplied");
            Label sentby = (Label)e.Item.FindControl("lblreplied");

            //if (sentby.Text == System.Convert.ToString(DataBinder.Eval(e.Item.DataItem, "SentBy")))
            //{
            //    sentby.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
            //}
            //else if (sentby.Text == System.Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Res_ReceivedBy")))
            //{
            //    sentby.BackColor = System.Drawing.ColorTranslator.FromHtml("#adb5bd");
            //}
            if (!DBNull.Value.Equals(System.Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Fileupdpath"))))
            {
                downloadlink.Visible = true;
                string filename = Path.GetFileName(System.Convert.ToString(DataBinder.Eval(e.Item.DataItem, "Fileupdpath")));
                downloadlink.Text = filename;
                //download = downloadlink.Text;
                Session["downloadreplied"] = downloadlink.Text;
                //divattachement.Text = (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UploadPath")));  
            }
            else
            {
                downloadlink.Visible = false;
            }

        }
    }

    public void saverecord()

    {
        DateTime NewDate = DateTime.Now;
        Session["newdate"] = NewDate;

        conn = new SqlConnection(sqlstr);


        cmd = new SqlCommand("str_ReplyToMemo", conn);
        cmd.CommandType = CommandType.StoredProcedure;


        cmd.Parameters.AddWithValue("@replyMssg", txtreplymemo.Value.Trim());
        cmd.Parameters.AddWithValue("@memoid", Session["MemoID"]);
        cmd.Parameters.AddWithValue("@sentby", Session["StaffID"]);
        cmd.Parameters.AddWithValue("@receiver", Session["Createdby"]);
        cmd.Parameters.AddWithValue("@date", NewDate);
        cmd.Parameters.AddWithValue("@file", txtfileName.Text);
        cmd.Parameters.AddWithValue("@updby", Session["StaffID"]);

        conn.Open();

        int i = cmd.ExecuteNonQuery();

        if (i != 0)
        {
            //Display success message.  
            string message = "Your details have been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Inserted Successfully.')", true);

        }
        else
        {
            //Failure success message.
            string message = "Record not saved.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "Failed", script, true);
           // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Inserted.')", true);
        }

        
       
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        PnlvwAllMemo.Visible = false;
        PnlUntreated.Visible = false;
        PnlTreated.Visible = false;
        pnlTimeline.Visible = true;
        Pnldisplay.Visible = true;

        try
        {
            if (fileUploadImage.HasFile)
            {
                string constring = fileUploadImage.FileName;
                fileUploadImage.SaveAs(Server.MapPath("../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName)));
                txtfileName.Text = "../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName);
                label1.Visible = true;
                label1.Text = "File name: " + fileUploadImage.PostedFile.FileName + "<br>" + "File Size: " + fileUploadImage.PostedFile.ContentLength + " kb<br>" + "Content type: " + fileUploadImage.PostedFile.ContentType;

            }
            else
            {
                label1.Visible = true;
                label1.Text = "You have not specified a file.";
            }
            saverecord();
            GetMssg();
            UpdateStatusTo2();
        }
        catch (Exception ex)
        {
            //throw ex;
        }

    }


    public void GetDateTreated()
    {
        string getnewdate = Session["newdate"].ToString();
        conn = new SqlConnection(sqlstr);
        string str = "SELECT * FROM ADM_ReplyMessage WHERE DateTreated= @getdate ";
        cmd = new SqlCommand(str, conn);
        cmd.Parameters.AddWithValue("@getdate", Session["newdate"]);
        conn.Open();
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {

            Session["MssgID"] = ds.Tables[0].Rows[0]["MessageID"].ToString();
            Session["Treateddate"] = ds.Tables[0].Rows[0]["DateTreated"].ToString();
            Session["createddate"] = ds.Tables[0].Rows[0]["DateCreated"].ToString();
        }
        conn.Close();
    }


    protected void lnkbtndwnpath_Click(object sender, EventArgs e)
    {
        string filename = "../Uploads/" + Session["dwnload"].ToString();
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filename));
        Response.WriteFile(Server.MapPath(filename));
        Response.End();
        Response.Flush();


    }

    protected void lnkgetdownloadreplied_Click(object sender, EventArgs e)
    {
        string filename = "../Uploads/" + Session["downloadreplied"].ToString();
        //string filename = "../" + download;
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filename));
        Response.WriteFile(Server.MapPath(filename));
        Response.End();
        Response.Flush();

    }

    protected void savechanges_ServerClick(object sender, EventArgs e)
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Update MM_Memo Set StatusID=1 Where MemoID = @ID";
        //string sql = "Update ADM_ReplyMessage Set Response_Status=1 Where MessageID = @ID";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        //cmd.Parameters.AddWithValue("@ID", Session["MssID"]);
        //cmd.ExecuteNonQuery();
        if (cmd.ExecuteNonQuery() == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        }

    }

    private void UpdateStatusTo2()
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Update MM_Memo Set StatusID=2 Where MemoID = @ID";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        if (cmd.ExecuteNonQuery() == 1)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        }
    }

    protected void btnSendRejectfile_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated.')", true);
        PnlUntreated.Visible = true;
        GetUntreatedMemo();
    }
}