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
            Display();
        }
        
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
                //string str = "SELECT MemoID, Subject, DepartmentfromID=ADM_Department.DepartmentName, DepartmentToID, DocumentType=ADM_DocumentType.DocumentType, DateIn,MemoDate, MemoUpdateTo, RecievedBy, Status=ADM_Status.StatusName FROM ADM_FILE inner join ADM_DocumentType on DocumentTypeID = ADM_FILE.DocumentType inner join ADM_Department on ADM_Department.DepartmentID = ADM_FILE.DepartmentfromID INNER JOIN ADM_Status ON ADM_Status.StatusId= ADM_FILE.Status";
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
}