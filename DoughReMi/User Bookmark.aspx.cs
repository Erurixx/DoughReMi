using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class User_Bookmark : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserProfile();
                LoadBookmarks();
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

        private void LoadBookmarks()
        {
            string userName = usernamelbl.Text;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
            {
                string query = "SELECT b.MRname, m.MRimage FROM Bookmark b INNER JOIN MenuRecipe m ON b.MRname = m.MRname WHERE b.userName = @userName";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userName", userName);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                BookmarkGridView.DataSource = dt;
                BookmarkGridView.DataBind();
            }
        }

        protected void BookmarkGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = BookmarkGridView.Rows[index];
                string mrName = selectedRow.Cells[0].Text;

                Response.Redirect("User MR detail.aspx?MRname=" + mrName);
            }
        }



        protected void ProfilePicture_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User Profile.aspx");
        }

        protected void LogoutLink_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Log Out Successful!'); window.location ='Login.aspx';", true);
        }

        protected void BookmarkGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}