using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class Masterpages_Admin : System.Web.UI.MasterPage
{
    SqlConnection conn;
    SqlCommand cmd;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        lblFullname.Text = Session["Fullname"].ToString();
        DeterminRole();
    }
    public void DeterminRole()
    {
        //Check Roles
        //conn = new SqlConnection(sqlstr);
        //conn.Open();
        //string sql = "Select * from ADM_Roles WHERE CreatedBy = @staff";
        //cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["StaffId"]);
        
        if (Session["RoleName"].ToString() == "Administrator")
        {
            Createuser.Visible = true;
            addDepart.Visible = true;
            //Response.Redirect("Homepage/AdminHome.aspx", true);
        }
        else if (Session["RoleName"].ToString() == "Director")
        {
            Createuser.Visible = true;
            addDepart.Visible = false;
            admindashboard.Visible = false;
            Response.Redirect("Homepage/DirectorHome.aspx", true);
        }
        else {
            Response.Write("You do not have access to this module !");
        }
    }
    public LinkButton VwMemo
    {
        get
        {
            return vwDirectorMemo;
        }
        set
        {
            vwDirectorMemo = value;
        }
    }

    public LinkButton vwAll
    {
        get
        {
            return lnkvwAll;
        }
        set
        {
            lnkvwAll = value;
        }
    }

    public LinkButton Untreated
    {
        get
        {
            return lnkUntreated;
        }
        set
        {
            lnkUntreated = value;
        }
    }

    public LinkButton Treated
    {
        get
        {
            return lnkTreated;
        }
        set
        {
            lnkTreated = value;
        }
    }
    protected void lnkbtnhome_Click(object sender, EventArgs e)
    {
        //Check Roles

        if (Session["RoleName"].ToString() == "Administrator")
        {
            admindashboard.Visible = true;
            Response.Redirect("../Homepage/AdminHome.aspx", true);
        }
        //else if (Session["RoleName"].ToString() == "Director")
        //{
        //    Response.Redirect("../Homepage/DirectorHome.aspx", true);
        //}
        //else if (Session["RoleName"].ToString() == "Unit Head")
        //{
        //    Response.Redirect("../Homepage/UnitHeadHome.aspx", true);
        //}
        else 
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('You do not have access to this module!')", true);
        }

    }
}
