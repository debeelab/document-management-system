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
    SqlDataReader sdr;
    SqlDataAdapter adapt;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC"; 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            
            GetDepartmentFrom();
            GetStatus();
          
        }
        Display();
        pnlTimeline.Visible = false;
        pnldisplay.Visible = false;

    }

    public void ClearField()
    {
        lblSubject.Text = string.Empty;
        txtdocType.Text = string.Empty;
        //txtDateOut.Text = "";
        //drpDepartmentToID.SelectedIndex = -1;
        drpStatusID.SelectedIndex = -1;

    }
    //public void GetDepartmentFrom()
    //{
    //    conn = new SqlConnection(sqlstr);
    //    conn.Open();
    //    string str = "Select MemoID, MemoBody, MemoUpdateBy, MM_Memo.DateTreated, MM_Memo.DateCreated, CreatedBy=ADM_Users.FullName, RecievedBy=ADM_Users_1.FullName, ADM_Users.StaffID,  " +
    //        "DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID=ADM_Department_1.DepartmentName " +
    //        "From MM_Memo INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
    //        "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID  " +
    //        "INNER JOIN ADM_Users ON MM_Memo.CreatedBy = ADM_Users.StaffID INNER JOIN ADM_Users AS ADM_Users_1  " +
    //        "ON MM_Memo.RecievedBy = ADM_Users_1.StaffID AND MemoID=@ID ";
    //    cmd = new SqlCommand(str, conn);
    //    cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
    //    DataSet ds = new DataSet();
    //    adapt = new SqlDataAdapter(cmd);
    //    adapt.Fill(ds);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        Session["Receiver"] = ds.Tables[0].Rows[0]["RecievedBy"].ToString();
    //        Session["Sender"] = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
    //        Session["MemoBody"] = ds.Tables[0].Rows[0]["MemoBody"].ToString();
    //        Session["Replied"] = ds.Tables[0].Rows[0]["MemoUpdateBy"].ToString();
    //        Session["DateCreated"] = ds.Tables[0].Rows[0]["DateCreated"].ToString();
    //        Session["DateTreated"] = ds.Tables[0].Rows[0]["DateTreated"].ToString();
    //        Session["DeptTo"] = ds.Tables[0].Rows[0]["DepartmentToID"].ToString(); ;

    //    }
    //}
    public void Display()
    {
        try {
            //Check Roles
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string sql = "Select * from ADM_Roles WHERE CreatedBy = @staff";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@staff", Session["StaffId"]);

        if (Session["RoleName"].ToString() == "Administrator")
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= MM_Memo.Status";
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                "DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MM_memo.CreatedBy, " + 
                "RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department ON " + 
                "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " + 
                "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " + 
                "MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                "MM_Memo.Status = ADM_Status.StatusId ORDER BY MemoID ";
            cmd = new SqlCommand(str, conn);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvwallmemo.DataSource = ds.Tables[0];
                gvwallmemo.DataBind();
                
                pnldisplay.Visible = false;
                
                
            }
            else
            {
            }
        }
        else if ((Session["RoleName"].ToString() == "Director") || (Session["RoleName"].ToString() == "Secretary") || (Session["RoleName"].ToString() == "Unit Head"))
        {
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
                "DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MM_memo.CreatedBy, " +
                "Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department ON " +
                "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
                "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " +
                "MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                "MM_Memo.Status = ADM_Status.StatusId WHERE MemoUsrID=@usr ORDER BY MemoID";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@usr", Session["LoginID"]);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvwallmemo.DataSource = ds.Tables[0];
                gvwallmemo.DataBind();
            }
            else
            {
            }
        }

        //gvwallmemo.UseAccessibleHeader = true;
        //gvwallmemo.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        catch (Exception) {
        }
        

    }

    
    protected void gvwallmemo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int ID = int.Parse(e.CommandArgument.ToString());
        Session["MemoID"] = ID;

        lblSubject.Attributes.Add("readonly", "readonly");
        txtdocType.Attributes.Add("readonly", "readonly");
        lblDeptTo.Attributes.Add("readonly", "readonly");
        lblStatus.Attributes.Add("readonly", "readonly");
        psender.Attributes.Add("readonly", "readonly");
        preciever.Attributes.Add("readonly", "readonly");

       
        
        if (e.CommandName == "Edit")
        {
            Pnldisplaygrid.Visible = false;
            pnlTimeline.Visible = true;

            conn = new SqlConnection(sqlstr);
            conn.Open();
            string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, MemoUsrID=ADM_Users.FullName,DepartmentToID=ADM_Department_1.DepartmentName, " +
               "DepartmentfromID=ADM_Department.DepartmentName, Status=ADM_Status.StatusName, MM_Memo.MemoBody, MM_Memo.MemoResponse, " +
               "ADM_DocumentType.DocumentType, CreatedBy=ADM_Users_1.FullName, MM_Memo.DateCreated, MM_Memo.DateTreated " +
              "FROM MM_Memo INNER JOIN ADM_Users ON MM_Memo.MemoUsrID = ADM_Users.UserID INNER JOIN " +
              "ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN " +
              "ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN " +
              "ADM_Status ON MM_Memo.Status = ADM_Status.StatusId INNER JOIN " +
              "ADM_DocumentType ON MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN " +
              "ADM_Users AS ADM_Users_1 ON MM_Memo.CreatedBy = ADM_Users_1.StaffID " +
              "WHERE MemoID = @ID";

            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@ID", ID);
            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                pnlTimeline.Visible = true;
                pnldisplay.Visible = true;
                Pnldisplaygrid.Visible = false;

                lblSubject.Text = ds.Tables[0].Rows[0]["Subject"].ToString();
                txtdocType.Text = ds.Tables[0].Rows[0]["DocumentType"].ToString();
                lblDeptTo.Text = ds.Tables[0].Rows[0]["DepartmentToID"].ToString() + " / " + ds.Tables[0].Rows[0]["MemoUsrID"].ToString();
                lblFrom.Text = ds.Tables[0].Rows[0]["DepartmentfromID"].ToString() + " / " + ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblStatus.Text = ds.Tables[0].Rows[0]["Status"].ToString();
                //txtDateOut.Text = ds.Tables[0].Rows[0]["DateOut"].ToString();

                lblSender.Text = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
                lblDateCreated.Text = ds.Tables[0].Rows[0]["DateCreated"].ToString();
                lblDateTreated.Text = ds.Tables[0].Rows[0]["DateTreated"].ToString();
             
                psender.InnerHtml = ds.Tables[0].Rows[0]["MemoBody"].ToString();
                preciever.InnerHtml = ds.Tables[0].Rows[0]["MemoResponse"].ToString();
                //psender.InnerText = ds.Tables[0].Rows[0]["MemoBody"].ToString();
                //lbldwnpath.Text = ds.Tables[0].Rows[0]["UploadPath"].ToString();
                btnupdate.Visible = true;


               
            }
            else
            {
            } 
            if (preciever.InnerText == string.Empty)
            {
            receiver.Visible = false;
            //sendermemo.Visible = false;
            }
            else { }
        }
        else if (e.CommandName == "Delete")

        {
            //btnconfirmOk_Click(sender, e);

            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
            conn.Open();
            string sql = "DELETE FROM MM_Memo where MemoID = @ID";
            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("ID", ID);
            if (cmd.ExecuteNonQuery() == 1)
            {
                //lblInfo.Text = "Record Deleted Successfully";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Deleted Successfully.')", true);
                Display();
            }
            else
            {
                //lblInfo.Text = "Record not Deleted";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Deleted.')", true);
            }
            conn.Close();
        }
        

    }
    protected void gvwallmemo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    
    //public void searchMemo()
    //{
    //    conn = new SqlConnection(sqlstr);
    //    conn.Open();
    //    string sql = "Select * from ADM_Roles WHERE CreatedBy = @staff";
    //    cmd = new SqlCommand(sql, conn);
    //    cmd.Parameters.AddWithValue("@staff", Session["StaffId"]);

    //    if (Session["RoleName"].ToString() == "Administrator")
    //    {
    //        var filter = txtsearch.Text.Trim();
    //        conn = new SqlConnection(sqlstr);
    //        conn.Open();
    //        //string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MemoDate, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON MM_Memo.Status = ADM_Status.StatusId WHERE Subject LIKE @Subject +'%'  OR (Status LIKE '%' + @status + '%')  ORDER BY MemoID";
    //        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " + 
    //            "DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MemoDate, " + 
    //            "MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department " + 
    //            "ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " + 
    //            "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType  " + 
    //            "ON MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status  " + 
    //            "ON MM_Memo.Status = ADM_Status.StatusId WHERE Subject LIKE '%" + txtsearch.Text.Trim() + "%' " + 
    //            "OR ADM_Status.StatusName LIKE '%" + txtsearch.Text.Trim() + "%' OR  " + 
    //            "ADM_DocumentType.DocumentType LIKE '%" + txtsearch.Text.Trim() + "%' ORDER BY MemoID";
    //        cmd = new SqlCommand(str, conn);
    //        if (filter.Length != 0 || !string.IsNullOrEmpty(txtsearch.Text.Trim()) || filter == string.Empty)
    //        //if (filter.Length != 0 || filter == string.Empty)
    //        {
    //            cmd.Parameters.AddWithValue("@Subject", txtsearch.Text.Trim());
    //            cmd.Parameters.AddWithValue("@status", txtsearch.Text.Trim());
    //            cmd.Parameters.AddWithValue("@docType", txtsearch.Text.Trim());
    //            //cmd.Parameters.AddWithValue("@subject", string.Format("%{0}%", filter));
    //            //cmd.Parameters.AddWithValue("@doctype", string.Format("%{0}%", filter));
    //            //cmd.Parameters.AddWithValue("@status", string.Format("%{0}%", filter));
    //            DataSet ds = new DataSet();
    //            adapt = new SqlDataAdapter(cmd);
    //            DataTable dt = new DataTable();
    //            adapt.Fill(dt);
    //            if (dt.Rows.Count > 0)
    //            {
    //                gvwallmemo.DataSource = dt;
    //                gvwallmemo.DataBind();
    //            }
    //        }

    //    }
    //    else if ((Session["RoleName"].ToString() == "Secretary") || (Session["RoleName"].ToString() == "Director"))
    //    {
    //        conn = new SqlConnection(sqlstr);
    //        conn.Open();
    //        //string str = "SELECT MemoID, Subject, DepartmentfromID, DepartmentToID=ADM_Department.DepartmentName, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo inner join ADM_DocumentType on DocumentTypeID = MM_Memo.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = MM_Memo.DepartmentToID INNER JOIN ADM_Status ON ADM_Status.StatusId= MM_Memo.Status WHERE MemoUsrid=@user AND Subject LIKE @Subject + '%' ";
    //        string str = "SELECT MM_Memo.MemoID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName, " +
    //            "DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MemoDate, " +
    //            "MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department " +
    //            "ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
    //            "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType  " +
    //            "ON MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status  " +
    //            "ON MM_Memo.Status = ADM_Status.StatusId " +
    //            "WHERE MemoUsrid=@user AND (Subject LIKE '%" + txtsearch.Text.Trim() + "%' " +
    //            "OR ADM_Status.StatusName LIKE '%" + txtsearch.Text.Trim() + "%' OR  " +
    //            "ADM_DocumentType.DocumentType LIKE '%" + txtsearch.Text.Trim() + "%') ORDER BY MemoID";
    //        cmd = new SqlCommand(str, conn);
    //        if (!string.IsNullOrEmpty(txtsearch.Text.Trim()) || txtsearch.Text == string.Empty)
    //        {
    //            //cmd.Parameters.AddWithValue("@Subject", txtsearch.Text.Trim());
    //            cmd.Parameters.AddWithValue("@user", Session["LoginID"]);
    //            DataSet ds = new DataSet();
    //            adapt = new SqlDataAdapter(cmd);
    //            DataTable dt = new DataTable();
    //            adapt.Fill(dt);
    //            //gvwallmemo.DataSource = dt;
    //            //gvwallmemo.DataBind();
    //            if (dt.Rows.Count > 0)
    //            {
    //                gvwallmemo.DataSource = dt;
    //                gvwallmemo.DataBind();
    //            }

    //        }
    //        else {
    //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No Record Found.')", true);
    //        }

    //    }
    //}

    //protected void btnsearch_Click(object sender, EventArgs e)
    //{
    //    searchMemo();
    //}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //pnlTimeline.Visible = true;
        //pnldisplay.Visible = true;
    }

    public void GetDepartmentFrom()
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "Select MemoID, CreatedBy=ADM_Users.FullName,UploadPath, RecievedBy=ADM_Users_1.FullName, ADM_Users.StaffID,  " + 
            "DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID=ADM_Department_1.DepartmentName " + 
            "From MM_Memo INNER JOIN ADM_Department ON MM_Memo.DepartmentfromID = ADM_Department.DepartmentID " +
            "INNER JOIN ADM_Department AS ADM_Department_1 ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID  " +
            "INNER JOIN ADM_Users ON MM_Memo.CreatedBy = ADM_Users.StaffID INNER JOIN ADM_Users AS ADM_Users_1  " +
            "ON MM_Memo.RecievedBy = ADM_Users_1.StaffID ";
        cmd = new SqlCommand(str, conn);
        //cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        DataSet ds = new DataSet();
        adapt = new SqlDataAdapter(cmd);
        adapt.Fill(ds);
        if (ds.Tables[0].Rows.Count > 0)
        { 
            
            lblreciever.Text = ds.Tables[0].Rows[0]["RecievedBy"].ToString();

            Session["Receiver"] = ds.Tables[0].Rows[0]["RecievedBy"].ToString();
            Session["Sender"] = ds.Tables[0].Rows[0]["CreatedBy"].ToString();
            Session["DeptTo"] = ds.Tables[0].Rows[0]["DepartmentToID"].ToString();
            Session["updpath"] = ds.Tables[0].Rows[0]["UploadPath"].ToString();

            //lblreciever.Text = Session["Reciever"].ToString();
            //lblSender.Text = Session["Sender"].ToString();
           
            //Session["StaffName"] = ds.Tables[0].Rows[0]["FullName"].ToString();

        }
    }

   
    public void GetStatus()
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        cn.Open();
        //string sql = "Select * from ADM_Department inner join ADM_Users on ADM_Users.DepartmentId = ADM_Department.DepartmentID WHERE UserId=@Usr";
        string sql = "Select * from ADM_Status";
        SqlCommand cmd = new SqlCommand(sql, cn);
        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);

        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpStatusID.Items.Clear();
        drpStatusID.AppendDataBoundItems = true;
        drpStatusID.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpStatusID.DataSource = ds.Tables[0];
            drpStatusID.DataTextField = "StatusName";
            drpStatusID.DataValueField = "StatusID";
            drpStatusID.DataBind();

            drpStatusID.SelectedIndex = 0;
        }
        else
        {

        }
    }
    protected void gvwallmemo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void btnconfirmOk_Click(object sender, EventArgs e)
    {
        //conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        //conn.Open();
        //string sql = "DELETE FROM MM_Memo where MemoID=@ID";
        //cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        //if (cmd.ExecuteNonQuery() == 1)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Deleted Successfully.')", true);
        //    Display();
        //}
        //else
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Deleted.')", true);
        //}
        //conn.Close();


    }
    protected void btnSendUpdate_Click(object sender, EventArgs e)
    { 
        //if (fileUploadImage.HasFile)
        //{
        //    string constring = fileUploadImage.FileName;
        //    fileUploadImage.SaveAs(Server.MapPath("../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName)));
        //    txtfileName.Text = "../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName);
        //    label1.Visible = true;
        //    label1.Text = "File name: " + fileUploadImage.PostedFile.FileName + "<br>" + "File Size: " + fileUploadImage.PostedFile.ContentLength + " kb<br>" + "Content type: " + fileUploadImage.PostedFile.ContentType;
        //}
        //else
        //{
        //    label1.Visible = true;
        //    label1.Text = "You have not specified a file.";
        //}

        //conn = new SqlConnection(sqlstr);
        //conn.Open();
        ////string sql = "UPDATE MM_Memo set Subject = @sub, DepartmentfromId = @deptfrom, DepartmentToId = @deptTo, DateIn = @indate, MemoDate = @memoDate, RecievedBy=@reciever, Status=@status where MemoID = @ID";
        //string sql = "Update MM_Memo Set DateOut=@outdate,UploadPath=@file, MemoResponse=@upd, RecievedBy=@reciever, Status=@status Where MemoID = @ID";
        //cmd = new SqlCommand(sql, conn);

        //cmd.Parameters.AddWithValue("@outdate", txtDateOut.Text);
        //cmd.Parameters.AddWithValue("@file", txtfileName.Text);
        //cmd.Parameters.AddWithValue("@upd", message.Value.Trim());
        //cmd.Parameters.AddWithValue("@reciever", Session["StaffID"]);
        //cmd.Parameters.AddWithValue("@status", drpStatusID.SelectedItem.Value);
        //cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        //        if (cmd.ExecuteNonQuery() == 1)
        //        {
        //            //lblInfo.Text = "Record Updated Successfully";
           //         ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        //            Display();
        //            ClearField();
        //        }
        //        else
        //        {
        //            //lblInfo.Text = "Record not Updated";
        //            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        //        }
        //        conn.Close();
    }

    protected void Save_Click(object sender, EventArgs e)
    {
        lblInfo.Text = txtmessage.Value.Trim();
        Pnldisplaygrid.Visible = false;
        pnlTimeline.Visible = true;
        pnldisplay.Visible = true;
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        ////string message = "Record updated successfully.";
        ////string script = "window.onload = function(){alert('"; script += message; script+= "')}";
        ////ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessge", script, true);
        //if (fileUploadImage.HasFile)
        //{
        //    string constring = fileUploadImage.FileName;
        //    fileUploadImage.SaveAs(Server.MapPath("../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName)));
        //    txtfileName.Text = "../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName);
        //    label1.Visible = true;
        //    label1.Text = "File name: " + fileUploadImage.PostedFile.FileName + "<br>" + "File Size: " + fileUploadImage.PostedFile.ContentLength + " kb<br>" + "Content type: " + fileUploadImage.PostedFile.ContentType;
        //}
        //else
        //{
        //    label1.Visible = true;
        //    label1.Text = "You have not specified a file.";
        //}

        //conn = new SqlConnection(sqlstr);
        //conn.Open();
        //string sql = "Update MM_Memo Set MemoResponse=@upd, UploadPath=@file,RecievedBy=@reciever, Status=@status Where MemoID = @ID";
        //cmd = new SqlCommand(sql, conn);

        ////cmd.Parameters.AddWithValue("@outdate", txtDateOut.Text);
        ////cmd.Parameters.AddWithValue("@upd", message.Value.Trim());
        //cmd.Parameters.AddWithValue("@upd", txtmessage.InnerText);
        //cmd.Parameters.AddWithValue("@file", txtfileName.Text);
        //cmd.Parameters.AddWithValue("@reciever", Session["StaffID"]);
        //cmd.Parameters.AddWithValue("@status", drpStatusID.SelectedItem.Value);
        //cmd.Parameters.AddWithValue("@ID", Session["MemoID"]);
        //if (cmd.ExecuteNonQuery() == 1)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Updated Successfully.')", true);
        //    Display();
        //    ClearField();
        //}
        //else
        //{
        //    //lblInfo.Text = "Record not Updated";
        //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Updated.')", true);
        //}
        //conn.Close();

    }

    //public void DownloadFile() {
    //    try
    //    {
    //        string strUrl = dwnfile.InnerText;
    //        string filePath =  AppDomain.CurrentDomain.BaseDirectory +" /App_Data/Uploads/"+ strUrl;
    //        WebClient req = new WebClient();
    //        HttpResponse resp = HttpContext.Current.Response;
    //        resp.Clear();
    //        resp.ClearContent();
    //        resp.ClearHeaders();
    //        resp.Buffer = true;
    //        resp.AddHeader("Content- Disposition", "attachment;filename=\"" +  Server.MapPath(strUrl) + "\" ");
    //        byte[] data = req.DownloadData(Server.MapPath(strUrl));
    //        resp.BinaryWrite(data);
    //        resp.TransmitFile(filePath);
    //        resp.Flush();
    //        resp.End();

    //    }
    //    catch (Exception ex) 
    //    {
    //    }
    //}
    protected void lbldwnpath_Click(object sender, EventArgs e)
    {
    //    try
    //    {
    //        if (dwnpath.Text != null)
    //        {
    //            dwnpath.Text = Session["updpath"].ToString();
    //            string strUrl = dwnpath.Text;
    //            string filePath = AppDomain.CurrentDomain.BaseDirectory + " /App_Data/Uploads/" + dwnpath.Text;
    //            WebClient req = new WebClient();
    //            HttpResponse resp = HttpContext.Current.Response;
    //            resp.Clear();
    //            resp.ClearContent();
    //            resp.ClearHeaders();
    //            resp.Buffer = true;
    //            resp.Charset = "";
    //            resp.Cache.SetCacheability(HttpCacheability.NoCache);
    //            resp.AddHeader("Content- Disposition", "attachment;filename=\"" + Server.MapPath(dwnpath.Text) + "\" ");
    //            byte[] data = req.DownloadData(Server.MapPath(strUrl));
    //            resp.BinaryWrite(data);
    //            //resp.TransmitFile(filePath);
    //            //resp.Flush();
    //            resp.End();
    //        }
    //        else
    //        {


    //            dwnpath.Visible = false;
    //        }



        //}
        //catch (Exception ex)
        //{
        //}

        

    }
}