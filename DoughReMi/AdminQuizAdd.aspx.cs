using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace WAPP_Assignment.Assignment
{
    public partial class AdminQuizAdd : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        { 
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Quizzes_Add (title, difficult, q1, choiceAq1, choiceBq1, choiceCq1, choiceDq1, ansQ1, 
                                                          q2, choiceAq2, choiceBq2, choiceCq2, choiceDq2, ansQ2,
                                                          q3, choiceAq3, choiceBq3, choiceCq3, choiceDq3, ansQ3,
                                                          q4, choiceAq4, choiceBq4, choiceCq4, choiceDq4, ansQ4,
                                                          q5, choiceAq5, choiceBq5, choiceCq5, choiceDq5, ansQ5)
                               VALUES (@title, @difficult, @q1, @choiceAq1, @choiceBq1, @choiceCq1, @choiceDq1, @ansQ1, 
                                       @q2, @choiceAq2, @choiceBq2, @choiceCq2, @choiceDq2, @ansQ2,
                                       @q3, @choiceAq3, @choiceBq3, @choiceCq3, @choiceDq3, @ansQ3,
                                       @q4, @choiceAq4, @choiceBq4, @choiceCq4, @choiceDq4, @ansQ4,
                                       @q5, @choiceAq5, @choiceBq5, @choiceCq5, @choiceDq5, @ansQ5)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters with values
                    command.Parameters.AddWithValue("@title", title.Text);
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

                    // Open the connection and execute the query
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            // Register the JavaScript to show the success message and redirect
            string script = "alert('Quiz added successful!'); window.location='AdminQuizDashboard.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "AddAlert", script, true);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminQuizDashboard.aspx");
        }
    }
}

