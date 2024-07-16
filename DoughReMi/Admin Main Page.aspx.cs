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
    public partial class Admin_Main_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
                LoadProfilePicture();
                LoadDashboardData();
            }
        }

        private void LoadUserProfile()
        {
            // Retrieve the login identifier from the session
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
                        // Set the username in the label
                        usernamelbl.Text = "Hi, " + reader["userName"].ToString();
                    }
                    conn.Close();
                }
            }

        }


        private void LoadProfilePicture()
        {
            // Retrieve the login identifier from the session
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

        private void LoadDashboardData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Fetch registered users count
                string registeredUsersQuery = "SELECT COUNT(*) FROM Register";
                SqlCommand registeredUsersCmd = new SqlCommand(registeredUsersQuery, con);
                int registeredUsersCount = (int)registeredUsersCmd.ExecuteScalar();
                lblRegisteredUsers.Text = registeredUsersCount.ToString();

               
            }
        }
    }
}