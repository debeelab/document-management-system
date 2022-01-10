using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Masterpages_Admin : System.Web.UI.MasterPage
{
    SqlConnection conn;
    SqlCommand cmd;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        lblFullname.Text = Session["Fullname"].ToString();
       // DeterminRole();
        //if (Session["RoleName"].ToString() == "Administrator")
        //{
        //    dashboardirector.Visible = false;
        //    CreateMemo.Visible = false;
        //    vwDirectorMemo.Visible = false;
        //    Response.Redirect("../Homepage/AdminHome.aspx", true);
        //}
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

    public void DeterminRole()
    {
        //Check Roles 
        if ((Session["StaffID"].ToString() == "2109E") || (Session["StaffID"].ToString() == "1234D"))
        {
            //Creatememo.Visible = false;
            CreateExternalMemo.Visible = true;
        }
        else
        {
            //Response.Write("You do not have access to this module !");
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('You do not have access to this module!')", true);
        }
    }

    public HtmlGenericControl navbar
    {
        get 
        {
            return headernavbar;
        }
        set
        {
            headernavbar = value;
        }
    }

    public HtmlGenericControl aside
    {
        get
        {
            return asidenavbar;
        }
        set
        {
            asidenavbar = value;
        }
    }

    public HtmlGenericControl content
    {
        get
        {
            return contentwrapper;
        }
        set
        {
            contentwrapper = value;
            
        }
    }

    protected void lnkbtnhome_Click(object sender, System.EventArgs e)
    {
        //Check Roles

        if (Session["RoleName"].ToString() == "Secretary")
        {
            Response.Redirect("../Homepage/SecretaryHome.aspx", true);
        }

        else if (Session["RoleName"].ToString() == "Administrator")
        {
            dashboardirector.Visible = false;
            Response.Redirect("../Homepage/AdminHome.aspx", true);
        }
        else if (Session["RoleName"].ToString() == "Director")
        {
            Response.Redirect("../Homepage/DirectorHome.aspx", true);
        }
        else if (Session["RoleName"].ToString() == "Unit Head")
        {
            Response.Redirect("../Homepage/UnitHeadHome.aspx", true);
        }
        //else

    }

    protected void dashboardirector_ServerClick(object sender, System.EventArgs e)
    {

        if (Session["RoleName"].ToString() == "Secretary")
        {
            Response.Redirect("../Homepage/SecretaryHome.aspx", true);
        }

        else if (Session["RoleName"].ToString() == "Administrator")
        {
            dashboardirector.Visible = false;
            CreateMemo.Visible = false;
            vwDirectorMemo.Visible = false;
            Response.Redirect("../Homepage/AdminHome.aspx", true);
        }
        else if (Session["RoleName"].ToString() == "Director")
        {
            Response.Redirect("../Homepage/DirectorHome.aspx", true);
        }
        else if (Session["RoleName"].ToString() == "Unit Head")
        {
            Response.Redirect("../Homepage/UnitHeadHome.aspx", true);
        }
    }
    
}
