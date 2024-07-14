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
    public partial class Manage_Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData();
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            BindGridView(SearchTextBox.Text.Trim());
        }

        private void BindGridView(string searchTerm = "")
        {
            try
            {

               
                string connectionString = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT Id, fname, lname, userName, email, gender FROM Register WHERE email LIKE '%@admin.com'";

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " AND (userName LIKE @searchTerm OR email LIKE @searchTerm)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    

                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No users found matching the search criteria.'); window.location = 'Manage Admin.aspx';", true);
                    }

                    UserGridView.DataSource = dt;
                    UserGridView.DataBind();
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        private void LoadUserData()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT Id, fname, lname, userName, email, gender FROM Register WHERE email LIKE '%@admin.com'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            UserGridView.DataSource = dt;
                            UserGridView.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void UserGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(UserGridView.DataKeys[rowIndex].Value); // Retrieve the ID from DataKeys

                DeleteUser(userId);
            }

            if (e.CommandName == "EditUser")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = UserGridView.Rows[index];
                string adminId = UserGridView.DataKeys[index].Value.ToString();
                Response.Redirect("Edit Admin.aspx?adminId=" + adminId);
            }
        }



        private void DeleteUser(int userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RegisterConnectionString"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string deleteQuery = "DELETE FROM Register WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", userId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User deleted successfully.');", true);
                            LoadUserData(); // Re-bind the GridView after deletion
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User deletion failed or user does not exist.');", true);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('An error occurred: {ex.Message}');", true);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Response.Redirect("Admin Main Page.aspx");
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add Admin.aspx");
        }


    }
}
