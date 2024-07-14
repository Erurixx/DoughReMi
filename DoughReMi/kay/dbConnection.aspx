<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dbConnection.aspx.cs" Inherits="kay.dbConnection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringInd %>" SelectCommand="SELECT * FROM [indTable]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
