using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ehealth
{
    /// <summary>
    /// Summary description for SympsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class SympsService : System.Web.Services.WebService
    {
        
        [WebMethod(enableSession: false)]
        public string GetSymptoms(String organ_name)
        {
            List<symps> listSymptoms = new List<symps>();

            string CS = ConfigurationManager.ConnectionStrings["EhealtsCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("sendSymptoms", con);
                cmd.CommandType = CommandType.StoredProcedure ;

                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@organ";
                parameter.Value = organ_name;
                cmd.Parameters.Add(parameter);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    symps symp = new symps();
                    symp.Sympt = rdr["SymptomsName"].ToString();
                    listSymptoms.Add(symp);
                  
                }
                String serializedList = JsonConvert.SerializeObject(listSymptoms);
                return serializedList;
                
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //Context.Response.Write(js.Serialize(listSymptoms));
            }
           
             
        }
    }
}
