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
    DataSet ds;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            GetDepartment();
            lnksameoffice_Click(sender, e);
            //lnkbtnanotheroffice_Click(sender, e);
            GetPriority();

            //lnkbtnvshelf_Click(sender, e);
            
            
            //Display();
        }
        
       
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        Master.GetSameOffice.Click += new EventHandler(lnksameoffice_Click);
        Master.GetToAnotherOffice.Click += new EventHandler(lnkbtnanotheroffice_Click);
        //Master.GetVirtualShelf.Click += new EventHandler(lnkbtnvshelf_Click);
        
    }

    public void ClearField()
    {
        txtDispatcherName.Text = "";
        txtsubject.Text = "";
        txtdescription.Value = string.Empty;
        txtfileName.Text = "";
        txtfileno.Text = "";
        txtremark.Text = "";
        txtUpdfileName.Text = "";
        drpDept.SelectedIndex = -1;
        drpReceiver.SelectedIndex = -1;
        drpPriority.SelectedIndex = -1;

    }

    protected void lnksameoffice_Click(object sender, EventArgs e)
    {

        GetDepartment();
        lbldispatchType.Visible = true;
        lbldispatchType.Text = "Within Same Office/Department";
        lbldispatchType.ForeColor = System.Drawing.Color.Red;
        pnlCreatefile.Visible = true;
        pnlVirtualshelf.Visible = false;
    }
    protected void lnkbtnanotheroffice_Click(object sender, EventArgs e) {
        lbldispatchType.Visible = true;
        lbldispatchType.Text = "To Another Office/Department";
        //lbldispatchType.ForeColor = System.Drawing.Color.Red;

        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "select * from ADM_Department";
        cmd = new SqlCommand(str, conn);
        adapt = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adapt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select Department--";
        li.Value = "0";


        drpDept.Items.Clear();
        drpDept.AppendDataBoundItems = true;
        drpDept.Items.Add(li);
        if (ds.Tables[0].Rows.Count > 0)
        {
            drpDept.DataSource = ds;
            drpDept.DataTextField = "DepartmentName";
            drpDept.DataValueField = "DepartmentID";
            drpDept.DataBind();

            drpDept.SelectedIndex = 0;
        }
        else { }
        pnlCreatefile.Visible = true;
        pnlVirtualshelf.Visible = false;
    }
    //protected void lnkbtnvshelf_Click(object sender, EventArgs e)
    //{
        
    //    //Display();
    //    try
    //    {
    //        //Check Roles

    //        if (Session["RoleName"].ToString() == "Administrator")
    //        {
    //            conn = new SqlConnection(sqlstr);
    //            conn.Open();
    //            //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM ADM_FILE inner join ADM_DocumentType on DocumentTypeID = ADM_FILE.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = ADM_FILE.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= ADM_FILE.Status";
    //            string str = "SELECT FILEID, FILENO, FILENAME,FileSubject, FileDescription, DepartmentfromID=ADM_Department.DepartmentName , " +
    //                "filepriority = ADM_PRIORITY.PriorityName, SENDER,CREATEDBY = ADM_Users.FullName,RECEIVER = ADM_Users_1.FullName, ADM_FILE.DATECREATED, UploadPath " +
    //                "FROM ADM_FILE " +
    //                "INNER JOIN ADM_PRIORITY ON ADM_FILE.filePriority = ADM_PRIORITY.PriorityID " +
    //                "INNER JOIN ADM_Department ON ADM_FILE.DepartmentfromID = ADM_Department.DepartmentID " +
    //                "INNER JOIN ADM_Users ON ADM_FILE.CREATEDBY = ADM_Users.StaffID " +
    //                "INNER JOIN ADM_Users AS ADM_Users_1 ON ADM_FILE.RECEIVER = ADM_Users_1.UserID";
    //            cmd = new SqlCommand(str, conn);
    //            DataSet ds = new DataSet();
    //            adapt = new SqlDataAdapter(cmd);
    //            adapt.Fill(ds);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                gvvirtual.DataSource = ds.Tables[0];
    //                gvvirtual.DataBind();



    //            }
    //            else
    //            {
    //            }
    //            //lblcreatedby.Visible = true;
    //            conn.Close();
    //        }
    //        else if (Session["RoleName"].ToString() == "Secretary")
    //        {
    //            conn = new SqlConnection(sqlstr);
    //            conn.Open();
    //            string str = "SELECT FILEID, FILENO, FILENAME,FileSubject, FileDescription, DepartmentfromID=ADM_Department.DepartmentName , " +
    //                "filepriority = ADM_PRIORITY.PriorityName, SENDER,CREATEDBY = ADM_Users.FullName,RECEIVER = ADM_Users_1.FullName, ADM_FILE.DATECREATED, UploadPath " +
    //                "FROM ADM_FILE " +
    //                "INNER JOIN ADM_PRIORITY ON ADM_FILE.filePriority = ADM_PRIORITY.PriorityID " +
    //                "INNER JOIN ADM_Department ON ADM_FILE.DepartmentfromID = ADM_Department.DepartmentID " +
    //                "INNER JOIN ADM_Users ON ADM_FILE.CREATEDBY = ADM_Users.StaffID " +
    //                "INNER JOIN ADM_Users AS ADM_Users_1 ON ADM_FILE.RECEIVER = ADM_Users_1.UserID WHERE ADM_FILE.CREATEDBY=@usr ";
    //            cmd = new SqlCommand(str, conn);
    //            cmd.Parameters.AddWithValue("@usr", Session["StaffID"]);
    //            DataSet ds = new DataSet();
    //            adapt = new SqlDataAdapter(cmd);
    //            adapt.Fill(ds);
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                gvvirtual.DataSource = ds.Tables[0];
    //                gvvirtual.DataBind();
    //            }
    //            else
    //            {
    //            }
    //            conn.Close();
    //        }
    //    }
    //    catch (Exception)
    //    {
    //    }

    //    pnlVirtualshelf.Visible = true;
    //    pnlCreatefile.Visible = false;
        
    //}
   
    protected void drpDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "select * from ADM_Users inner join ADM_Department on ADM_Department.DepartmentID = ADM_Users.DepartmentID where ADM_Department.DepartmentID =" + drpDept.SelectedValue;
        cmd = new SqlCommand(str, conn);
        adapt = new SqlDataAdapter(cmd);

        ds = new DataSet();
        adapt.Fill(ds);

        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Sender--";
        li.Value = "0";


        drpReceiver.Items.Clear();
        drpReceiver.AppendDataBoundItems = true;
        drpReceiver.Items.Add(li);

        //if (ds.Tables[0].Rows.Count > 0)
        //{}
        drpReceiver.DataSource = ds;
        drpReceiver.DataTextField = "FullName";
        drpReceiver.DataValueField = "UserID";
        drpReceiver.DataBind();

        drpReceiver.SelectedIndex = 0;


        drpReceiver.SelectedItem.Value = ds.Tables[0].Rows[0]["UserID"].ToString();

    }

    public void Display()
    {
        try
        {
            //Check Roles

            if (Session["RoleName"].ToString() == "Administrator")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT FILEID, FILENO, FILENAME,FileSubject, FileDescription, DepartmentfromID=ADM_Department.DepartmentName , " +
                    "filepriority = ADM_PRIORITY.PriorityName, SENDER,CREATEDBY = ADM_Users.FullName,RECEIVER = ADM_Users_1.FullName, ADM_FILE.DATECREATED, UploadPath " +
                    "FROM ADM_FILE " +
                    "INNER JOIN ADM_PRIORITY ON ADM_FILE.filePriority = ADM_PRIORITY.PriorityID " +
                    "INNER JOIN ADM_Department ON ADM_FILE.DepartmentfromID = ADM_Department.DepartmentID " +
                    "INNER JOIN ADM_Users ON ADM_FILE.CREATEDBY = ADM_Users.StaffID " +
                    "INNER JOIN ADM_Users AS ADM_Users_1 ON ADM_FILE.RECEIVER = ADM_Users_1.UserID";
                cmd = new SqlCommand(str, conn);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvvirtual.DataSource = ds.Tables[0];
                    gvvirtual.DataBind();



                }
                else
                {
                }
                //lblcreatedby.Visible = true;
                conn.Close();
            }
            else if (Session["RoleName"].ToString() == "Secretary")
            {
                conn = new SqlConnection(sqlstr);
                conn.Open();
                string str = "SELECT FILEID, FILENO, FILENAME,FileSubject, FileDescription, DepartmentfromID=ADM_Department.DepartmentName , " +
                    "filepriority = ADM_PRIORITY.PriorityName, SENDER,CREATEDBY = ADM_Users.FullName,RECEIVER = ADM_Users_1.FullName, ADM_FILE.DATECREATED, UploadPath " +
                    "FROM ADM_FILE " +
                    "INNER JOIN ADM_PRIORITY ON ADM_FILE.filePriority = ADM_PRIORITY.PriorityID " +
                    "INNER JOIN ADM_Department ON ADM_FILE.DepartmentfromID = ADM_Department.DepartmentID " +
                    "INNER JOIN ADM_Users ON ADM_FILE.CREATEDBY = ADM_Users.StaffID " +
                    "INNER JOIN ADM_Users AS ADM_Users_1 ON ADM_FILE.RECEIVER = ADM_Users_1.UserID WHERE ADM_FILE.CREATEDBY=@usr ";
                cmd = new SqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@usr", Session["StaffID"]);
                DataSet ds = new DataSet();
                adapt = new SqlDataAdapter(cmd);
                adapt.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvvirtual.DataSource = ds.Tables[0];
                    gvvirtual.DataBind();
                }
                else
                {
                }
                conn.Close();
            }
        }
        catch (Exception)
        {
        }


    }

    public void GetPriority()
    {
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

    public void GetDepartment()
    {

        if ((Session["RoleName"].ToString() == "Secretary") ||(Session["RoleName"].ToString() == "Administrator"))
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            //string str = "select * from ADM_Users WHERE ADM_Users.UserID=@usr";
            string str = "select * from ADM_Users inner join ADM_Department on ADM_Department.DepartmentID = ADM_Users.DepartmentID where ADM_Users.UserID=@usr";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@usr", Session["LoginID"]);
            adapt = new SqlDataAdapter(cmd);
            ds = new DataSet();

            adapt.Fill(ds);

            ListItem li = default(ListItem);
            li = new ListItem();
            li.Text = "--Select Department--";
            li.Value = "0";

            //drpReceiver.Items.Clear();
            //drpReceiver.AppendDataBoundItems = true;
            //drpReceiver.Items.Add(li);


            drpDept.Items.Clear();
            drpDept.AppendDataBoundItems = true;
            drpDept.Items.Add(li);

            if (ds.Tables[0].Rows.Count > 0)
            {
                drpDept.DataSource = ds;
                drpDept.DataTextField = "DepartmentName";
                drpDept.DataValueField = "DepartmentID";
                drpDept.DataBind();

                drpDept.SelectedIndex = 0;
                //drpReceiver.SelectedIndex = 0;
            }
            else
            {
            }
        }
    }

   
    protected void btnsubmit_ServerClick(object sender, EventArgs e)
    {
        if (fileUploadImage.HasFile)
        {
            string constring = fileUploadImage.FileName;
            fileUploadImage.SaveAs(Server.MapPath("../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName)));
            txtUpdfileName.Text = "../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName);
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
        string sql = "INSERT INTO ADM_FILE(FileNo,FileName,FileSubject,FileDescription, Remarks, DepartmentfromID, Receiver, FilePriority, UploadPath, Sender, CreatedBy ) " +
            "VALUES (@fileno,@filename,@subject,@descrip,@remark,@dptfromID,@receiver,@priority,@updpath,@sender,@createdby)";
        cmd = new SqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@dptfromID", drpDept.SelectedValue);
        cmd.Parameters.AddWithValue("@receiver", drpReceiver.SelectedValue);
        cmd.Parameters.AddWithValue("@priority", drpPriority.SelectedValue);
        cmd.Parameters.AddWithValue("@fileno", txtfileno.Text);
        cmd.Parameters.AddWithValue("@filename", txtfileName.Text);
        cmd.Parameters.AddWithValue("@subject", txtsubject.Text);
        cmd.Parameters.AddWithValue("@descrip", txtdescription.Value.Trim());
        cmd.Parameters.AddWithValue("@sender", txtDispatcherName.Text);
        cmd.Parameters.AddWithValue("@remark", txtremark.Text);

        cmd.Parameters.AddWithValue("@updpath", txtUpdfileName.Text);
        cmd.Parameters.AddWithValue("@createdby", Session["StaffID"]);



        if (cmd.ExecuteNonQuery() == 1)
        {

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Saved Successfully.')", true);
            ClearField();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Saved.')", true);
        }
        conn.Close();

    }
}  
