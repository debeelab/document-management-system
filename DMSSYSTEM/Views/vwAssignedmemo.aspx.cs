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

    protected void Page_Load(object sender, EventArgs e)
    {
        Display();


    }
    public void Display() {
        conn = new SqlConnection(sqlstr);
        conn.Open();
        string str = "SELECT MM_Memo.MemoID, PriorityID, MM_Memo.Subject, DepartmentfromID=ADM_Department.DepartmentName," +
                    "DepartmentToID=ADM_Department_1.DepartmentName, ADM_DocumentType.DocumentType,DateIn,MM_memo.CreatedBy, UploadPath, " + 
                    "Status=ADM_Status.StatusName FROM MM_Memo INNER JOIN ADM_Department ON " +
                    "MM_Memo.DepartmentfromID = ADM_Department.DepartmentID INNER JOIN ADM_Department AS ADM_Department_1 " +
                    "ON MM_Memo.DepartmentToID = ADM_Department_1.DepartmentID INNER JOIN ADM_DocumentType ON  " +
                    "MM_Memo.DocumentType = ADM_DocumentType.DocumentTypeID INNER JOIN ADM_Status ON  " +
                    "MM_Memo.Status = ADM_Status.StatusId WHERE MemoUsrId=@usr ORDER BY MemoID";
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
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No record found.')", true);
        }
    }
    protected void gvassignedmemo_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void btndownload_Click(object sender, EventArgs e)
    {
        try {
        //    //var element = (LinkButton)sender;
        //    int ID = int.Parse((sender as LinkButton).CommandArgument);
        ////byte[] bytes;
        //    string filename, contType;
        //    conn = new SqlConnection(sqlstr);
        //    conn.Open();
        //    //string str = "SELECT UploadPath FROM MM_Memo WHERE ID=@id ORDER BY MemoID";'
        //    string str = "SELECT uploadid, FileUpload.UploadName, FileUpload.UploadPath, MM_Memo.MemoID FROM FileUpload INNER JOIN MM_Memo ON FileUpload.MemoID = MM_Memo.MemoID WHERE ID=@id ORDER BY MemoID";
           
        //    cmd = new SqlCommand(str, conn);
        //    cmd.Parameters.AddWithValue("@id", ID);
        //    SqlDataReader sdr = cmd.ExecuteReader();

        //    sdr.Read();
        //    {
        //        //bytes = (byte[])sdr["UploadPath"];
        //        filename = sdr["Uploadname"].ToString();
        //        contType = sdr["UploadPath"].ToString();


        //    } 
        //    //string filepath = Server.MapPath("Files/" + filename);
        //Response.Clear();
        //Response.ClearHeaders();
        //Response.ClearContent();
        //Response.Buffer = true;
        //Response.Charset = "";
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.ContentType = contType;
        //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
        
        //Response.Flush();
        ////Response.TransmitFile(filepath);
        //Response.End();

            string filepath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filepath));
            Response.WriteFile(filepath);
            Response.End();

        }
        catch (Exception ex) {
            throw ex;
        }
        

    }
}