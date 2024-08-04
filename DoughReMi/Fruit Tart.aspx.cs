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
    public partial class Menu_and_Recipe___Jas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
                LoadProfilePicture();
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
            Response.Redirect("User_Profile.aspx");
        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Log Out Successful!'); window.location ='Login.aspx';", true);
        }
    }
}