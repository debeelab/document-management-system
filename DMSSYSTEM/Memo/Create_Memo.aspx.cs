using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;



public partial class Masterpages_Default : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    DataSet ds;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDepartmentTo();
            GetDocumentType();
            GetPriority();

        }
        
    }

    public void ClearField()
    {
        txtSubject.Text = string.Empty;
        txtfileName.Text = "";
        txtmemobody.Value = "";
        drpPriority.SelectedIndex = -1;
        drpDepartmentToID.SelectedIndex = -1;
        drpDocumentType.SelectedIndex = -1;
        drpMemoTo.SelectedIndex = -1;
       
    }

    public void GetDocumentType()
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        cn.Open();
        string sql = "Select * from ADM_DocumentType";
        SqlCommand cmd = new SqlCommand(sql, cn);


        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);
        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpDocumentType.Items.Clear();
        drpDocumentType.AppendDataBoundItems = true;
        drpDocumentType.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpDocumentType.DataSource = ds.Tables[0];
            drpDocumentType.DataTextField = "DocumentType";
            drpDocumentType.DataValueField = "DocumentTypeID";
            drpDocumentType.DataBind();

            drpDocumentType.SelectedIndex = 0;
        }
        else
        {

        }
    }

    public void GetPriority() {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        cn.Open();
        string sql = "Select * from ADM_Priority";
        SqlCommand cmd = new SqlCommand(sql, cn);


        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);
        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpPriority.Items.Clear();
        drpPriority.AppendDataBoundItems = true;
        drpPriority.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpPriority.DataSource = ds.Tables[0];
            drpPriority.DataTextField = "PriorityName";
            drpPriority.DataValueField = "PriorityID";
            drpPriority.DataBind();

            drpPriority.SelectedIndex = 0;
        }
        else
        {

        }
    }
    
    public void GetDepartmentTo()
    {
        //Check Roles
        //if ((Session["RoleName"].ToString() == "Administrator") || (Session["RoleName"].ToString() == "Director"))
        //{}
            
            conn = new SqlConnection(sqlstr);
            conn.Open();
            string str = "select * from ADM_Department";    
            cmd = new SqlCommand(str, conn);
            adapt = new SqlDataAdapter(cmd);
            ds = new DataSet();
            adapt.Fill(ds);
            ListItem li = default(ListItem);
            li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";

            drpDepartmentToID.Items.Clear();
            drpDepartmentToID.AppendDataBoundItems = true;
            drpDepartmentToID.Items.Add(li);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpDepartmentToID.DataSource = ds;
                drpDepartmentToID.DataTextField = "DepartmentName";
                drpDepartmentToID.DataValueField = "DepartmentID";
                drpDepartmentToID.DataBind();

                drpDepartmentToID.SelectedIndex = 0;
            }
            else
            {
            }
        
        //else if ((Session["RoleName"].ToString() == "Secretary") || (Session["RoleName"].ToString() == "Unit Head"))
        //{
        //    drpDepartmentToID.Items.Clear();
        //    drpDepartmentToID.Items.Add("--Select--");
        //    conn = new SqlConnection(sqlstr);
        //    conn.Open();
        //    string str = "select * from ADM_Users inner join ADM_Department on ADM_Department.DepartmentID = ADM_Users.DepartmentID where ADM_Users.UserID=@usr";
        //    cmd = new SqlCommand(str, conn);
        //    cmd.Parameters.AddWithValue("@usr", Session["LoginID"]);
        //    adapt = new SqlDataAdapter(cmd);
        //    ds = new DataSet();

        //    adapt.Fill(ds);

        //    ListItem li = default(ListItem);
        //    li = new ListItem();
        //    li.Text = "--Select--";
        //    li.Value = "0";

        //    drpDepartmentToID.Items.Clear();
        //    drpDepartmentToID.AppendDataBoundItems = true;
        //    drpDepartmentToID.Items.Add(li);

        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        drpDepartmentToID.DataSource = ds;
        //        drpDepartmentToID.DataTextField = "DepartmentName";
        //        drpDepartmentToID.DataValueField = "DepartmentID";
        //        drpDepartmentToID.DataBind();

        //        drpDepartmentToID.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //    }
        //}
    }
    
    protected void drpDepartmentToID_SelectedIndexChanged(object sender, EventArgs e)
    {
        //drpMemoTo.Items.Clear();
        //drpMemoTo.Items.Add("--Select--");
        
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Value = "0";
        li.Text = "--Select --";
      
        drpMemoTo.Items.Clear();
        drpMemoTo.AppendDataBoundItems = true;
        drpMemoTo.Items.Add(li);

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "SELECT * from ADM_Users " + 
        "inner join ADM_Department on ADM_Department.DepartmentID = ADM_Users.DepartmentID " + 
        "where ADM_Department.DepartmentID =" + drpDepartmentToID.SelectedValue;
        cmd = new SqlCommand(str, conn);
        adapt = new SqlDataAdapter(cmd);
        
        ds = new DataSet();
        adapt.Fill(ds);

        if ((drpMemoTo.SelectedIndex != -1) && (ds.Tables[0].Rows.Count > 0))
        {
            drpMemoTo.DataSource = ds;
            drpMemoTo.DataTextField = "FullName";
            drpMemoTo.DataValueField = "UserID";
            drpMemoTo.DataBind();

            drpMemoTo.SelectedIndex = 0;
            drpMemoTo.SelectedItem.Value = ds.Tables[0].Rows[0]["UserID"].ToString();
           // Session["receiver"] = drpMemoTo.SelectedItem.Value ;
        }
           
    }
    
    protected void Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (fileUploadImage.HasFile)
            {

                //string constring = Path.GetFileName (fileUploadImage.PostedFile.FileName);
                //fileUploadImage.SaveAs(Server.MapPath("../Uploads/" + constring));
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
            //string str = "INSERT INTO MM_Memo(Subject,MemoBody,DepartmentfromID,DepartmentToID,MemoUsrID, " +
            //             "UploadPath, StatusID, DocumentTypeID, PriorityID, CreatedBy, DateCreated) " +
            //             "VALUES (@subj,@memobody,@deptfrom,@DdeptTo,@memousrid, @updfile,2, @docType,@memopriority,@sentby, @sentdate)";

            //cmd = new SqlCommand(str, conn);


            cmd = new SqlCommand("[dbo].[InsertNewMemo]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@subj", txtSubject.Text);
            cmd.Parameters.AddWithValue("@memobody", txtmemobody.Value.Trim());
            cmd.Parameters.AddWithValue("@deptfrom", Session["DepartmentID"]);
            cmd.Parameters.AddWithValue("@deptTo", drpDepartmentToID.SelectedValue);
            cmd.Parameters.AddWithValue("@memousrid", drpMemoTo.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@updfile", txtfileName.Text);
            cmd.Parameters.AddWithValue("@memostatus", 2);
            cmd.Parameters.AddWithValue("@docType", drpDocumentType.SelectedValue);
            cmd.Parameters.AddWithValue("@memopriority", drpPriority.SelectedValue);
            cmd.Parameters.AddWithValue("@sentby", Session["StaffID"]);
            cmd.Parameters.AddWithValue("@sentdate", DateTime.Now);

            conn.Open();
           //cmd.ExecuteNonQuery();
            int i = cmd.ExecuteNonQuery();

            if (i != 0)
            {
                //Display success message.  
            string message = "Your details have been saved successfully.";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "')};";
            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                ClearField();

            }
            else
            {
                //Failure success message.
                string message = "Record not saved.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "Failed", script, true);
                ClearField();
            }
            conn.Close();
 
        }
        catch (SqlException ex) 
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Cannot Insert record into the database.') "+ ex, true);
               
        }
    }

}
