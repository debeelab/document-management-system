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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDepartmentTo();
            GetDocumentType();
           
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {

         if (fileUploadImage.HasFile)
            {
                string constring = fileUploadImage.FileName;
                fileUploadImage.SaveAs(Server.MapPath("../Uploads/"  + constring + System.IO.Path.GetExtension(fileUploadImage.FileName)));
                txtfileName.Text = "../Uploads/" + constring + System.IO.Path.GetExtension(fileUploadImage.FileName);
                label1.Visible = true;
                label1.Text = "File name: " + fileUploadImage.PostedFile.FileName + "<br>" + "File Size: " + fileUploadImage.PostedFile.ContentLength + " kb<br>" + "Content type: " + fileUploadImage.PostedFile.ContentType;
            }
            else
            {
                label1.Visible = true;
                label1.Text = "You have not specified a file.";
            }


         conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
         conn.Open();
         string sql = "INSERT INTO MM_Memo(Subject,DepartmentfromID,DepartmentToID,DateIn,MemoDate,DocumentType,UploadPath,CreatedBy,Usr_StaffID) VALUES (@Subject,@DepartmentfromID,@DepartmentToID,@DateIn,@MemoDate,@DocumentType,@UploadPath,@CreatedBy,@role)";
         cmd = new SqlCommand(sql, conn);
         cmd.Parameters.AddWithValue("@Subject", txtSubject.Text);
         cmd.Parameters.AddWithValue("@DepartmentfromID", Session["DepartmentID"]);
         cmd.Parameters.AddWithValue("@DepartmentToID", drpDepartmentToID.SelectedValue);
         cmd.Parameters.AddWithValue("@DateIn", txtDateIn.Text);
         cmd.Parameters.AddWithValue("@MemoDate", txtMemoDate.Text);
         cmd.Parameters.AddWithValue("@DocumentType", drpDocumentType.SelectedValue);
         cmd.Parameters.AddWithValue("@UploadPath", txtfileName.Text);
         cmd.Parameters.AddWithValue("@CreatedBy", Session["StaffID"]);
         cmd.Parameters.AddWithValue("@role", Session["Role"]);
         if (cmd.ExecuteNonQuery() == 1)
         {
             lblInfo.Text = "Record Saved Successfully";
             if (Session["RoleName"].ToString() == "Director")
             {
                 Response.Redirect("../Homepage/DirectorHome.aspx", true);
             }
             else if (Session["RoleName"].ToString() == "Secretary") {
                 Response.Redirect("../Homepage/SecretaryHome.aspx", true);

             }

         }
         else
         {
             lblInfo.Text = "Record not Saved";
         }
         conn.Close();
    }

    public void GetDepartmentTo()
    {
        
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        cn.Open();
        string sql = "Select * from ADM_Department";
        SqlCommand cmd = new SqlCommand(sql, cn);

       
        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);

        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpDepartmentToID.Items.Clear();
        drpDepartmentToID.AppendDataBoundItems = true;
        drpDepartmentToID.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpDepartmentToID.DataSource = ds.Tables[0];
            drpDepartmentToID.DataTextField = "DepartmentName";
            drpDepartmentToID.DataValueField = "DepartmentID";
            drpDepartmentToID.DataBind();

            drpDepartmentToID.SelectedIndex = 0;
        }
        else
        {
           
        }
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

}