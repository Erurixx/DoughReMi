<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Forum.aspx.cs" Inherits="DoughReMi.AdminForum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <link rel="stylesheet" type="text/css" href="Admin forum.css" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <p>
                <asp:Button ID="back" runat="server" CssClass="back-btn" OnClick="back_Click1" Text="Back" />
            </p>
            <h1 class="auto-style2">Manage Discussion Forum</h1>
            <p class="auto-style2">&nbsp;</p>

            <asp:Repeater ID="RptAdminPosts" runat="server">
                <ItemTemplate>
                    <div class="admin-post-box">
                        <div class="admin-post-content">
                            <p><strong>Post:</strong> <%# Eval("PostContent") %></p>
                        </div>
                        <div class="admin-comments">
                            <h4>Comments:</h4>
                            <asp:Repeater ID="RptAdminComments" runat="server" DataSource='<%# Eval("Comments") %>'>
                                <ItemTemplate>
                                    <div class="admin-comment-box">
                                        <p><%# Eval("CommentContent") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="admin-post-actions">
                            <asp:Button ID="BtnDeletePost" runat="server" Text="Delete Post" CssClass="custom-button" CommandName="DeletePost" CommandArgument='<%# Eval("PostID") %>' OnCommand="BtnDeletePost_Command" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>