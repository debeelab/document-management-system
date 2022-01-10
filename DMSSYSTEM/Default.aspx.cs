using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Security.Cryptography;

public partial class Default : System.Web.UI.Page
{
    //Database Access
    SqlConnection conn;
    SqlDataAdapter adapt;
    SqlCommand cmd;
    String sqlstr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private string Encrypt(string clearText)
    {
        string EncryptionKey = "MAKV2SPBNI99212";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
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

    private string Decrypt(string cipherText)
    {
        string EncryptionKey = "ADA2009MAKV2SPBNI99212ONYEbISHOP";
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }
    protected void btnsignIn_Click(object sender, EventArgs e)
    {
        string strPassword, strEnteredPwd, strEncryptedPwd;
        int intChangePassword = 0;

        if (txtstaffID.Value.Trim() != "" && txtpassword.Value.Trim() != "")
        {
            conn = new SqlConnection(sqlstr);
            conn.Open();
            // string str = "SELECT  *, (Select RoleName from ADM_ROLES WHERE RoleID = ADM_Users.RoleID) as RoleName FROM ADM_USERS where StaffID = @StaffID and Password = @Password";
            string str = "SELECT  *, (Select RoleName from ADM_ROLES WHERE RoleID = ADM_Users.RoleID) as RoleName FROM ADM_USERS where StaffID = @StaffID";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@StaffID", txtstaffID.Value.Trim());
            //cmd.Parameters.AddWithValue("@Password", txtpassword.Value);

            //SqlDataReader dr;
            //dr = cmd.ExecuteReader();
            //if (dr.Read()) 
            //{
            //    strPassword = dr["Password"].ToString();  
            //    strPassword = strPassword.Trim();
            //    strEnteredPwd = txtpassword.Value.Trim();
            //    strEncryptedPwd = Encrypt(strEnteredPwd);

            //    //lblInfo.Text = strPassword;
            //    if (strPassword != strEnteredPwd)
            //    {
            //        Response.Write("<script>alert('Password does not match')</script>");
            //        return;
            //    }
            //    else 
            //    {  
            //        lblInfo.Text = strEncryptedPwd;
            //    }
                
            //}

            DataSet ds = new DataSet();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strPassword = ds.Tables[0].Rows[0]["Password"].ToString();  
                strPassword = strPassword.Trim();
                strEnteredPwd = txtpassword.Value.Trim();
                strEncryptedPwd = Encrypt(strEnteredPwd);
                if (strPassword == strEnteredPwd)
                {
                    lblInfo.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    Session["RoleName"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    Session["StaffID"] = ds.Tables[0].Rows[0]["StaffID"].ToString();
                    Session["Role"] = ds.Tables[0].Rows[0]["RoleID"].ToString();
                    Session["LoginID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["Fullname"] = ds.Tables[0].Rows[0]["Fullname"].ToString();
                    Session["DepartmentID"] = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                    //intChangePassword = int.Parse(ds.Tables[0].Rows[0]["Upd_ChangePassword"].ToString());
                    if (intChangePassword == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You must change your password now!')", true);
                        Response.Redirect("Pages/ChangePassword.aspx", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You must change your password now!')", true);
                        Response.Redirect("Pages/ChangePassword.aspx", true);
                    }
                }
                else if (strPassword == strEncryptedPwd)
                {
                    lblInfo.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    Session["RoleName"] = ds.Tables[0].Rows[0]["RoleName"].ToString();
                    Session["StaffID"] = ds.Tables[0].Rows[0]["StaffID"].ToString();
                    Session["Role"] = ds.Tables[0].Rows[0]["RoleID"].ToString();
                    Session["LoginID"] = ds.Tables[0].Rows[0]["UserID"].ToString();
                    Session["Fullname"] = ds.Tables[0].Rows[0]["Fullname"].ToString();
                    Session["DepartmentID"] = ds.Tables[0].Rows[0]["DepartmentID"].ToString();
                    intChangePassword = int.Parse(ds.Tables[0].Rows[0]["Upd_ChangePassword"].ToString());

                    if (intChangePassword == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You must change your password now!')", true);
                        Response.Redirect("../Pages/ChangePassword.aspx", true);
                    }
                    else
                    {
                        //Check Roles
                        if (Session["RoleName"].ToString() == "Administrator")
                        {
                            Response.Redirect("Homepage/AdminHome.aspx", true);
                        }
                        else if (Session["RoleName"].ToString() == "Director")
                        {
                            Response.Redirect("Homepage/DirectorHome.aspx", true);
                        }
                        else if (Session["RoleName"].ToString() == "Secretary")
                        {
                            Response.Redirect("Homepage/SecretaryHome.aspx", true);
                        }
                        else if (Session["RoleName"].ToString() == "Unit Head")
                        {
                            Response.Redirect("Homepage/UnitHeadHome.aspx", true);
                        }

                    }
                }        
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No matched username or password found!')", true);
            }
        }
        else 
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('The Username or Password field cannot be empty')", true);
        }
    }
}