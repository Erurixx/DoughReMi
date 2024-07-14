using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace kay
{
    public partial class aForum : System.Web.UI.Page
    {
        private string connectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringInd"].ConnectionString;

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

                // Fetch posts
                SqlCommand cmdPosts = new SqlCommand("SELECT qId, question FROM qTable", conn);
                SqlDataAdapter daPosts = new SqlDataAdapter(cmdPosts);
                DataTable dtPosts = new DataTable();
                daPosts.Fill(dtPosts);

                // Create a DataTable to hold posts with their comments
                DataTable dtPostsWithComments = new DataTable();
                dtPostsWithComments.Columns.Add("PostID", typeof(int));
                dtPostsWithComments.Columns.Add("PostContent", typeof(string));
                dtPostsWithComments.Columns.Add("Comments", typeof(DataTable));

                foreach (DataRow postRow in dtPosts.Rows)
                {
                    int postId = Convert.ToInt32(postRow["qId"]);
                    string postContent = postRow["question"].ToString();

                    // Fetch comments for the current post
                    SqlCommand cmdComments = new SqlCommand("SELECT comment FROM aTable WHERE qId = @qId", conn);
                    cmdComments.Parameters.AddWithValue("@qId", postId);
                    SqlDataAdapter daComments = new SqlDataAdapter(cmdComments);
                    DataTable dtComments = new DataTable();
                    daComments.Fill(dtComments);

                    // Add comments to a new DataTable
                    DataTable dtCommentContent = new DataTable();
                    dtCommentContent.Columns.Add("CommentContent", typeof(string));

                    foreach (DataRow commentRow in dtComments.Rows)
                    {
                        DataRow newCommentRow = dtCommentContent.NewRow();
                        newCommentRow["CommentContent"] = commentRow["comment"].ToString();
                        dtCommentContent.Rows.Add(newCommentRow);
                    }

                    // Add post and comments to dtPostsWithComments
                    DataRow newPostRow = dtPostsWithComments.NewRow();
                    newPostRow["PostID"] = postId;
                    newPostRow["PostContent"] = postContent;
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
    }
}
