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
    public partial class AdminQuizView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string quizTitle = Request.QueryString["title"];
            if (!string.IsNullOrEmpty(quizTitle))
            {
                LoadQuizDetails(quizTitle);
            }
        }

        private void LoadQuizDetails(string quizTitle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Quizzes_Add WHERE title = @title";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", quizTitle);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            title.Text = reader["title"].ToString();
                            difficulty.Text = reader["difficult"].ToString();
                            q1.Text = reader["q1"].ToString();
                            choice1a.Text = reader["choiceAq1"].ToString();
                            choice1b.Text = reader["choiceBq1"].ToString();
                            choice1c.Text = reader["choiceCq1"].ToString();
                            choice1d.Text = reader["choiceDq1"].ToString();
                            ansq1.Text = reader["ansQ1"].ToString();
                            q2.Text = reader["q2"].ToString();
                            choice2a.Text = reader["choiceAq2"].ToString();
                            choice2b.Text = reader["choiceBq2"].ToString();
                            choice2c.Text = reader["choiceCq2"].ToString();
                            choice2d.Text = reader["choiceDq2"].ToString();
                            ansq2.Text = reader["ansQ2"].ToString();
                            q3.Text = reader["q3"].ToString();
                            choice3a.Text = reader["choiceAq3"].ToString();
                            choice3b.Text = reader["choiceBq3"].ToString();
                            choice3c.Text = reader["choiceCq3"].ToString();
                            choice3d.Text = reader["choiceDq3"].ToString();
                            ansq3.Text = reader["ansQ3"].ToString();
                            q4.Text = reader["q4"].ToString();
                            choice4a.Text = reader["choiceAq4"].ToString();
                            choice4b.Text = reader["choiceBq4"].ToString();
                            choice4c.Text = reader["choiceCq4"].ToString();
                            choice4d.Text = reader["choiceDq4"].ToString();
                            ansq4.Text = reader["ansQ4"].ToString();
                            q5.Text = reader["q5"].ToString();
                            choice5a.Text = reader["choiceAq5"].ToString();
                            choice5b.Text = reader["choiceBq5"].ToString();
                            choice5c.Text = reader["choiceCq5"].ToString();
                            choice5d.Text = reader["choiceDq5"].ToString();
                            ansq5.Text = reader["ansQ5"].ToString();
                        }
                    }
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin Quiz Dashboard.aspx");
        }
    }
}