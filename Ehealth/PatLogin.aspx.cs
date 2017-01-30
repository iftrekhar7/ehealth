using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.Security;

namespace Ehealth
{
    public partial class PatLogin : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             
             using (SqlConnection con = new SqlConnection(CS))
             {
                 con.Open();
                 SqlCommand cmd = new SqlCommand("select count(*) from PatientTable where [User name]= @userName and [pasword] = @pass", con);

                 cmd.Parameters.AddWithValue("@userName", TextBox1.Text.Trim());
                 cmd.Parameters.AddWithValue("@pass", TextBox2.Text);

                 int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                 if (temp > 0)
                 {
                     Session["USER_ID"] = TextBox1.Text;
                     Response.Redirect("patientProfile.aspx");
                 }
                 else 
                 {
                     //ScriptManager.RegisterClientScriptBlock(this.Page,this.GetType(),"MyScript","alert('invalid user name or password!',)",true);
                     Label1.Visible = true;
                     Label1.Text = "baler pass dicos";
                     Label1.ForeColor = System.Drawing.Color.Red;
                 }
             }

                
                
        }
    }
}