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
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Save_Click(object sender, EventArgs e)
    {
        
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        conn.Open();
        string sql = "INSERT INTO ADM_department(DepartmentName,DepartmentCode,CreatedBy ) VALUES (@DepartmentName,@DepartmentCode,@CreatedBy)";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("DepartmentName", txtdepartmentName.Text);
        cmd.Parameters.AddWithValue("DepartmentCode", txtdepartmentCode.Text);
        cmd.Parameters.AddWithValue("CreatedBy", Session["StaffID"]);
        if (cmd.ExecuteNonQuery() == 1)
        {
            lblInfo.Text = "Record Saved Successfully";
            
        }
        else
        {
            lblInfo.Text = "Record not Saved";
        }
        conn.Close();
    }
}