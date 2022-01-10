using System;
using System.Collections.Generic;
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

    public LinkButton GetSameOffice
    {
        get
        {
            return lnksameoffice;
        }
        set
        {
            lnksameoffice = value;
        }
    }
    public LinkButton GetToAnotherOffice
    {

        get
        {
            return lnkbtnanotheroffice;
        }
        set
        {
            lnkbtnanotheroffice = value;
        }

    }

    //public LinkButton GetVirtualShelf
    //{

    //    get
    //    {
    //        return lnkbtnvshelf;
    //    }
    //    set
    //    {
    //        lnkbtnvshelf = value;
    //    }

    //}


    public void DeterminRole()
    {
        //Check Roles
        if (Session["RoleName"].ToString() == "Secretary")
        {
            CreateMemo.Visible = false;
            //vwMemo.Visible = true;
        }
         else if (Session["RoleName"].ToString() == "Unit Head")
        {
            CreateMemo.Visible = false;
            //vwMemo.Visible = true;
            dispatch.Visible = false;

        }
        else if (Session["RoleName"].ToString() == "Administrator") {
            dashboard.Visible = false;
            //vwMemo.Visible = false;
            
            dispatch.Visible = true;
        }
        else if(Session["RoleName"].ToString() == "Director") 
        {
            dashboard.Visible = false;
            //vwMemo.Visible = false;
            CreateInterMemo.Visible = false;
            dispatch.Visible = false;
            vshelf.Visible = false;
        }
        else if (((Session["RoleName"].ToString() == "Director")) && (Session["StaffID"].ToString() == "2109E"))
        {
            CreateMemo.Visible = true;
            dispatch.Visible = true;
            CreateInterMemo.Visible = true;
            vshelf.Visible = true;
        }
        
        else
        {
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('You do not have access to this module !.')", true);
            //Response.Write("");
        }
    }


    protected void lnkbtnhome_Click(object sender, System.EventArgs e)
    {
        //Check Roles
        //conn = new SqlConnection(sqlstr);
        //conn.Open();
        //string sql = "Select * from ADM_Roles WHERE CreatedBy = @staff";
        //cmd = new SqlCommand(sql, conn);
        //cmd.Parameters.AddWithValue("@staff", Session["StaffId"]);


        if (Session["RoleName"].ToString() == "Secretary")
        {
            Response.Redirect("../Homepage/SecretaryHome.aspx", true);
        }

        else if (Session["RoleName"].ToString() == "Administrator")
        {
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

   
}
