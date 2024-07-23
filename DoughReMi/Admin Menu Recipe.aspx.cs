using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

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
            // Binding logic here
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
            Response.Redirect("Admin_Main_Page.aspx");
        }
    }
}
