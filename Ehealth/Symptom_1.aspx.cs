using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ehealth
{
    public partial class Symptom_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Symptom_2.aspx");
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList2.SelectedValue == "1 || 2 || 3")
            {
               
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = "~/Images/Male.png";

            if (RadioButtonList1.SelectedValue == "1")
            {
                Image1.ImageUrl = "~/Images/Male.png";
            }
            else 
            {
                Image1.ImageUrl = "~/Images/Female.png";
            }
        }
    }
}