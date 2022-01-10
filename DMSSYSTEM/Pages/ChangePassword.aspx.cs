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
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;


public partial class Masterpages_Default : System.Web.UI.Page
{
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataAdapter adapt;
    String sqlstr = (ConfigurationManager.ConnectionStrings["cnn"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //HtmlAnchor navbar = (HtmlAnchor)(this.Master).FindControl("headernavbar");
        HtmlGenericControl navbar = (HtmlGenericControl)Master.FindControl("headernavbar");
        HtmlGenericControl aside = (HtmlGenericControl)Master.FindControl("asidenavbar");
        HtmlGenericControl contentwrapper = (HtmlGenericControl)Master.FindControl("contentwrapper");
        
        aside.Visible = false;
        navbar.Style.Add(HtmlTextWriterStyle.MarginLeft, "0");
        contentwrapper.Style.Add(HtmlTextWriterStyle.MarginLeft, "0");
        
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        
        String str;
        String strEncryptedPwd;
       if (txtNewPassword.Text.Trim() != txtConfirmNewPassword.Text.Trim())
       {
           Response.Write("<script>alert('Password does not match')</script>");
           return;
       } 
        conn = new SqlConnection(sqlstr);
        conn.Open();
       // now encrypt password
       strEncryptedPwd = Encrypt((txtNewPassword.Text.Trim()));
       // now update newusers table with the new pwd
       str = "update ADM_USERS set Password= '" + strEncryptedPwd + "', upd_changepassword = 1 where StaffID =  @Usr ";
        cmd = new SqlCommand(str, conn);
        cmd.Parameters.AddWithValue("@Usr", Session["StaffID"]);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
       // now redirect to login page
       Response.Write("<script>alert('Password has been changed successfully')</script>");
        Response.Redirect("~/Default.aspx", true);
       //Check Roles
       //if (Session["RoleName"].ToString() == "Administrator")
       //{
       //    Response.Redirect("Homepage/AdminHome.aspx", true);
       //}
       //else if (Session["RoleName"].ToString() == "Director")
       //{
       //    Response.Redirect("Homepage/DirectorHome.aspx", true);
       //}
       //else if (Session["RoleName"].ToString() == "Secretary")
       //{
       //    Response.Redirect("Homepage/SecretaryHome.aspx", true);
       //}
       //else if (Session["RoleName"].ToString() == "Unit Head")
       //{
       //    Response.Redirect("Homepage/UnitHeadHome.aspx", true);
       //}

       txtNewPassword.Text = "";
       txtConfirmNewPassword.Text = "";
       btnSubmit.Enabled = false;
     
    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        // Dim EncryptionKey As String = "ADA2009MAKV2SPBNI99212ONYEbISHOP"
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6E, 0x20, 0x4D, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

   
}