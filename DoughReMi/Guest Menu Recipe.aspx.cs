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
    public partial class Guest_Menu_Recipe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRecipeData();
        }

        private void LoadRecipeData()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
            {
                string query = "SELECT MRname, MRimage FROM MenuRecipe";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                RecipeRepeater.DataSource = reader;
                RecipeRepeater.DataBind();
            }
        }
    }
}