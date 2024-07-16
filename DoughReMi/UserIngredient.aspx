<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIngredient.aspx.cs" Inherits="DoughReMi.UserIngredient" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="UserIngredient.css" />
    
    <script src="UserIngredient.js"></script>
   
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
            <div class="logo">
                <a href="Main Page After Logged In.aspx">DoughReMi</a>
            </div>
            <ul class="topnav">
                <li><a href="#menu-recipe" >Menu & Recipes</a></li>
                <li><a href="UserQuizDashboard.aspx">Quiz & Assessments</a></li>
                <li><a href="UserIngredient.aspx">Ingredients</a></li>
                <li><a href="UserForum.aspx">Forums</a></li>
                <li><a href="#bookmark">Bookmark</a></li>
                <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
            </ul>

            <div class="profile">
                <asp:ImageButton ID="ProfilePicture" runat="server" CssClass="profile-picture" ImageUrl="/assets/default-avatar.jpg" OnClick="ProfilePicture_Click" Height="43px" Width="43px" />
                <asp:Label ID="usernamelbl" runat="server" CssClass="username"></asp:Label>
                <div id="profile-dropdown" class="dropdown-content">
                    <a href="User Profile.aspx">Manage Profile</a>
                    <a href="Change Password.aspx">Change Password</a>
                </div>
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
