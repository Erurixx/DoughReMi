using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class Admin_Menu_Recipe : System.Web.UI.Page
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
            string myquery = "SELECT * FROM MenuRecipe";
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
            FileUpload vd = (FileUpload)row.FindControl("FileUpload4");

            // Generate a unique filename
            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = rand.Next(1, 1000);

            string imageUrl = "";
            string videoUrl = "";
            
            if (fu.HasFile)
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
                    imageUrl = "assets/" + fileName;
                }
                else
                {
                    // Display message if the selected file is not an allowed image type
                    errMsg.Text = "Only image files (jpg, jpeg, png, gif, bmp) are allowed.";
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                    return; // Exit the method without updating the database
                }
            }

            if (vd.HasFile)
            {
                // Define allowed file extensions
                string[] allowedVideoExtensions = { ".mp4" };
                string videoFileExtension = Path.GetExtension(vd.FileName).ToLower();

                // Check if the selected file is an allowed video type
                if (Array.Exists(allowedVideoExtensions, ext => ext == videoFileExtension))
                {
                    try
                    {
                        // Generate a unique filename for the video
                        string videoFileName = Guid.NewGuid().ToString() + videoFileExtension;
                        string videoPath = Server.MapPath("~/assets/") + videoFileName;

                        // Save the video to the server
                        vd.SaveAs(videoPath);
                        videoUrl = "assets/" + videoFileName;
                    }
                    catch (Exception ex)
                    {
                        errMsg.Text = "Error uploading video: " + ex.Message;
                        errMsg.Visible = true;
                        successMsg.Visible = false;
                        return;
                    }
                }
                else
                {
                    errMsg.Text = "Only video files (mp4) are allowed.";
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                    return;
                }
            }

            // Update the database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString);
            con.Open();

            string updatedata = "UPDATE MenuRecipe SET MRname=@MRname, MRdescription=@MRdescription" + 
                (fu.HasFile ? ", MRimage=@MRimage" : "") + (vd.HasFile ? ", MRvideourl=@MRvideourl" : "") + " WHERE ID=@ID";
            SqlCommand cmd = new SqlCommand(updatedata, con);
            cmd.Parameters.AddWithValue("@MRname", textName.Text);
            cmd.Parameters.AddWithValue("@MRdescription", textDescription.Text);
            if (fu.HasFile)
            {
                cmd.Parameters.AddWithValue("@MRimage", imageUrl);
            }
            if (vd.HasFile)
            {
                cmd.Parameters.AddWithValue("@MRvideourl", videoUrl);
            }
            cmd.Parameters.AddWithValue("@ID", labelID.Text);
            cmd.ExecuteNonQuery();

            con.Close();

            // Register the JavaScript to show the success message and redirect
            string script = "alert('Menu and Recipe updated successful!');";
            ScriptManager.RegisterStartupScript(this, GetType(), "AddAlert", script, true);

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
            SqlCommand cmd = new SqlCommand("DELETE FROM MenuRecipe WHERE ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", labelID.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            Bind();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string imageUrl = "";
            string videoUrl = "";

            // Check if FileUpload2 has a file
            if (FileUpload2.HasFile)
            {
                // Define allowed image extensions
                string[] allowedImageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
                string imageFileExtension = Path.GetExtension(FileUpload2.FileName).ToLower();

                // Check if the selected file is an allowed image type
                if (Array.Exists(allowedImageExtensions, ext => ext == imageFileExtension))
                {
                    try
                    {
                        // Generate a unique filename for the image
                        string imageFileName = Guid.NewGuid().ToString() + imageFileExtension;
                        string imagePath = Server.MapPath("~/assets/") + imageFileName;

                        // Save the image to the server
                        FileUpload2.SaveAs(imagePath);
                        imageUrl = "assets/" + imageFileName;
                    }
                    catch (Exception ex)
                    {
                        errMsg.Text = "Error uploading image: " + ex.Message;
                        errMsg.Visible = true;
                        successMsg.Visible = false;
                        return;
                    }
                }
                else
                {
                    errMsg.Text = "Only image files (jpg, jpeg, png, gif, bmp) are allowed.";
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                    return;
                }
            }

            // Check if FileUpload3 has a file
            if (FileUpload3.HasFile)
            {
                // Define allowed video extensions
                string[] allowedVideoExtensions = { ".mp4" };
                string videoFileExtension = Path.GetExtension(FileUpload3.FileName).ToLower();

                // Check if the selected file is an allowed video type
                if (Array.Exists(allowedVideoExtensions, ext => ext == videoFileExtension))
                {
                    try
                    {
                        // Generate a unique filename for the video
                        string videoFileName = Guid.NewGuid().ToString() + videoFileExtension;
                        string videoPath = Server.MapPath("~/assets/") + videoFileName;

                        // Save the video to the server
                        FileUpload3.SaveAs(videoPath);
                        videoUrl = "assets/" + videoFileName;
                    }
                    catch (Exception ex)
                    {
                        errMsg.Text = "Error uploading video: " + ex.Message;
                        errMsg.Visible = true;
                        successMsg.Visible = false;
                        return;
                    }
                }
                else
                {
                    errMsg.Text = "Only video files (mp4) are allowed.";
                    errMsg.Visible = true;
                    successMsg.Visible = false;
                    return;
                }
            }

            // Insert into database
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString))
            {
                con.Open();
                string insertQuery = "INSERT INTO MenuRecipe (MRname, MRdescription, MRimage, MRvideourl) VALUES (@MRname, @MRdescription, @MRimage, @MRvideourl)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@MRname", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@MRdescription", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@MRimage", imageUrl);
                cmd.Parameters.AddWithValue("@MRvideourl", videoUrl);

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

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin Main Page.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
