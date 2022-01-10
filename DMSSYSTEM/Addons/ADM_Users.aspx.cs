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
    //String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
    SqlCommand cmd;
    SqlDataAdapter adapt;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDepartment();
            GetRoles();
        }
    }
    public void ClearField()
    {
        txtStaffID.Text = string.Empty;
        txtfullName.Text = string.Empty;
        txtPassword.Text = string.Empty;
        drpDepartment.SelectedIndex = -1;
        //drpDepartmentToID.SelectedIndex = -1;
        drpRole.SelectedIndex = -1;

    }
    protected void Save_Click(object sender, EventArgs e)
    {

        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        conn.Open();
        string sql = "INSERT INTO ADM_Users(StaffID,Password,RoleID,DepartmentID,Fullname,CreatedBy ) VALUES (@StaffID,@Password,@RoleID,@DepartmentID,@Fullname,@CreatedBy)";
        cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@StaffID", txtStaffID.Text);
        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
        cmd.Parameters.AddWithValue("@RoleID", drpRole.SelectedValue);
        cmd.Parameters.AddWithValue("@DepartmentID", drpDepartment.SelectedValue);
        cmd.Parameters.AddWithValue("@Fullname", txtfullName.Text);
        cmd.Parameters.AddWithValue("@CreatedBy", Session["StaffID"]);
        if (cmd.ExecuteNonQuery() == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Saved Successfully.')", true);
            ClearField();

        }
        else
        {
            //lblInfo.Text = "Record not Saved";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Not Saved.')", true);
        }

        conn.Close();
    }

    public void GetDepartment()
    {

        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        conn.Open();
        string sql = "Select * from ADM_Department";
        SqlCommand cmd = new SqlCommand(sql, conn);


        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);

        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpDepartment.Items.Clear();
        drpDepartment.AppendDataBoundItems = true;
        drpDepartment.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpDepartment.DataSource = ds.Tables[0];
            drpDepartment.DataTextField = "DepartmentName";
            drpDepartment.DataValueField = "DepartmentID";
            drpDepartment.DataBind();

            drpDepartment.SelectedIndex = 0;
        }
        else
        {

        }
    }


    public void GetRoles()
    {
        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        conn.Open();
        string sql = "Select * from ADM_Roles";
        SqlCommand cmd = new SqlCommand(sql, conn);


        cmd.ExecuteNonQuery();

        SqlDataAdapter adt = new SqlDataAdapter(cmd);

        System.Data.DataSet ds = new System.Data.DataSet();

        adt.Fill(ds);
        ListItem li = default(ListItem);
        li = new ListItem();
        li.Text = "--Select--";
        li.Value = "0";

        drpRole.Items.Clear();
        drpRole.AppendDataBoundItems = true;
        drpRole.Items.Add(li);

        if (ds.Tables[0].Rows.Count > 0)
        {

            drpRole.DataSource = ds.Tables[0];
            drpRole.DataTextField = "RoleName";
            drpRole.DataValueField = "RoleID";
            drpRole.DataBind();

            drpRole.SelectedIndex = 0;
        }
        else
        {

        }
    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Saved Successfully.')", true);
    //}
}