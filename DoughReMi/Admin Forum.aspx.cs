using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace DoughReMi
{
    public partial class AdminForum : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["IngredientConnectionString"].ConnectionString;

            if (!IsPostBack)
            {
                BindAdminPosts();
            }
        }

        protected void BindAdminPosts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Fetch posts with usernames, ordered by qId in descending order
                SqlCommand cmdPosts = new SqlCommand("SELECT qId, question, userName FROM qTable ORDER BY qId DESC", conn);
                SqlDataAdapter daPosts = new SqlDataAdapter(cmdPosts);
                DataTable dtPosts = new DataTable();
                daPosts.Fill(dtPosts);

                // Create a DataTable to hold posts with their comments
                DataTable dtPostsWithComments = new DataTable();
                dtPostsWithComments.Columns.Add("PostID", typeof(int));
                dtPostsWithComments.Columns.Add("PostContent", typeof(string));
                dtPostsWithComments.Columns.Add("PostUserName", typeof(string));
                dtPostsWithComments.Columns.Add("Comments", typeof(DataTable));

                foreach (DataRow postRow in dtPosts.Rows)
                {
                    int postId = Convert.ToInt32(postRow["qId"]);
                    string postContent = postRow["question"].ToString();
                    string postUserName = postRow["userName"].ToString();

                    // Fetch comments for the current post with usernames, ordered by comment ID in descending order
                    SqlCommand cmdComments = new SqlCommand("SELECT comment, userName FROM aTable WHERE qId = @qId", conn);
                    cmdComments.Parameters.AddWithValue("@qId", postId);
                    SqlDataAdapter daComments = new SqlDataAdapter(cmdComments);
                    DataTable dtComments = new DataTable();
                    daComments.Fill(dtComments);

                    // Add comments to a new DataTable
                    DataTable dtCommentContent = new DataTable();
                    dtCommentContent.Columns.Add("CommentContent", typeof(string));
                    dtCommentContent.Columns.Add("CommentUserName", typeof(string));

                    foreach (DataRow commentRow in dtComments.Rows)
                    {
                        DataRow newCommentRow = dtCommentContent.NewRow();
                        newCommentRow["CommentContent"] = commentRow["comment"].ToString();
                        newCommentRow["CommentUserName"] = commentRow["userName"].ToString();
                        dtCommentContent.Rows.Add(newCommentRow);
                    }

                    // Add post and comments to dtPostsWithComments
                    DataRow newPostRow = dtPostsWithComments.NewRow();
                    newPostRow["PostID"] = postId;
                    newPostRow["PostContent"] = postContent;
                    newPostRow["PostUserName"] = postUserName;
                    newPostRow["Comments"] = dtCommentContent;
                    dtPostsWithComments.Rows.Add(newPostRow);
                }

                // Bind data to the Repeater
                RptAdminPosts.DataSource = dtPostsWithComments;
                RptAdminPosts.DataBind();
            }
        }

        protected void BtnDeletePost_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeletePost")
            {
                int postId = Convert.ToInt32(e.CommandArgument);

                // Delete post and its associated comments
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Delete comments
                    SqlCommand cmdDeleteComments = new SqlCommand("DELETE FROM aTable WHERE qId = @qId", conn);
                    cmdDeleteComments.Parameters.AddWithValue("@qId", postId);
                    cmdDeleteComments.ExecuteNonQuery();

                    // Delete post
                    SqlCommand cmdDeletePost = new SqlCommand("DELETE FROM qTable WHERE qId = @qId", conn);
                    cmdDeletePost.Parameters.AddWithValue("@qId", postId);
                    cmdDeletePost.ExecuteNonQuery();
                }

                // Refresh the Repeater after deletion
                BindAdminPosts();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Implement any additional functionality if needed
        }

        protected void back_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Admin Main Page.aspx");
        }
    }
}
