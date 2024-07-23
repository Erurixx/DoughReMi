<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User Bookmark.aspx.cs" Inherits="DoughReMi.User_Bookmark" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bookmark</title>
    <link rel="stylesheet" href="User Bookmark.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
            <div class="logo">
                <a href="Main Page After Logged In.aspx">DoughReMi</a>
            </div>
            <ul class="topnav">
                <li><a href="MenuRecipe Dashboard.aspx">Menu & Recipes</a></li>
                <li><a href="User Quiz Dashboard.aspx">Quiz & Assessments</a></li>
                <li><a href="User Ingredient.aspx">Ingredients</a></li>
                <li><a href="User Forum.aspx">Forums</a></li>
                <li><a href="User Bookmark.aspx">Bookmark</a></li>
                <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
            </ul>

            <div class="profile">
                <asp:ImageButton ID="ProfilePicture" runat="server" CssClass="profile-picture" ImageUrl="/assets/default-avatar.jpg" OnClick="ProfilePicture_Click" Height="43px" Width="43px" />
                
                <asp:Label ID="usernamelbl" runat="server" CssClass="username"></asp:Label>

                <div id="profile-dropdown" class="dropdown-content">
                    <a href="User Profile.aspx">Manage Profile</a>
                    <a href="Change Password.aspx">Change Password</a>
                    <asp:LinkButton ID="LogoutLink" runat="server" OnClick="LogoutLink_Click">Log Out</asp:LinkButton>
                </div>
            </div>
        </nav>

        <div class="bookmark-header">
            <h2>Bookmark</h2>
        </div>

        <div class="bookmark-list">
            <asp:GridView ID="BookmarkGridView" runat="server" CssClass="bookmark-table" AutoGenerateColumns="False" OnRowCommand="BookmarkGridView_RowCommand" OnSelectedIndexChanged="BookmarkGridView_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="MRname" HeaderText="Recipe Name" />
                    <asp:ImageField DataImageUrlField="MRimage" HeaderText="Image" ControlStyle-Width="100px" ControlStyle-Height="100px" />
                    <asp:ButtonField CommandName="ViewDetails" Text="View" ButtonType="Button"/>
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>

