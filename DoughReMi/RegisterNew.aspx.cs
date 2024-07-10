using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class RegisterNew : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) // Check if the page is valid
            {
                try
                {
                    // Establish connection
                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                    {
                        con.Open();

                        // Check if username already exists
                        string checkUserQuery = "SELECT COUNT(*) FROM Register WHERE userName = @username";
                        SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, con);
                        checkUserCmd.Parameters.AddWithValue("@username", username.Text);
                        int userCount = (int)checkUserCmd.ExecuteScalar();

                        if (userCount > 0)
                        {
                            // Username already exists
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Username already exists. Please choose another.');", true);
                            return;
                        }

                        // Define SQL query with parameters
                        string query = "INSERT INTO Register (fname, lname, userName, email, gender, password) " +
                                       "VALUES (@fname, @lname, @username, @email, @gender, @password)";

                        SqlCommand cmd = new SqlCommand(query, con);

                        // Add parameters
                        cmd.Parameters.AddWithValue("@fname", fname.Text);
                        cmd.Parameters.AddWithValue("@lname", lname.Text);
                        cmd.Parameters.AddWithValue("@username", username.Text);
                        cmd.Parameters.AddWithValue("@email", email.Text);
                        cmd.Parameters.AddWithValue("@gender", gender.SelectedItem.Value); // Adjusted to use Value
                        cmd.Parameters.AddWithValue("@password", password.Text);

                        // Execute the query
                        cmd.ExecuteNonQuery();

                        // Registration successful, redirect to login page or display success message
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration successful!');window.location ='Login.aspx';", true);
                    }
                }
                catch (Exception ex)
                {
                    // Log and display error message
                    System.IO.File.WriteAllText(Server.MapPath("~/Errors.txt"), ex.ToString());
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
                }
            }
        }
        protected void ValidatePassword(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(args.Value) && Regex.IsMatch(args.Value, @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+])[A-Za-z\d!@#$%^&*()_+]{8,}$");
        }

        protected void ValidateRequiredField(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(args.Value);
        }

        protected void ValidateEmail(object source, ServerValidateEventArgs args)
        {
            args.IsValid = !string.IsNullOrWhiteSpace(args.Value) && Regex.IsMatch(args.Value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
    
}



