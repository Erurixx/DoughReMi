using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class AdminIngredient : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString);
            string myquery = "SELECT * FROM indTable";
            SqlCommand cmd = new SqlCommand(myquery, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Bind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = (GridViewRow)GridView1.Rows[index];

            // Find controls
            Label labelID = (Label)row.FindControl("Label1Edit");
            TextBox textName = (TextBox)row.FindControl("TextBox1");
            TextBox textDescription = (TextBox)row.FindControl("TextBox2");
            FileUpload fu = (FileUpload)row.FindControl("FileUpload1");

            // Generate a unique filename
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = rand.Next(1, 1000);

            string link = "";
            if(fu.HasFile)
            {
                // Define allowed file extensions
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string fileExtension = Path.GetExtension(fu.FileName).ToLower();

                // Check if the selected file is an allowed image type
                if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    // Generate a unique filename
                    string fileName = Guid.NewGuid().ToString() + fileExtension;
                    string filePath = Server.MapPath("~/assets/") + fileName;

                    // Save the file to the server
                    fu.SaveAs(filePath);
                    link = "assets/" + fileName;
                }
                else
                {
                    // Display message if the selected file is not an allowed image type
                    
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                    return; // Exit the method without updating the database
                }
            }

            // Update the database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString);
            con.Open();

            string updatedata = "UPDATE indTable SET Name=@Name, Description=@Description" + (fu.HasFile ? ", Image=@Image" : "") + " WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(updatedata, con);
            cmd.Parameters.AddWithValue("@Name", textName.Text);
            cmd.Parameters.AddWithValue("@Description", textDescription.Text);
            if (fu.HasFile)
            {
                cmd.Parameters.AddWithValue("@Image", link);
            }
            cmd.Parameters.AddWithValue("@ID", labelID.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            // Exit edit mode and refresh data
            GridView1.EditIndex = -1;
            Bind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];

            Label labelID = (Label)row.FindControl("Label1");

            // Delete by ID
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM indTable WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", labelID.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Bind();
        }

        protected void Button1_Click(object sender, EventArgs e) //save button
        {
            if (FileUpload2.HasFile)
            {
                // Define allowed file extensions
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string fileExtension = Path.GetExtension(FileUpload2.FileName).ToLower();

                // Check if the selected file is an allowed image type
                if (Array.Exists(allowedExtensions, ext => ext == fileExtension))
                {
                    try
                    {
                        // Generate a unique filename
                        string fileName = Guid.NewGuid().ToString() + fileExtension;
                        string filePath = Server.MapPath("~/assets/") + fileName;

                        // Save the file to the server
                        FileUpload2.SaveAs(filePath);

                        // Insert into database
                        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
                        {
                            con.Open();
                            string insertQuery = "INSERT INTO indTable (Name, Description, Image) VALUES (@Name, @Description, @Image)";
                            SqlCommand cmd = new SqlCommand(insertQuery, con);
                            cmd.Parameters.AddWithValue("@Name", TextBox3.Text.Trim());
                            cmd.Parameters.AddWithValue("@Description", TextBox4.Text.Trim());
                            cmd.Parameters.AddWithValue("@Image", "assets/" + fileName); // Assuming assets folder structure

                            cmd.ExecuteNonQuery();
                        }

                        // Clear form fields
                        TextBox3.Text = "";
                        TextBox4.Text = "";
                        successMsg.Text = "Ingredient added successfully!";
                        successMsg.Visible = true;
                        errMsg.Visible = false;

                        // Refresh GridView
                        Bind();
                    }
                    catch (Exception ex)
                    {
                        // Display error message if upload or database insertion fails
                        errMsg.Text = "Error: " + ex.Message;
                        errMsg.Visible = true;
                        successMsg.Visible = false;
                    }
                }
                else
                {
                    // Display message if the selected file is not an allowed image type
                    errMsg.Text = "Only image files (jpg, jpeg, png, gif, bmp) are allowed.";
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                }
            }
            else
            {
                // Display message if no file selected
                errMsg.Text = "Please select a file!";
                errMsg.Visible = true;
                successMsg.Visible = false;
            }
        }

        protected void back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admin Main Page.aspx");

        }



    }
}