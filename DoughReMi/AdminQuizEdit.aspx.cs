using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace WAPP_Assignment.Assignment
{
    public partial class AdminQuizEdit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string quizTitle = Request.QueryString["title"];
                if (!string.IsNullOrEmpty(quizTitle))
                {
                    LoadQuizDetails(quizTitle);
                }
            }
        }

        private void LoadQuizDetails(string quizTitle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
                            difficulty.SelectedValue = reader["difficult"].ToString();
                            question1.Text = reader["q1"].ToString();
                            choiceAq1.Text = reader["choiceAq1"].ToString();
                            choiceBq1.Text = reader["choiceBq1"].ToString();
                            choiceCq1.Text = reader["choiceCq1"].ToString();
                            choiceDq1.Text = reader["choiceDq1"].ToString();
                            ansQ1.SelectedValue = reader["ansQ1"].ToString();
                            question2.Text = reader["q2"].ToString();
                            choiceAq2.Text = reader["choiceAq2"].ToString();
                            choiceBq2.Text = reader["choiceBq2"].ToString();
                            choiceCq2.Text = reader["choiceCq2"].ToString();
                            choiceDq2.Text = reader["choiceDq2"].ToString();
                            ansQ2.SelectedValue = reader["ansQ2"].ToString();
                            question3.Text = reader["q3"].ToString();
                            choiceAq3.Text = reader["choiceAq3"].ToString();
                            choiceBq3.Text = reader["choiceBq3"].ToString();
                            choiceCq3.Text = reader["choiceCq3"].ToString();
                            choiceDq3.Text = reader["choiceDq3"].ToString();
                            ansQ3.SelectedValue = reader["ansQ3"].ToString();
                            question4.Text = reader["q4"].ToString();
                            choiceAq4.Text = reader["choiceAq4"].ToString();
                            choiceBq4.Text = reader["choiceBq4"].ToString();
                            choiceCq4.Text = reader["choiceCq4"].ToString();
                            choiceDq4.Text = reader["choiceDq4"].ToString();
                            ansQ4.SelectedValue = reader["ansQ4"].ToString();
                            question5.Text = reader["q5"].ToString();
                            choiceAq5.Text = reader["choiceAq5"].ToString();
                            choiceBq5.Text = reader["choiceBq5"].ToString();
                            choiceCq5.Text = reader["choiceCq5"].ToString();
                            choiceDq5.Text = reader["choiceDq5"].ToString();
                            ansQ5.SelectedValue = reader["ansQ5"].ToString();
                        }
                    }
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string quizTitle = Request.QueryString["title"];

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Quizzes_Add SET difficult = @difficult, " +
                    "q1 = @q1, choiceAq1 = @choiceAq1, choiceBq1 = @choiceBq1, choiceCq1 = @choiceCq1," +
                    "choiceDq1 = @choiceDq1, ansQ1 = @ansQ1, " +
                    "q2 = @q2, choiceAq2 = @choiceAq2, choiceBq2 = @choiceBq2, choiceCq2 = @choiceCq2," +
                    " choiceDq2 = @choiceDq2, ansQ2 = @ansQ2, " +
                    "q3 = @q3, choiceAq3 = @choiceAq3, choiceBq3 = @choiceBq3, choiceCq3 = @choiceCq3," +
                    " choiceDq3 = @choiceDq3, ansQ3 = @ansQ3, " +
                    "q4 = @q4, choiceAq4 = @choiceAq4, choiceBq4 = @choiceBq4, choiceCq4 = @choiceCq4," +
                    " choiceDq4 = @choiceDq4, ansQ4 = @ansQ4, " +
                    "q5 = @q5, choiceAq5 = @choiceAq5, choiceBq5 = @choiceBq5, choiceCq5 = @choiceCq5," +
                    " choiceDq5 = @choiceDq5, ansQ5 = @ansQ5 " +
                    "WHERE title = @title";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@difficult", difficulty.SelectedValue);
                    command.Parameters.AddWithValue("@q1", question1.Text);
                    command.Parameters.AddWithValue("@choiceAq1", choiceAq1.Text);
                    command.Parameters.AddWithValue("@choiceBq1", choiceBq1.Text);
                    command.Parameters.AddWithValue("@choiceCq1", choiceCq1.Text);
                    command.Parameters.AddWithValue("@choiceDq1", choiceDq1.Text);
                    command.Parameters.AddWithValue("@ansQ1", ansQ1.SelectedValue);
                    command.Parameters.AddWithValue("@q2", question2.Text);
                    command.Parameters.AddWithValue("@choiceAq2", choiceAq2.Text);
                    command.Parameters.AddWithValue("@choiceBq2", choiceBq2.Text);
                    command.Parameters.AddWithValue("@choiceCq2", choiceCq2.Text);
                    command.Parameters.AddWithValue("@choiceDq2", choiceDq2.Text);
                    command.Parameters.AddWithValue("@ansQ2", ansQ2.SelectedValue);
                    command.Parameters.AddWithValue("@q3", question3.Text);
                    command.Parameters.AddWithValue("@choiceAq3", choiceAq3.Text);
                    command.Parameters.AddWithValue("@choiceBq3", choiceBq3.Text);
                    command.Parameters.AddWithValue("@choiceCq3", choiceCq3.Text);
                    command.Parameters.AddWithValue("@choiceDq3", choiceDq3.Text);
                    command.Parameters.AddWithValue("@ansQ3", ansQ3.SelectedValue);
                    command.Parameters.AddWithValue("@q4", question4.Text);
                    command.Parameters.AddWithValue("@choiceAq4", choiceAq4.Text);
                    command.Parameters.AddWithValue("@choiceBq4", choiceBq4.Text);
                    command.Parameters.AddWithValue("@choiceCq4", choiceCq4.Text);
                    command.Parameters.AddWithValue("@choiceDq4", choiceDq4.Text);
                    command.Parameters.AddWithValue("@ansQ4", ansQ4.SelectedValue);
                    command.Parameters.AddWithValue("@q5", question5.Text);
                    command.Parameters.AddWithValue("@choiceAq5", choiceAq5.Text);
                    command.Parameters.AddWithValue("@choiceBq5", choiceBq5.Text);
                    command.Parameters.AddWithValue("@choiceCq5", choiceCq5.Text);
                    command.Parameters.AddWithValue("@choiceDq5", choiceDq5.Text);
                    command.Parameters.AddWithValue("@ansQ5", ansQ5.SelectedValue);
                    command.Parameters.AddWithValue("@title", quizTitle);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            string script = "alert('Quiz updated successful!'); window.location='AdminQuizDashboard.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "UpdateAlert", script, true);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminQuizDashboard.aspx");
        }
    }
}
