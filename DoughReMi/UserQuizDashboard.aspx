<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserQuizDashboard.aspx.cs" Inherits="WAPP_Assignment.Assignment.UserQuizDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Quiz Dashboard</title>
    <link rel="stylesheet" type="text/css" href="UserQuizDashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>User Quiz Dashboard</h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Hi, "></asp:Label>
                <asp:Label ID="username" runat="server"></asp:Label>
            </p>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="quiz-table" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="title" HeaderText="Title" />
                    <asp:BoundField DataField="difficult" HeaderText="Difficulty" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnAttempt" runat="server" CommandArgument='<%# Eval("title") %>' Text="Attempt" CssClass="btn" OnClick="Attempt_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
