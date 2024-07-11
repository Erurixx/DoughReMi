using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignInButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Define the connection string
                string connectionString = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;

                // Create and open the connection
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Check if the username or email and password match
                    string checkUserQuery = "SELECT email FROM Register WHERE (userName = @userNameOrEmail OR email = @userNameOrEmail) AND password = @password";
                    SqlCommand cmd = new SqlCommand(checkUserQuery, con);
                    cmd.Parameters.AddWithValue("@userNameOrEmail", username.Text);
                    cmd.Parameters.AddWithValue("@password", password.Text);

                    string email = (string)cmd.ExecuteScalar();

                    if (!string.IsNullOrEmpty(email))
                    {
                        // Store the username or email in the session
                        Session["storeUsername"] = username.Text;

                        // Check if the email ends with @admin.com
                        if (email.EndsWith("@admin.com"))
                        {
                            // Redirect to admin dashboard
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login successful!');window.location ='Admin Main Page.aspx';", true);
                        }
                        else
                        {
                            // Redirect to user dashboard
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login successful!');window.location ='Main Page After Logged In.aspx';", true);
                        }
                    }
                    else
                    {
                        // Invalid credentials
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username or password.');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}
    
