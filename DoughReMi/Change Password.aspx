<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change Password.aspx.cs" Inherits="DoughReMi.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>DoughReMi Change Password</title>
    <link rel="stylesheet" href="User Profile New.css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Change Password</h2>

            

            <!-- Change Password Section -->
            <div class="form-group">
                <asp:Label ID="lblCurrentPassword" runat="server" AssociatedControlID="txtCurrentPassword" Text="Current Password"></asp:Label>
                <asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your current password"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblNewPassword" runat="server" AssociatedControlID="txtNewPassword" Text="New Password"></asp:Label>
                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your new password"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword" Text="Confirm New Password"></asp:Label>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm your new password"></asp:TextBox>
            </div>

            <div class="form-group text-center">
                <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" CssClass="btn btn-primary" OnClick="btnChangePassword_Click" />
            </div>

            <!-- Back Button -->
            <div class="form-group">
            </div>
        </div>
    </form>
</body>
</html>
