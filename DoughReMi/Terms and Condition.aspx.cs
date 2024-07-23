using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class Terms_and_Condition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Check if the user is logged in by inspecting the session variable
            if (Session["storeUsername"] != null)
            {
                // If the user is logged in, redirect to the registered user main page
                Response.Redirect("Main Page After Logged In.aspx");
            }
            else
            {
                // If the user is not logged in, redirect to the non-user main page
                Response.Redirect("Main Page.aspx");
            }
        }
    }
}