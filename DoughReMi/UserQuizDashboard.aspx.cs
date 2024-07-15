using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class UserQuizDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
                LoadProfilePicture();
                LoadQuizzes();
                LoadScore();
            }
        }


        private void LoadQuizzes()
        {
           string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT title, difficult FROM Quizzes_Add";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        private void LoadScore()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT username, title, score FROM Quizzes_Score WHERE username = @username";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }

        protected void Attempt_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string quizTitle = btn.CommandArgument;
            Response.Redirect("UserQuizAttempt.aspx?title=" + quizTitle);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main Page After Logged In.aspx");
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

        protected void ProfilePicture_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User Profile.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
