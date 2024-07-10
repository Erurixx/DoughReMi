<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserQuizAttempt.aspx.cs" Inherits="WAPP_Assignment.Assignment.UserQuizAttempt" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Quiz Attempt</title>
    <link rel="stylesheet" type="text/css" href="UserQuizAttempt.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Attempt Quiz: <asp:Label ID="lblQuizTitle" runat="server" /></h1>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Username : "></asp:Label>
                <asp:Label ID="username" runat="server"></asp:Label>
            </p>
            <p>
                <asp:Label ID="Label2" runat="server" Text="Score : "></asp:Label>
                <asp:Label ID="score" runat="server"></asp:Label>
            </p>
            <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
                <ItemTemplate>
                    <div class="question">
                        <asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("QuestionText") %>' />
                        <asp:RadioButtonList ID="rblChoices" runat="server">
                            <asp:ListItem Text="Choice A" Value="A" />
                            <asp:ListItem Text="Choice B" Value="B" />
                            <asp:ListItem Text="Choice C" Value="C" />
                            <asp:ListItem Text="Choice D" Value="D" />
                        </asp:RadioButtonList>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:Button ID="btnFinishAttempt" runat="server" Text="Finish Attempt" OnClick="btnFinishAttempt_Click" />
        </div>
    </form>
</body>
</html>
