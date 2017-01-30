using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Ehealth
{
    public partial class ActivationAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ActivateMyAccount();
            }
        }

        private void ActivateMyAccount() 
        {
            string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS)) 
            {
                try
                {
                    if ((!string.IsNullOrEmpty(Request.QueryString["Id"])) & (!string.IsNullOrEmpty(Request.QueryString["EmailId"])))
                    {
                        //approve account by setting Is_Approved to 1 i.e. True in the sql server table
                        SqlCommand cmd = new SqlCommand("UPDATE PatientTable SET Is_Approved=1 WHERE Id=@UserID AND [Email address]=@EmailId", con);
                        cmd.Parameters.AddWithValue("@UserID", Request.QueryString["Id"]);
                        cmd.Parameters.AddWithValue("@EmailId", Request.QueryString["EmailId"]);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        Response.Write("You account has been activated. You can <a href='PatLogin.aspx'>Login</a> now! ");
                    }
                }
                catch(Exception ex) 
                {
                  ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                  return;
                }
                finally
                {
                    con.Close();
                   // cmd.Dispose();
                }
            }
        }
    }
}