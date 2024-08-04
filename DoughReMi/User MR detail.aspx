<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User MR detail.aspx.cs" Inherits="DoughReMi.User_MR_detail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Recipe Detail</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="User MR details.css" />
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

        <div class="recipe-detail">
            <h2 class="recipe-title"><asp:Label ID="MRNameLabel" runat="server" Text="Recipe Title"></asp:Label></h2>
            <div class="recipe-description"><asp:Label ID="MRDescriptionLabel" runat="server" Text="Recipe description goes here."></asp:Label></div>
            <asp:Image ID="MRImage" runat="server" CssClass="recipe-image" />
            <div class="recipe-video">
                <asp:PlaceHolder ID="MRVideoPlaceholder" runat="server"></asp:PlaceHolder>
            </div>
            <div class="additional-images">
                <asp:Image ID="AdditionalImage1" runat="server" CssClass="additional-image" />
                <asp:Image ID="AdditionalImage2" runat="server" CssClass="additional-image" />
                <asp:Image ID="AdditionalImage3" runat="server" CssClass="additional-image" />
            </div>
            <asp:Button ID="Bookmark" runat="server" OnClick="Bookmark_Click" Text="Add to bookmark" CssClass="btn" />
        </div>
    </form>
</body>
</html>
