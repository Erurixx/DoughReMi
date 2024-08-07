﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class UserQuizAttempt : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string quizTitle = Request.QueryString["title"];                
                lblQuizTitle.Text = quizTitle;
                LoadQuizQuestions(quizTitle);
                LoadUserProfile();
                LoadProfilePicture();
            }
        }

        private void LoadQuizQuestions(string quizTitle)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT q1, choiceAq1, choiceBq1, choiceCq1, choiceDq1, ansQ1, " +
                               "q2, choiceAq2, choiceBq2, choiceCq2, choiceDq2, ansQ2, " +
                               "q3, choiceAq3, choiceBq3, choiceCq3, choiceDq3, ansQ3, " +
                               "q4, choiceAq4, choiceBq4, choiceCq4, choiceDq4, ansQ4, " +
                               "q5, choiceAq5, choiceBq5, choiceCq5, choiceDq5, ansQ5 " +
                               "FROM Quizzes_Add WHERE title = @title";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", quizTitle);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                var questions = new List<Question>();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    questions.Add(new Question
                    {
                        QuestionText = row["q1"].ToString(),
                        ChoiceA = row["choiceAq1"].ToString(),
                        ChoiceB = row["choiceBq1"].ToString(),
                        ChoiceC = row["choiceCq1"].ToString(),
                        ChoiceD = row["choiceDq1"].ToString(),
                    });
                    questions.Add(new Question
                    {
                        QuestionText = row["q2"].ToString(),
                        ChoiceA = row["choiceAq2"].ToString(),
                        ChoiceB = row["choiceBq2"].ToString(),
                        ChoiceC = row["choiceCq2"].ToString(),
                        ChoiceD = row["choiceDq2"].ToString(),
                    });
                    questions.Add(new Question
                    {
                        QuestionText = row["q3"].ToString(),
                        ChoiceA = row["choiceAq3"].ToString(),
                        ChoiceB = row["choiceBq3"].ToString(),
                        ChoiceC = row["choiceCq3"].ToString(),
                        ChoiceD = row["choiceDq3"].ToString(),
                    });
                    questions.Add(new Question
                    {
                        QuestionText = row["q4"].ToString(),
                        ChoiceA = row["choiceAq4"].ToString(),
                        ChoiceB = row["choiceBq4"].ToString(),
                        ChoiceC = row["choiceCq4"].ToString(),
                        ChoiceD = row["choiceDq4"].ToString(),
                    });
                    questions.Add(new Question
                    {
                        QuestionText = row["q5"].ToString(),
                        ChoiceA = row["choiceAq5"].ToString(),
                        ChoiceB = row["choiceBq5"].ToString(),
                        ChoiceC = row["choiceCq5"].ToString(),
                        ChoiceD = row["choiceDq5"].ToString(),
                    });
                }

                rptQuestions.DataSource = questions;
                rptQuestions.DataBind();
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
                        username.Text = reader["userName"].ToString();
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


        protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var question = (Question)e.Item.DataItem;
                Label lblQuestion = (Label)e.Item.FindControl("lblQuestion");
                lblQuestion.Text = question.QuestionText;

                RadioButtonList rblChoices = (RadioButtonList)e.Item.FindControl("rblChoices");
                rblChoices.Items[0].Text = question.ChoiceA;
                rblChoices.Items[0].Value = "A";
                rblChoices.Items[1].Text = question.ChoiceB;
                rblChoices.Items[1].Value = "B";
                rblChoices.Items[2].Text = question.ChoiceC;
                rblChoices.Items[2].Value = "C";
                rblChoices.Items[3].Text = question.ChoiceD;
                rblChoices.Items[3].Value = "D";

            }
        }

        protected void FinishAttempt_Click(object sender, EventArgs e)
        {
            int totalQuestions = rptQuestions.Items.Count;
            int correctAnswers = 0;
            
            bool allAnswered = true;

            foreach (RepeaterItem item in rptQuestions.Items)
            {
                RadioButtonList rblChoices = (RadioButtonList)item.FindControl("rblChoices");
                if (rblChoices.SelectedValue == "")
                {
                    allAnswered = false;
                    break;
                }

                Label lblQuestion = (Label)item.FindControl("lblQuestion");
                string correctAnswer = GetCorrectAnswer(lblQuizTitle.Text, lblQuestion.Text);

                if (rblChoices.SelectedValue == correctAnswer)
                {
                    correctAnswers++;
                }
            }

            if (!allAnswered)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please answer all the questions.');", true);
            }
            else
            {
                int scoreValue = (correctAnswers * 100) / totalQuestions;
                score.Text = scoreValue.ToString();

                // Save the score and time into Quizzes_Score table
                SaveScore(username.Text, lblQuizTitle.Text, scoreValue);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Your score is: {scoreValue}');", true);
                Response.Redirect("User Quiz Dashboard.aspx");
            }
        }


        private string GetCorrectAnswer(string quizTitle, string questionText)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT q1, ansQ1, q2, ansQ2, q3, ansQ3, q4, ansQ4, q5, ansQ5 FROM Quizzes_Add WHERE title = @title";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", quizTitle);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (questionText == reader["q1"].ToString()) return reader["ansQ1"].ToString();
                    if (questionText == reader["q2"].ToString()) return reader["ansQ2"].ToString();
                    if (questionText == reader["q3"].ToString()) return reader["ansQ3"].ToString();
                    if (questionText == reader["q4"].ToString()) return reader["ansQ4"].ToString();
                    if (questionText == reader["q5"].ToString()) return reader["ansQ5"].ToString();
                }
            }
            return string.Empty;
        }

        private void SaveScore(string username, string quizTitle, int score)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QuizConnectionString"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Quizzes_Score (username, title, score) VALUES (@username, @title, @score)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@title", quizTitle);
                cmd.Parameters.AddWithValue("@score", score);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("User Quiz Dashboard.aspx");
        }

        protected void ProfilePicture_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User Profile.aspx");
        }

        protected void rptQuestions_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }

    public class Question
    {
        public string QuestionText { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
    }
}
