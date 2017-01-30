using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Ehealth
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (!Page.IsPostBack)
            {
                BindAlbumDataList(); 
            }*/
            
            string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("Select * from PatientTable", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            }
        }
        string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;

        protected void BindAlbumDataList()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT ImageName,ImagePath FROM HistoryTable", con);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        dlImages.DataSource = dr;
                        dlImages.DataBind();
                    }
                    else
                    {
                        dlImages.DataSource = null;
                        dlImages.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("Error Occured: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void btnViewAlbum_Click(object sender, EventArgs e)
        {
            BindAlbumDataList();
        }


       
    }
}