using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class Add_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Redirect back to the previous page (assuming you have a specific page URL to redirect to)
            Response.Redirect("Manage Admin.aspx");
        }

        protected void btnAddProfile_Click(object sender, EventArgs e)
        {
            // Get values from the form
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim(); // Retrieve password
            string gender = txtgender.SelectedValue;

            // Validate inputs
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(gender))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please fill in all fields.');", true);
                return;
            }

            // Validate email domain
            string[] emailParts = email.Split('@');
            if (emailParts.Length != 2 || emailParts[1] != "admin.com")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Email must be in the format username@admin.com.');", true);
                return;
            }

            // Save admin details to database
            
            try
            {
                string imageUrl = "/assets/default-avatar.jpg"; // Default image URL
                if (fuProfilePic.HasFile)
                {

                    // Validate file extension
                    string fileExtension = Path.GetExtension(fuProfilePic.FileName).ToLower();
                    if (fileExtension != ".jpg" && fileExtension != ".jpeg" && fileExtension != ".png")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Only .jpg, .jpeg, or .png files are allowed.');", true);
                        return;
                    }
                    // Save profile picture to server and get the URL
                    string filename = Path.GetFileName(fuProfilePic.FileName);
                    string folderPath = Server.MapPath("/UploadedImages/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string filePath = Path.Combine(folderPath, filename);
                    fuProfilePic.SaveAs(filePath);
                    imageUrl = "/UploadedImages/" + filename;
                }

                // Insert admin data into the database
                string query = "INSERT INTO Register (fname, lname, email, userName, gender, imageURL, password) " +
                               "VALUES (@fname, @lname, @email, @userName, @gender, @imageURL, @password)";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@fname", firstName);
                        cmd.Parameters.AddWithValue("@lname", lastName);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@userName", username); // You can generate a username or leave empty if not needed
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@gender", gender);
                        cmd.Parameters.AddWithValue("@imageURL", imageUrl);
                        

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // Optionally, display success message or redirect to another page
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Admin added successfully'); window.location ='Manage Admin.aspx';", true);
            }
            catch (Exception ex)
            {
                // Handle exceptions
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }
    }
}