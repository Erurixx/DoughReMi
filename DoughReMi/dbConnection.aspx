<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbConnection.aspx.cs" Inherits="WAPP_Assignment.dbConnector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Quizzes]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
