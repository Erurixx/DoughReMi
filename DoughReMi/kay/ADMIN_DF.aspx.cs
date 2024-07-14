using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace kay
{
    public partial class ADMIN_DF : System.Web.UI.Page
    {
        private string connectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString;

            if (!IsPostBack)
            {
                LoadPosts();
            }
        }

        protected void btnSubmitPost_Click(object sender, EventArgs e)
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

        protected void btnSubmitComment_Click(object sender, EventArgs e)
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

        protected void btnDeletePost_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int postId = Convert.ToInt32(btn.CommandArgument);

            // Delete post and associated comments
            DeletePostAndComments(postId);

            // Reload posts after deletion
            LoadPosts();
        }

        protected void btnDeleteComment_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            int commentIndex = item.ItemIndex;

            // Assuming rptComments is the parent Repeater of btnDeleteComment
            Repeater rptComments = (Repeater)item.Parent;
            RepeaterItem parentItem = (RepeaterItem)rptComments.NamingContainer;

            // Get the post ID from the parent Repeater (rptPosts)
            int postId = (int)DataBinder.Eval(parentItem.DataItem, "PostID");

            // Delete the specific comment
            DeleteComment(postId, commentIndex);

            // Reload posts after deletion
            LoadPosts();
        }

        protected void rptPosts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptComments = (Repeater)e.Item.FindControl("rptComments");
                Post post = (Post)e.Item.DataItem;
                rptComments.DataSource = post.Comments;
                rptComments.DataBind();
            }
        }

        private void LoadPosts()
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT qId, question FROM qTable ORDER BY qId DESC", conn);
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

            rptPosts.DataSource = posts;
            rptPosts.DataBind();
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

        private void DeletePostAndComments(int postId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Delete comments first
                SqlCommand deleteCommentsCmd = new SqlCommand("DELETE FROM aTable WHERE qId = @qId", conn);
                deleteCommentsCmd.Parameters.AddWithValue("@qId", postId);
                deleteCommentsCmd.ExecuteNonQuery();

                // Delete post
                SqlCommand deletePostCmd = new SqlCommand("DELETE FROM qTable WHERE qId = @qId", conn);
                deletePostCmd.Parameters.AddWithValue("@qId", postId);
                deletePostCmd.ExecuteNonQuery();
            }
        }

        private void DeleteComment(int postId, int commentIndex)
        {
            // Assuming you have a way to identify comments uniquely (e.g., comment ID in database)

            // Example: Implement deletion logic for comments
            // using (SqlConnection conn = new SqlConnection(connectionString))
            // {
            //     conn.Open();
            //     SqlCommand deleteCommentCmd = new SqlCommand("DELETE FROM aTable WHERE commentId = @commentId", conn);
            //     deleteCommentCmd.Parameters.AddWithValue("@commentId", commentId);
            //     deleteCommentCmd.ExecuteNonQuery();
            // }
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
    }
}