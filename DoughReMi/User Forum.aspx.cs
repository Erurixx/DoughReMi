using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class UserForum : System.Web.UI.Page
    {


        private string connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString;

            if (!IsPostBack)
            {
                LoadUserProfile();
                LoadProfilePicture();
                LoadPosts();
            }
        }

        protected void BtnSubmitPost_Click(object sender, EventArgs e)
        {
            string postContent = txtNewPost.Text.Trim();
            if (!string.IsNullOrEmpty(postContent))
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO qTable (question) VALUES (@question); SELECT SCOPE_IDENTITY()", conn);
                    cmd.Parameters.AddWithValue("@question", postContent);
                    int postId = Convert.ToInt32(cmd.ExecuteScalar());
                }

                txtNewPost.Text = string.Empty;
                LoadPosts();
            }
        }

        protected void BtnSubmitComment_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int postId = int.Parse(btn.CommandArgument);
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtNewComment = (TextBox)item.FindControl("txtNewComment");

            string commentContent = txtNewComment.Text.Trim();
            if (!string.IsNullOrEmpty(commentContent))
            {
                InsertComment(postId, commentContent);
                txtNewComment.Text = string.Empty; // Clear comment textbox after submitting a comment
                LoadPosts();
            }
        }

        protected void RptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptComments = (Repeater)e.Item.FindControl("rptComments");
                Post post = (Post)e.Item.DataItem;
                rptComments.DataSource = post.Comments;
                rptComments.DataBind();
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

        protected void ProfilePicture_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("User Profile.aspx");
        }
        private void LoadPosts()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT qId, question FROM qTable", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Post post = new Post
                    {
                        PostID = (int)reader["qId"],
                        PostContent = reader["question"].ToString(),
                        Comments = new List<Comment>()
                    };

                    posts.Add(post);
                }
                reader.Close();

                foreach (var post in posts)
                {
                    SqlCommand commentCmd = new SqlCommand("SELECT comment FROM aTable WHERE qId = @qId", conn);
                    commentCmd.Parameters.AddWithValue("@qId", post.PostID);
                    SqlDataReader commentReader = commentCmd.ExecuteReader();
                    while (commentReader.Read())
                    {
                        post.Comments.Add(new Comment
                        {
                            CommentContent = commentReader["comment"].ToString()
                        });
                    }
                    commentReader.Close();
                }
            }

            // Sort posts in descending order
            posts.Reverse();
            RptPosts.DataSource = posts;
            RptPosts.DataBind();
        }

        private void InsertComment(int postId, string commentContent)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO aTable (qId, comment) VALUES (@qId, @comment)", conn);
                cmd.Parameters.AddWithValue("@qId", postId);
                cmd.Parameters.AddWithValue("@comment", commentContent);
                cmd.ExecuteNonQuery();
            }
        }

        public class Post
        {
            public int PostID { get; set; }
            public string PostContent { get; set; }
            public List<Comment> Comments { get; set; }
        }

        public class Comment
        {
            public string CommentContent { get; set; }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Response.Redirect("Main Page After Logged In.aspx");
        }
    }
}

