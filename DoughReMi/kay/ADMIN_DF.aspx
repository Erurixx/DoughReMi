<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ADMIN_DF.aspx.cs" Inherits="kay.ADMIN_DF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Discussion Forum</title>
    <link rel="stylesheet" type="text/css" href="ADMIN_DF.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Discussion Forum</h2>
            <asp:TextBox ID="txtNewPost" runat="server" TextMode="MultiLine" Rows="3" Width="776px"></asp:TextBox>
            <asp:Button ID="btnSubmitPost" runat="server" Text="Post" OnClick="btnSubmitPost_Click" />
            
            <asp:Repeater ID="rptPosts" runat="server" OnItemDataBound="rptPosts_ItemDataBound">
                <ItemTemplate>
                    <div class="post">
                        <p><strong>Post:</strong> <%# Eval("PostContent") %></p>
                        <asp:Repeater ID="rptComments" runat="server">
                            <ItemTemplate>
                                <div class="comment">
                                    <p><strong>Comment:</strong> <%# Eval("CommentContent") %></p>
                                    <asp:Button ID="btnDeleteComment" runat="server" Text="Delete Comment" CommandArgument='<%# Container.ItemIndex %>' OnClick="btnDeleteComment_Click" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnDeletePost" runat="server" Text="Delete Post" CommandArgument='<%# Eval("PostID") %>' OnClick="btnDeletePost_Click" />
                        <div class="comments">
                            <asp:TextBox ID="txtNewComment" runat="server" TextMode="MultiLine" Rows="2" Width="300px"></asp:TextBox>
                            <asp:Button ID="btnSubmitComment" runat="server" Text="Comment" CommandArgument='<%# Eval("PostID") %>' OnClick="btnSubmitComment_Click" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>