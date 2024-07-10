<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminQuizDashboard.aspx.cs" Inherits="WAPP_Assignment.Assignment.AdminQuizDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Quiz Dashboard</title>
    <link rel="stylesheet" type="text/css" href="AdminQuizDashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Quiz Dashboard</h1>
            <asp:Button ID="AddQuiz" runat="server" Text="Add New Quiz" CssClass="btn" OnClick="btnAddQuiz_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="quiz-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Title" />
                    <asp:BoundField DataField="difficult" HeaderText="Difficulty" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandArgument='<%# Eval("title") %>' Text="Edit" CssClass="btn" OnClick="btnEdit_Click" />
                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("title") %>' Text="Delete" CssClass="btn" OnClick="btnDelete_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
