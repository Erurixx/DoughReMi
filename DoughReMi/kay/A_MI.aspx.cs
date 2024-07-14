using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI.WebControls;

namespace kay
{
    public partial class A_MI : System.Web.UI.Page
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString);
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

            Random rand = new Random((int)DateTime.Now.Ticks);
            int numIterations = rand.Next(1, 1000);

            string link = "";
            if (fu.HasFile)
            {
                string fileName = numIterations + Path.GetFileName(fu.FileName);
                fu.SaveAs(Server.MapPath("~/assets/") + fileName);
                link = "assets/" + fileName;
            }

            // Update the database
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString);
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

            //exit and update data
            GridView1.EditIndex = -1;
            Bind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];

            Label labelID = (Label)row.FindControl("Label1");

            // delete by id
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString);
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
                try
                {
                    // Generate a unique filename
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload2.FileName);
                    string filePath = Server.MapPath("~/assets/") + fileName;

                    // Save the file to the server
                    FileUpload2.SaveAs(filePath);

                    // Insert into database
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString);
                    con.Open();

                    string insertQuery = "INSERT INTO indTable (Name, Description, Image) VALUES (@Name, @Description, @Image)";
                    SqlCommand cmd = new SqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@Name", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Description", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Image", "assets/" + fileName); // Assuming assets folder structure

                    cmd.ExecuteNonQuery();
                    con.Close();

                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    successMsg.Text = "Ingredient added successfully!";
                    successMsg.Visible = true;

                    Bind(); // Refresh GridView
                }
                catch (Exception ex)
                {
                    // Display error message if upload or database insertion fails
                    errMsg.Text = "Error: " + ex.Message;
                    errMsg.Visible = true;
                }
            }
            else
            {
                // Display message if no file selected
                errMsg.Text = "Please select a file!";
                errMsg.Visible = true;
            }
        }

        
    }
}
