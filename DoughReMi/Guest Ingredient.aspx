<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guest Ingredient.aspx.cs" Inherits="DoughReMi.Guest_Ingredient" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Guest Ingredient</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="Guest Ingredient.css" />
    <link rel="stylesheet" href="Main Page.css" />
    <script src="User Ingredient.js"></script>
   
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

        <div class="container">
            <h1>
                <asp:Label ID="Label1" runat="server" Text="Ingredients"></asp:Label>
            </h1>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="grid-view">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IngredientConnectionString %>" SelectCommand="SELECT [Name], [Description], [Image] FROM [indTable] ORDER BY [Name]"></asp:SqlDataSource>
            </p>
        </div>

        
    </form>

    <footer>
        <div class="footer-bottom">
            <p>&copy; 2024 DoughReMi. All rights reserved.</p>
        </div>
    </footer>
</body>
</html>