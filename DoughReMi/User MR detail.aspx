<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User MR detail.aspx.cs" Inherits="DoughReMi.User_MR_detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Recipe Detail</title>
    <link rel="stylesheet" href="MRDashboard.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="recipe-detail">
            <h2><asp:Label ID="MRNameLabel" runat="server"></asp:Label></h2>
            <asp:Image ID="MRImage" runat="server" />
            <p><asp:Label ID="MRDescriptionLabel" runat="server"></asp:Label></p>
            <asp:PlaceHolder ID="MRVideoPlaceholder" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>