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
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect back to the previous page (assuming you have a specific page URL to redirect to)
            Response.Redirect("Main Page After Logged In.aspx");
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmNewPassword = txtConfirmPassword.Text.Trim();

            // Validate if passwords match
            if (newPassword != confirmNewPassword)
            {
                // Passwords do not match, show error message
                Response.Write("<script>alert('New Password and Confirm New Password do not match');</script>");
                return;
            }

            // Validate if new password meets the required criteria
            if (newPassword.Length < 8 || !System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"\d") || !System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"[a-zA-Z]"))
            {
                // New password does not meet criteria, show error message
                Response.Write("<script>alert('New Password must be at least 8 characters long and contain at least one number and one letter');</script>");
                return;
            }

            // TODO: Add logic to change password in your database
            // Example code to update password in the database
            string username = Session["storeUsername"]?.ToString(); // Retrieve username from session

            if (!string.IsNullOrEmpty(username))
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                {
                    string query = "SELECT password FROM Register WHERE userName = @userName";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@userName", username);

                    conn.Open();
                    string storedPassword = cmd.ExecuteScalar() as string;
                    conn.Close();

                    // Validate if the current password matches the stored password
                    if (storedPassword == currentPassword)
                    {
                        query = "UPDATE Register SET password = @newPassword WHERE userName = @userName";
                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@newPassword", newPassword);
                        cmd.Parameters.AddWithValue("@userName", username);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        // Password updated successfully
                        Response.Write("<script>alert('Password updated successfully');</script>");
                        Response.Redirect("User Profile.aspx");
                    }
                    else
                    {
                        // Current password is incorrect, show error message
                        Response.Write("<script>alert('Current Password is incorrect');</script>");
                    }
                }
            }
            else
            {
                // Session expired or username not found
                Response.Redirect("Login.aspx");
            }
        }
    }
}