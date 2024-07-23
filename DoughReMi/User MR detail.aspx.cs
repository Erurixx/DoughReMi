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
    public partial class User_MR_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string mrName = Request.QueryString["MRname"];
                if (!string.IsNullOrEmpty(mrName))
                {
                    LoadUserProfile();
                    LoadProfilePicture();
                    LoadRecipeDetails(mrName);
                }
            }
        }

        private void LoadUserProfile()
        {
            string loginIdentifier = Session["storeUsername"]?.ToString();

            if (!string.IsNullOrEmpty(loginIdentifier))
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                {
                    string query = "SELECT userName FROM Register WHERE userName = @loginIdentifier OR email = @loginIdentifier";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@loginIdentifier", loginIdentifier);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usernamelbl.Text = "Hi, " + reader["userName"].ToString();
                    }
                    conn.Close();
                }
            }
        }

        private void LoadProfilePicture()
        {
            string loginIdentifier = Session["storeUsername"]?.ToString();

            if (!string.IsNullOrEmpty(loginIdentifier))
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString))
                {
                    string query = "SELECT imageURL FROM Register WHERE userName = @loginIdentifier OR email = @loginIdentifier";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@loginIdentifier", loginIdentifier);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string imageUrl = reader["imageURL"].ToString();
                        if (!string.IsNullOrEmpty(imageUrl))
                        {
                            ProfilePicture.ImageUrl = imageUrl;
                        }
                    }
                    conn.Close();
                }
            }
        }

        protected void ProfilePicture_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User Profile.aspx");
        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Log Out Successful!'); window.location ='Login.aspx';", true);
        }

        private void LoadRecipeDetails(string mrName)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
            {
                string query = "SELECT MRname, MRimage, MRdescription, MRvideourl FROM MenuRecipe WHERE MRname = @MRname";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MRname", mrName);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    MRNameLabel.Text = reader["MRname"].ToString();
                    MRImage.ImageUrl = reader["MRimage"].ToString();
                    MRDescriptionLabel.Text = reader["MRdescription"].ToString();

                    string videoUrl = reader["MRvideourl"].ToString();
                    if (!string.IsNullOrEmpty(videoUrl))
                    {
                        ViewState["VideoUrl"] = videoUrl; // Store the video URL in ViewState
                        LoadVideo(videoUrl); // Load the video
                    }
                }
                conn.Close();
            }
        }

        private void LoadVideo(string videoUrl)
        {
            MRVideoPlaceholder.Controls.Clear();
            MRVideoPlaceholder.Controls.Add(new LiteralControl($"<video width='300' height='auto' controls><source src='{videoUrl}' type='video/mp4'>Your browser does not support the video tag.</video>"));
        }

        protected void Bookmark_Click(object sender, EventArgs e)
        {
            string userName = usernamelbl.Text;
            string mrName = MRNameLabel.Text;

            if (string.IsNullOrEmpty(userName))
            {
                // Show an alert to log in
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please log in to add a bookmark.');", true);
                return;
            }

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
            {
                // Check if the bookmark already exists
                string checkQuery = "SELECT COUNT(*) FROM Bookmark WHERE userName = @userName AND MRname = @MRname";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@userName", userName);
                checkCmd.Parameters.AddWithValue("@MRname", mrName);

                conn.Open();
                int count = (int)checkCmd.ExecuteScalar();
                conn.Close();

                if (count > 0)
                {
                    // Bookmark already exists
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('This recipe is already bookmarked!');", true);
                }
                else
                {
                    // Insert new bookmark
                    string insertQuery = "INSERT INTO Bookmark (userName, MRname) VALUES (@userName, @MRname)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@userName", userName);
                    insertCmd.Parameters.AddWithValue("@MRname", mrName);

                    conn.Open();
                    insertCmd.ExecuteNonQuery();
                    conn.Close();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Added to bookmarked successfully!');", true);
                    Response.Redirect("User Bookmark.aspx");
                }
            }
        }


    }
}