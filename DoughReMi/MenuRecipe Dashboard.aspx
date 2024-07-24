<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuRecipe Dashboard.aspx.cs" Inherits="DoughReMi.MenuRecipe_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu & Recipe Dashboard</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="MRdashboard.css" />
    <link rel="stylesheet" href="Main Page.css" />
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

        <div class="dashboard">
            <h2>Menu & Recipe Dashboard</h2>
            <div class="recipe-list">
                <div class="recipe-item">
                    <a href="Fruit Tart.aspx">
                        <img src="assets\tart image.jpg" alt="Recipe 1" style="height: 192px; width: 254px" />
                        <h4>Fruit Tart</h4>
                        <p>A tart.</p>
                    </a>
                </div>
                <div class="recipe-item">
                    <a href="RecipeDetail.aspx?recipeId=2">
                        <img src="/assets/recipe2.jpg" alt="Recipe 2" />
                        <h4>Vanilla Cupcakes</h4>
                        <p>Light and fluffy vanilla cupcakes.</p>
                    </a>
                </div>
                <div class="recipe-item">
                    <a href="RecipeDetail.aspx?recipeId=3">
                        <img src="/assets/recipe3.jpg" alt="Recipe 3" />
                        <h4>Strawberry Cheesecake</h4>
                        <p>A creamy cheesecake with strawberry topping.</p>
                    </a>
                </div>
                <!-- Add more recipe items as needed -->
            </div>
        </div>
    </form>
</body>
</html>
