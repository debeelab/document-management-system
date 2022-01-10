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
            GetMemo();
            GetAlloutgoing();
            GetTreatedOutgoing();
            GetUntreatedOutgoing();
            GetConfidentialoutgoing();
        }
        PnlOutgoingmail.Visible = true;
        pnldisplay.Visible = false;
        Pnltimeline.Visible = false;
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

    private void GetMemo() 
    {
        try
        {
            //Check Roles
            if (Session["RoleName"].ToString() == "Administrator")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject,MM_Memo.MemoBody, MM_Memo.DateTreated, " +
                "DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID=ADM_Department_1.DepartmentName, " +
                "DocumentTypeID=ADM_DocumentType.DocumentType,DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName " +
                "FROM MM_Memo INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID  " +
                "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID  " +
                "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " + 
                "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId";
        cmd = new SqlCommand(str, conn);
        //cmd.Parameters.AddWithValue("@usr", Session["StaffID"]);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMemo.DataSource = ds.Tables[0];
            gvMemo.DataBind();
        }
        conn.Close();

        }

        else if (Session["RoleName"].ToString() == "Director") 
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject,MM_Memo.MemoBody, MM_Memo.DateCreated, " +
                    "DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID=ADM_Department_1.DepartmentName, " +
                    "DocumentTypeID=ADM_DocumentType.DocumentType,RecievedBy, StatusID=ADM_Status.StatusName " +
                    "FROM MM_Memo " +
                    "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID  " +
                    "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID  " +
                    "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                    "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId WHERE MM_Memo.CreatedBy=@Usr ";
           
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@usr", Session["StaffID"]);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvMemo.DataSource = ds.Tables[0];
                gvMemo.DataBind();

            }
        }
        //gvMemo.UseAccessibleHeader = true;
        //gvMemo.HeaderRow.TableSection = TableRowSection.TableHeader;
        conn.Close();


        }


        catch { 
        }
        
    }

    private void GetStatus() 
    {
        conn = new SqlConnection(sqlstr);
        string str = "select *, (select StatusName AS [Status] from ADM_Status where StatusID = MM_Memo.StatusID) from MM_Memo ";
        cmd = new SqlCommand(str, conn);

        conn.Open();
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["Untreated"] = ds.Tables[0].Rows[0]["StatusName"].ToString();
        }
    }

    protected void lnkmemo_Click(object sender, EventArgs e)
    {
    }
    protected void btnSendUpdate_Click(object sender, EventArgs e)
    {
        PnlLoadgvw.Visible = false;
        Pnltimeline.Visible = true;
        pnldisplay.Visible = true;

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

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Update MM_Memo Set MemoResponse=@upd, UploadPath=@file,RecievedBy=@reciever, " +
                     "DateTreated=@date Where MemoID = @ID";
        cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@upd", txtreplymemo.Value.Trim());
        cmd.Parameters.AddWithValue("@file", txtfileName.Text);
        cmd.Parameters.AddWithValue("@reciever", Session["StaffID"]);
        cmd.Parameters.AddWithValue("@date", SqlDbType.DateTime).Value = DateTime.Now;
        cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        if (cmd.ExecuteNonQuery() == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
            GetMemo();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        }
        conn.Close();
    }
    
    protected void RepeatervwSent_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton downloadlink = (LinkButton)e.Item.FindControl("lnkgetdownloadreplied");
            Label sentby = (Label)e.Item.FindControl("lblreplied");
        }
    }

    protected void gvMemo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        Session["MemoID"] = ID;

        lblSubject.Attributes.Add("readonly", "readonly");
        lbldocType.Attributes.Add("readonly", "readonly");
        lblStatus.Attributes.Add("readonly", "readonly");
        lbldeptTo.Attributes.Add("readonly", "readonly");
        lblPriority.Attributes.Add("readonly", "readonly");
        psender.Attributes.Add("readonly", "readonly");
        presponse.Attributes.Add("readonly", "readonly");

        if ((e.CommandName == "Showmemo") ||(e.CommandName == "ViewReply"))
        {

            conn = new SqlConnection(sqlstr);
            conn.Open();

            //string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, MemoUsrID=ADM_Users.FullName,DepartmentToID=ADM_Department_1.DepartmentName, " +
            //    "DepartmentfromID=ADM_Department.DepartmentName, StatusID=ADM_Status.StatusName, MM_Memo.MemoBody,UploadPath," +
            //    "DocumentTypeID=ADM_DocumentType.DocumentType, CreatedBy=ADM_Users_1.FullName, MM_Memo.DateCreated, MM_Memo.DateTreated " +
            //   "FROM MM_Memo " +
            //   "INNER JOIN ADM_Users ON MM_Memo.MemoUsrID = ADM_Users.UserID " +
            //   "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " + 
            //   "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
            //   "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
            //   "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
            //   "INNER JOIN ADM_Users AS ADM_Users_1 ON MM_Memo.CreatedBy = ADM_Users_1.StaffID " +
            //   "WHERE MemoID = @ID";

            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, MemoUsrID=ADM_Users.FullName,DepartmentToID=ADM_Department_1.DepartmentName, " +
                         "DepartmentfromID=ADM_Department.DepartmentName, StatusID=ADM_Status.StatusName, MM_Memo.MemoBody,PriorityID=ADM_PRIORITY.PriorityName," +
                         "UploadPath, CreatedBy=ADM_Users_1.FullName, MM_Memo.DateCreated, " +
                         "DocumentTypeID=ADM_DocumentType.DocumentType, MM_Memo.DateTreated " +
                         "FROM MM_Memo " +
                         "INNER JOIN ADM_Users ON MM_Memo.MemoUsrID = ADM_Users.UserID " +
                         "INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " + 
                         "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID " +
                         "INNER JOIN ADM_Status ON MM_Memo.StatusID = ADM_Status.StatusId " +
                         "INNER JOIN ADM_DocumentType ON MM_Memo.DocumentTypeID = ADM_DocumentType.DocumentTypeID " +
                         "INNER JOIN ADM_Users AS ADM_Users_1 ON MM_Memo.CreatedBy = ADM_Users_1.StaffID " + 
                         "INNER JOIN ADM_PRIORITY ON ADM_PRIORITY.PriorityID = MM_Memo.PriorityID  " +
                         "WHERE MemoID = @ID";
         
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                PnlLoadgvw.Visible = false;
                Pnltimeline.Visible = true;
                pnldisplay.Visible = true;

                lblmemoid.Text = ds.Tables[0].Rows[0]["MemoID"].ToString();
                lblSubject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                lblPriority.Text = ds.Tables[0].Rows[0]["PriorityID"].ToString();
                lbldocType.Text = ds.Tables[0].Rows[0]["DocumentTypeID"].ToString();
                lbldeptTo.Text = ds.Tables[0].Rows[0]["DepartmentToID"].ToString() + " / " + ds.Tables[0].Rows[0]["MemoUsrID"].ToString();
                lblFrom.Text = ds.Tables[0].Rows[0]["DepartmentfromID"].ToString() + " / " + ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblresponse.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["StatusID"].ToString();


                lblSender.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblDateCreated.Text = ds.Tables[0].Rows[0]["DateCreated"].ToString();

                if ((!DBNull.Value.Equals(ds.Tables[0].Rows[0]["MemoBody"].ToString())) || (!DBNull.Value.Equals(ds.Tables[0].Rows[0]["UploadPath"].ToString())))
                {
                    psender.InnerHtml = ds.Tables[0].Rows[0]["MemoBody"].ToString();
                    lnkbtndwnpath.Visible = true;
                    string filepath = Path.GetFileName(ds.Tables[0].Rows[0]["UploadPath"].ToString());
                    lnkbtndwnpath.Text = filepath;
                    Session["dwnload"] = lnkbtndwnpath.Text;

                }
                else
                {
                    //divsendmemo.Visible = false;
                    lnkbtndwnpath.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["StatusID"].ToString() == "Untreated")
                {

                    this.lblStatus.ForeColor = System.Drawing.Color.White;
                    this.lblStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
                    lblStatus.Text = ds.Tables[0].Rows[0]["StatusID"].ToString();
                }
                else
                {
                    this.lblStatus.ForeColor = System.Drawing.Color.White;
                    this.lblStatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");
                    lblStatus.Text = ds.Tables[0].Rows[0]["StatusID"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PriorityID"].ToString() == "High")
                {
                    this.lblPriority.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
                }
                else
                {
                    this.lblPriority.BackColor = System.Drawing.Color.Transparent;
                }
                Session["receiver"] = ds.Tables[0].Rows[0]["MemoUsrID"].ToString();
                
            }
            GetMssg();
            if (presponse.InnerText == string.Empty)
            {
                divresponse.Visible = false;
            }
            else
            {
                divresponse.Visible = true;
            }
        }
    }

    public void GetMssg()
    {
        conn = new SqlConnection(sqlstr);

        //string sql = "select ADM_ReplyMessage.MessageID, RepliedMessage, FileUploadPath, ADM_ReplyMessage.DateTreated from ADM_ReplyMessage " +
        //    "INNER JOIN FileUpload ON FileUpload.MessageID = ADM_ReplyMessage.MessageID " +
        //    "INNER JOIN MM_Memo ON MM_Memo.MemoID = ADM_ReplyMessage.Res_MemoID " +
        //    "WHERE MM_Memo.MemoID = @mm_Memoid ";
        string sql = "SELECT ADM_ReplyMessage.MessageID, Res_MemoID, RepliedMessage , " +
                     "'Re: '+(SELECT Subject FROM MM_Memo WHERE MemoID = ADM_ReplyMessage.Res_MemoID) AS Subject, " +
                     "DateTreated, " +
                     "(SELECT FileUploadpath FROM FileUpload WHERE FileUpload.MessageID=ADM_ReplyMessage.MessageID ) AS Uploadpath, " +
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
           //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
           // { //divreplied.Visible = true;
           // //preplied.InnerHtml = ds.Tables[0].Rows[0]["RepliedMessage"].ToString();
           // //lblDateTreated.Text = ds.Tables[0].Rows[0]["DateTreated"].ToString();
           // }
                RepeatervwSent.DataSource = ds;
                RepeatervwSent.DataBind();
            
            if (!DBNull.Value.Equals("FileUploadpath"))
            {
                LinkButton dwnreply = RepeatervwSent.Items[0].FindControl("lnkgetdownloadreplied") as LinkButton;
                string filepath = Path.GetFileName(ds.Tables[0].Rows[0]["UploadPath"].ToString());
                dwnreply.Text = filepath;
                Session["downloadreplied"] = dwnreply.Text;
            }
            Session["datetreatedby"] = ds.Tables[0].Rows[0]["DateTreated"].ToString();
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
        //string filename = "../Uploads/" + downloadreply;
        Response.Clear();
        Response.ClearHeaders();
        Response.ClearContent();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filename));
        Response.WriteFile(Server.MapPath(filename));
        Response.End();
        Response.Flush();
        
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
        cmd.Parameters.AddWithValue("@receiver", Session["receiver"]);
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
        PnlLoadgvw.Visible = false;
        Pnltimeline.Visible = true;
        pnldisplay.Visible = true;

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
            //getreceiver.Text = Session["receiver"].ToString();

           
           
        }
        catch (Exception ex)
        {
            //throw ex;
        }

        
    }

    protected void gvMemo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblstatus = (Label)e.Row.FindControl("lblStatus");
            Label lbldocType = (Label)e.Row.FindControl("lbldoctype");
            LinkButton vwreply = (LinkButton)e.Row.FindControl("lnkviewreply");
            LinkButton getReject = (LinkButton)e.Row.FindControl("lnkbtnreject");

            if ((lblstatus.Text == "Untreated") || (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "StatusID")) == "Untreated")) 
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#dc3545");
                vwreply.Visible = false;
                getReject.Visible = false;
            }
            else
            {
                lblstatus.BackColor = System.Drawing.ColorTranslator.FromHtml("#006633");
                vwreply.Visible = true;
                getReject.Visible = true;
            }
            if (lbldocType.Text == "Confidential")
            {
                lbldocType.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffc107");
            }
            else
            {
                lbldocType.BackColor = System.Drawing.Color.Transparent;
            }
            //if (System.Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Status")) == "Untreated")
            //{
            //    vwreply.Visible = false;
            //}
            //else
            //{
            //    vwreply.Visible = true;
            //}
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

    protected void savechanges_ServerClick(object sender, EventArgs e)
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Update MM_Memo Set StatusID=1 Where MemoID = @ID";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        if (cmd.ExecuteNonQuery() == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        }

    }
}