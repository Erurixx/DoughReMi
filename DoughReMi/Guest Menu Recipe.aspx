<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guest Menu Recipe.aspx.cs" Inherits="DoughReMi.Guest_Menu_Recipe" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guest Menu & Recipe Dashboard</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="MRdashboard.css" />
    <link rel="stylesheet" href="Main Page.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
            <div class="logo">
                <a href="Main Page.aspx">DoughReMi</a>
            </div>
            <ul class="topnav">
                <li class="dropdown">
                    <a href="Guest Menu Recipe.aspx">Menu & Recipes</a>    
                </li>
                <li><a href="Guest Ingredient.aspx">Ingredients</a></li>
                <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
            </ul>
            <div class="register-button">
                <a href="RegisterNew.aspx">Register</a>
            </div>
            <div class="login-button">
                <a href="Login.aspx" class="button">Login</a>
            </div>
        </nav>

        <div class="dashboard">
            <h2>Menu & Recipe Dashboard</h2>
            <div class="recipe-list">
                <!-- Add the Repeater control -->
                <asp:Repeater ID="RecipeRepeater" runat="server">
                    <ItemTemplate>
                        <div class="recipe-item">
                            <img src='<%# Eval("MRimage") %>' alt="Recipe Image" width="254px" height="192px" />
                            <h4><%# Eval("MRname") %></h4>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
