<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminForum.aspx.cs" Inherits="DoughReMi.AdminForum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Panel</title>
    <link rel="stylesheet" type="text/css" href="Admin FOrum.css" />
    <style type="text/css">
        .auto-style2 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">  
            <ul class="topnav">   
                <li class="dropdown">
                    <a href="#content-management" class="dropbutton">User Management</a>
                    <div class="dropdown-content">
                        <a href="Manage User.aspx">Manage User</a>
                        <a href="Manage Admin.aspx">Manage Admin</a>
                    </div>
                </li>
                <li class="dropdown">
                    <a href="#content-management" class="dropbutton">Content Management</a>
                        <div class="dropdown-content">
                            <a href="Admin Quiz Dashboard.aspx">Manage Quiz & Assessments</a>
                            <a href="Admin Forum.aspx">Manage Discussion Forums</a>
                            <a href="Admin Ingredient.aspx">Manage Ingredient</a>
                            <a href="Admin Menu Recipe.aspx">Manage Menu & Recipe</a>
                        </div>
                    </li>
                <li>
                    <br />
                </li>
            </ul>    
        </nav>
        <br />
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
                            <p><strong><%# Eval("PostUserName") %>:</strong> <%# Eval("PostContent") %></p>
                        </div>
                        <div class="admin-comments">
                            <h4>Comments:</h4>
                            <asp:Repeater ID="RptAdminComments" runat="server" DataSource='<%# Eval("Comments") %>'>
                                <ItemTemplate>
                                    <div class="admin-comment-box">
                                        <p><strong><%# Eval("CommentUserName") %>:</strong> <%# Eval("CommentContent") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="admin-post-actions">
                            <asp:Button ID="BtnDeletePost" runat="server" Text="Delete Post" CssClass="custom-button" CommandName="DeletePost" CommandArgument='<%# Eval("PostID") %>' OnCommand="BtnDeletePost_Command" OnClientClick="return confirm('Are you sure you want to delete this forum?');"/>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
