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
using System.Net.Mail;
using System.IO;
namespace Ehealth
{
    public partial class PatientReg : System.Web.UI.Page
    {

        DateTime laterDate = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //InsertData();
            //emailId = string.Empty;
            MailMessage msg;
            SqlCommand cmd = new SqlCommand();
            string ActivationUrl = string.Empty;


            try
            {
                String emailId = TextBox6.Text.Trim().ToString();
                MailMessage mailMsg = new MailMessage("iftekhar.rasul7@gmail.com", "emailId");
                mailMsg.Subject = "Confirmation email for account activation";
                String activationUrl = Server.HtmlEncode("http://localhost:8665/MySampleApplication/ActivateAccount.aspx?Id=" + FetchUserId(emailId) + "&EmailId=" + emailId);

                mailMsg.Body = "Hi " + TextBox1.Text.Trim() + "!\n" +
               "Thanks for showing interest and registring in <a href='http://www.Ehealth.com'> Ehealth.com<a> " +
               " Please <a href='" + activationUrl + "'>click here to activate</a>  your account and enjoy our services. \nThanks!";
                mailMsg.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Send(mailMsg);
                //           clear_controls();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Confirmation Link to activate your account has been sent to your email address');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Error occured : " + ex.Message.ToString() + "');", true);
                return;
            }
            finally 
            {
                ActivationUrl = string.Empty;
                //emailId = string.Empty;
                //con.Close();
                cmd.Dispose();
            }

            

        }


        public void InsertData() 
        {
            string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand com = new SqlCommand("select count(*) from PatientTable where [User Name]= @userName", con);
                com.Parameters.AddWithValue("@userName", TextBox2.Text.Trim());
                int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                if (temp > 0)
                {
                    Label1.Visible = true;
                    Label1.Text = "User name is exist";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                else 
                {
                    SqlCommand cmd = new SqlCommand("insertData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@userName", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@pass", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@presentAdd", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@emailAdd", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@mobileNo", TextBox7.Text.Trim());
                    cmd.Parameters.Add("@dbo", SqlDbType.Date).Value = TextBox8.Text.Trim();
                    cmd.ExecuteNonQuery();

                    DateTime birthDate = Convert.ToDateTime(TextBox8.Text);
                    string age1 = Convert.ToString(Age(birthDate, laterDate));
                    string userName = TextBox2.Text.ToString();
                    SqlCommand com1 = new SqlCommand("update [Ehealth].[dbo].[PatientTable] set Age='"+age1+"' where [User Name]='"+userName+"'", con);
                    com1.ExecuteNonQuery();
                    Response.Redirect("PatLogin.aspx");
                }
            }
        }

        public static string FetchUserId(string emailId)
        {
            string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("SELECT Id FROM PatientTable WHERE [Email address]=@EmailId", con);
            cmd.Parameters.AddWithValue("@EmailId", emailId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string UserID = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            cmd.Dispose();
            return UserID;
        }

        public static int Age(DateTime birthDate, DateTime laterDate)
        {
            int age;
            age = laterDate.Year - birthDate.Year;

            if (age > 0)
            {
                age -= Convert.ToInt32(laterDate.Date < birthDate.Date.AddYears(age));
            }
            else
            {
                age = 0;
            }

            return age;
        }

       



                    }
                }

          

