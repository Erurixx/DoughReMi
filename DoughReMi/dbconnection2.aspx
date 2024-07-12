<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbconnection2.aspx.cs" Inherits="DoughReMi.dbconnection2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IngredientConnectionString %>" SelectCommand="SELECT * FROM [aTable]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
