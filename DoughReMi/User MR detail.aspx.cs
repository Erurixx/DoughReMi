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
                    LoadRecipeDetails(mrName);
                }
            }
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
                        MRVideoPlaceholder.Controls.Add(new Literal
                        {
                            Text = $"<video width='300' height='200' controls><source src='{videoUrl}' type='video/mp4'>Your browser does not support the video tag.</video>"
                        });
                    }
                }
                conn.Close();
            }
        }
    }
}