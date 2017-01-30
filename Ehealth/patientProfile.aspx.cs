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
    public partial class patientProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["USER_ID"] != null)
            {
                Label1.Text = Session["USER_ID"].ToString();  
            }
            else
            {
                Response.Redirect("PatientReg.aspx");
            }
        }
         string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("USER_ID");

            Response.Redirect("PatientReg.aspx");
        }

        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {
           using (SqlConnection con = new SqlConnection(CS))
            {
                string filePath = string.Empty;
                try
                {
                    string userName = Session["USER_ID"].ToString(); 
                    filePath = (Server.MapPath("~/Album/") + Guid.NewGuid() + System.IO.Path.GetFileName(e.FileName));
                    AjaxFileUpload1.SaveAs(filePath);
                    string strFile = filePath.Substring(filePath.LastIndexOf("\\"));
                    string strFileName = strFile.Remove(0, 1);
                    string strFilePath = "~/Album/" + strFileName;
                    SqlCommand cmd = new SqlCommand("Insert into HistoryTable (UserName,ImageName,ImagePath) values (@USER_NAME,@IMAGE_NAME,@IMAGE_PATH)", con);
                    cmd.Parameters.AddWithValue("@USER_NAME", userName);
                    cmd.Parameters.AddWithValue("@IMAGE_NAME", strFileName);
                    cmd.Parameters.AddWithValue("@IMAGE_PATH", strFilePath);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    cmd.Dispose();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }      
            }
            
        }       
    }
}