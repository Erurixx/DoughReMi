<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User Quiz Dashboard.aspx.cs" Inherits="DoughReMi.UserQuizDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Quiz Dashboard</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="User Quiz Dashboard.css" />
        <!-- Title & Logo Font -->
    <link rel="stylesheet"
          href="https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap" />
    <!-- Body Font -->
    <link rel="stylesheet"
          href="https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap" />
    <script src="https://kit.fontawesome.com/014d9f8d85.js" crossorigin="anonymous"></script>
    <script src="User Quiz Dashboard.js"></script>
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
                </div>
            </div>
        </nav>
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn" OnClick="Back_Click" />

        <div class="dashboard-header">
            <h2>Quizzes Available</h2>
        </div>

            <div class="form-container">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="quiz-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>

                        <asp:BoundField DataField="title" HeaderText="Title">
                            <ItemStyle Width="300px" />
                            <HeaderStyle Width="300px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="difficult" HeaderText="Difficulty">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                    <asp:Button ID="Attempt" runat="server" CommandArgument='<%# Eval("title") %>' Text="Attempt" CssClass="btn" OnClick="Attempt_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <div class="dashboard-header">
            <h2>Quiz Attempted History</h2>
                </div>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="quiz-table" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    <Columns>

                        <asp:BoundField DataField="username" HeaderText="Username">
                            <ItemStyle Width="150px" />
                            <HeaderStyle Width="150px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="title" HeaderText="Quiz Title">
                            <ItemStyle Width="300px" />
                            <HeaderStyle Width="300px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="score" HeaderText="Score">
                            <ItemStyle Width="50px" />
                            <HeaderStyle Width="50px" />
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>
            </div>
        </form>

        <footer>
        <div class="footer-bottom">
            <p>&copy; 2024 DoughReMi. All rights reserved.</p>
        </div>
    </footer>

</body>

</html>
