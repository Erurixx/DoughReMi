<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Quiz Dashboard.aspx.cs" Inherits="DoughReMi.AdminQuizDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Quiz Dashboard</title>
    <link rel="stylesheet" type="text/css" href="Admin Quiz dashboard.css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 1320px;
            height: 33px;
        }
        .auto-style3 {
            height: 33px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="page-title">
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
                        <ItemStyle Width="100px" />
                        <HeaderStyle Width="100px" />
                    </asp:BoundField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="button-container">
                                <asp:Button ID="btnView" runat="server" CommandArgument='<%# Eval("title") %>' Text="View" CssClass="btn" OnClick="View_Click" />
                                <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("title") %>' Text="Edit" CssClass="btn" OnClick="Edit_Click" />
                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("title") %>' Text="Delete" CssClass="btn" OnClick="Delete_Click" />
                            </div>
                        </ItemTemplate>
                         <ItemStyle Width="150px" />
                         <HeaderStyle Width="150px" />
                     </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">

                <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn" OnClick="Back_Click"/>

                </td>
                <td class="button-container">
                    <asp:Button ID="AddQuiz" runat="server" Text="Add New Quiz" CssClass="btn" OnClick="AddQuiz_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
