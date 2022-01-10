using System;
using System.Collections.Generic;
using System.Linq;
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
        if (!Page.IsPostBack) { 
            GetDepartment();

        }

        
    }

    public void GetDepartment()
    {

        conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
        conn.Open();
        string sql = "Select * from ADM_OTHERDEPARTMENT";
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
            drpDepartment.DataTextField = "Dept_Name";
            drpDepartment.DataValueField = "Dept_ID";
            drpDepartment.DataBind();

            drpDepartment.SelectedIndex = 0;
        }
        else
        {

        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Record Saved Successfully.')", true);

    }
}