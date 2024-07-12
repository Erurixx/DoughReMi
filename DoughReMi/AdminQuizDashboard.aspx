<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminQuizDashboard.aspx.cs" Inherits="DoughReMi.AdminQuizDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Quiz Dashboard</title>
    <link rel="stylesheet" type="text/css" href="AdminQuizDashboard.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 1320px;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
            <div class="logo">
                <a href="Main Page.aspx">DoughReMi</a>
            </div>
            <ul class="topnav">
                <li><a href="#menu-recipe" class="dropbutton">Menu & Recipes</a></li>
                <li><a href="#quiz-assessments">Quiz & Assessments</a></li>
                <li><a href="#ingredients">Ingredients</a></li>
                <li><a href="#forums">Forums</a></li>
                <li><a href="#bookmark">Bookmark</a></li>
                <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
            </ul>
        </nav>

        <br />

            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn" OnClick="Back_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>

        <div class="dashboard-header">
            <h2>Admin Quiz Dashboard</h2>
        </div>

        <div class="form-container">
            <br />
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
                            <div class="button-container">
                                <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("title") %>' Text="Edit" CssClass="btn" OnClick="Edit_Click" />
                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("title") %>' Text="Delete" CssClass="btn" OnClick="Delete_Click" />
                            </div>
                        </ItemTemplate>
                         <ItemStyle Width="100px" />
                         <HeaderStyle Width="100px" />
                     </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
            <asp:Button ID="AddQuiz" runat="server" Text="Add New Quiz" CssClass="btn" OnClick="AddQuiz_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
