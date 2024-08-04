<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuRecipe_Dashboard.aspx.cs" Inherits="DoughReMi.MenuRecipe_Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu & Recipe Dashboard</title>
    <link rel="icon" href="assets/company-logo 32x32.jpeg" type="image/x-icon" />
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
                    <a href="User_Profile.aspx">Manage Profile</a>
                    <a href="Change_Password.aspx">Change Password</a>
                    <asp:LinkButton ID="LogoutLink" runat="server" OnClick="LogoutLink_Click">Log Out</asp:LinkButton>
                </div>
            </div>
        </nav>

        <div class="dashboard">
            <h2>Menu & Recipe Dashboard</h2>
            <div class="recipe-list">
                <!-- Add the Repeater control -->
                <asp:Repeater ID="RecipeRepeater" runat="server" OnItemCommand="RecipeRepeater_ItemCommand">
                    <ItemTemplate>
                        <div class="recipe-item">
                            <asp:ImageButton ID="RecipeImage" runat="server" ImageUrl='<%# Eval("MRimage") %>' 
                                Width="254px" Height="192px" CommandArgument='<%# Eval("MRname") %>' CommandName="ViewDetails" />
                            <div class="recipe-details">
                                <h3>
                                    <asp:LinkButton ID="RecipeName" runat="server" CommandArgument='<%# Eval("MRname") %>' CommandName="ViewDetails">
                                        <%# Eval("MRname") %>
                                    </asp:LinkButton>
                                </h3>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
