using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class AdminQuizDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuizzes();
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

        protected void AddQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminQuizAdd.aspx");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string quizTitle = btn.CommandArgument;
            Response.Redirect("AdminQuizEdit.aspx?title=" + quizTitle);
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string quizTitle = btn.CommandArgument;

            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Quizzes_Add WHERE title = @title";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", quizTitle);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadQuizzes();

            string script = "alert('Delete successful!');";
            ScriptManager.RegisterStartupScript(this, GetType(), "DeleteAlert", script, true);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This can be left empty or used for additional functionality if needed.
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin Main Page.aspx");
        }
    }
}
