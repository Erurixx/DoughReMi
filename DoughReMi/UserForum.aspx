<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForum.aspx.cs" Inherits="DoughReMi.UserForum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discussion Forum</title>
    <link rel="stylesheet" type="text/css" href="UserForum.css" />
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="auto-style1">Discussion Forum</h1>

            <!-- Form for posting new content -->
            <div class="post-form">
                <asp:TextBox ID="txtNewPost" runat="server" CssClass="custom-textbox" TextMode="MultiLine" Rows="3" placeholder="Write your post here..."></asp:TextBox>
                <asp:Button ID="BtnSubmitPost" runat="server" Text="Post" CssClass="custom-button post-button" OnClick="BtnSubmitPost_Click" />
                <br />
                <br />
            </div>

            <!-- Repeater for displaying posts -->
            <asp:Repeater ID="RptPosts" runat="server" OnItemDataBound="RptPosts_ItemDataBound">
                <ItemTemplate>
                    <div class="post-box">
                        <div class="post-content">
                            <p><strong>Post:</strong> <%# Eval("PostContent") %></p>
                        </div>
                        <div class="comments">
                            <asp:Repeater ID="rptComments" runat="server">
                                <ItemTemplate>
                                    <div class="comment">
                                        <%# Eval("CommentContent") %>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="comment-form">
                                <asp:TextBox ID="txtNewComment" runat="server" CssClass="custom-textbox" TextMode="MultiLine" Rows="2" placeholder="Write your comment here..."></asp:TextBox>
                                <asp:Button ID="BtnSubmitComment" runat="server" Text="Comment" CssClass="custom-button" CommandArgument='<%# Eval("PostID") %>' OnClick="BtnSubmitComment_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
