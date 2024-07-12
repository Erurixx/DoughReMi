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
    public partial class User_Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load user's profile data
                LoadUserProfile();

                try
                {
                    // Retrieve the login identifier from the session
                    string loginIdentifier = Session["storeUsername"]?.ToString();
                    string query = "SELECT imageURL FROM Register WHERE userName = @loginIdentifier OR email = @loginIdentifier";

                    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("loginIdentifier", loginIdentifier);
                            con.Open();
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                                string imageUrl = result.ToString();
                                imgProfilePic.ImageUrl = imageUrl;
                            }
                            else
                            {
                                // Handle case where no image URL is found in the database
                                imgProfilePic.ImageUrl = "/assets/default-avatar.jpg"; // Fallback to default avatar
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions
                    Console.WriteLine(ex.Message);
                }

            }
        }

        private void LoadUserProfile()
        {

            string loginIdentifier = Session["storeUsername"]?.ToString();
            string query = "SELECT fname, lname, email, userName, gender, imageURL FROM Register WHERE userName = @loginIdentifier OR email = @loginIdentifier";
            // Example: Retrieve user profile data based on user ID or session


            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@loginIdentifier", loginIdentifier); // Use @Username parameter to filter by username
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["fname"].ToString();
                        txtLastName.Text = reader["lname"].ToString();
                        txtEmail.Text = reader["email"].ToString();
                        txtUsername.Text = reader["userName"].ToString();
                        string gender = reader["gender"].ToString();
                        txtgender.SelectedValue = gender; // Set selected gender in dropdown
                        string imageUrl = reader["imageURL"].ToString();
                        imgProfilePic.ImageUrl = string.IsNullOrEmpty(imageUrl) ? "~/assets/default-avatar.jpg" : imageUrl;


                    }
                    reader.Close();
                }
                
            }
        }


        protected void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve current user's login identifier from session (username or email)
                string loginIdentifier = Session["storeUsername"].ToString();

                // Check if a file is uploaded
                string imageUrl = null;
                if (fuProfilePic.HasFile)
                {
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







                // Retrieve current profile data from the database based on username
                string query = "SELECT fname, lname, email, userName, gender, imageURL FROM Register WHERE userName = @loginIdentifier OR email = @loginIdentifier";

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@loginIdentifier", loginIdentifier);
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            // Retrieve current database values
                            string currentFirstName = reader["fname"].ToString();
                            string currentLastName = reader["lname"].ToString();
                            string currentEmail = reader["email"].ToString();
                            string currentUsername = reader["userName"].ToString();
                            string currentGender = reader["gender"].ToString();
                            string currentImageUrl = reader["imageURL"].ToString();

                            // Compare current database values with input values
                            bool updateRequired = false;

                            if (txtFirstName.Text.Trim() != currentFirstName)
                            {
                                cmd.Parameters.AddWithValue("@fname", txtFirstName.Text.Trim());
                                updateRequired = true;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@fname", currentFirstName); // Use current value if no change
                            }

                            if (txtLastName.Text.Trim() != currentLastName)
                            {
                                cmd.Parameters.AddWithValue("@lname", txtLastName.Text.Trim());
                                updateRequired = true;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@lname", currentLastName); // Use current value if no change
                            }

                            if (txtEmail.Text.Trim() != currentEmail)
                            {
                                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                                updateRequired = true;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@email", currentEmail); // Use current value if no change
                            }

                            if (txtgender.SelectedValue != currentGender)
                            {
                                cmd.Parameters.AddWithValue("@gender", txtgender.SelectedValue);
                                updateRequired = true;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@gender", currentGender); // Use current value if no change
                            }
                            if (imageUrl != null)
                            {
                                cmd.Parameters.AddWithValue("@imageURL", imageUrl);
                                updateRequired = true;
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@imageURL", currentImageUrl); // Use current value if no change
                            }



                            reader.Close();

                            // Perform update only if there are changes
                            if (updateRequired)
                            {
                                string updateQuery = "UPDATE Register SET fname = @fname, lname = @lname, ";
                                updateQuery += "email = @email, gender = @gender, imageURL = @imageURL ";
                                updateQuery += "WHERE userName = @currentUsername";

                                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                                {
                                    updateCmd.Parameters.AddWithValue("@fname", cmd.Parameters["@fname"].Value);
                                    updateCmd.Parameters.AddWithValue("@lname", cmd.Parameters["@lname"].Value);
                                    updateCmd.Parameters.AddWithValue("@email", cmd.Parameters["@email"].Value);
                                    updateCmd.Parameters.AddWithValue("@gender", cmd.Parameters["@gender"].Value);
                                    updateCmd.Parameters.AddWithValue("@imageURL", cmd.Parameters["@imageURL"].Value);
                                    updateCmd.Parameters.AddWithValue("@currentUsername", currentUsername);
                                    updateCmd.ExecuteNonQuery();
                                }

                                // Update the session with the new email if it was changed
                                if (txtEmail.Text.Trim() != currentEmail)
                                {
                                    Session["storeUsername"] = txtEmail.Text.Trim();
                                }
                                else
                                {
                                    Session["storeUsername"] = currentUsername;
                                }

                                // Update image URL for display if a new image was uploaded
                                if (imageUrl != null)
                                {
                                    imgProfilePic.ImageUrl = imageUrl;
                                }

                                // Redirect or display success message
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Profile updated successfully!'); window.location ='Main Page After Logged In.aspx';", true);
                            }
                            else
                            {
                                // No changes detected, do nothing or display a message
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No changes detected.');", true);
                            }
                        }
                        else
                        {
                            // Username not found in database
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User ID not found.');", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle error
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Response.Redirect("Main Page After Logged In.aspx");
        }

    }
}

      