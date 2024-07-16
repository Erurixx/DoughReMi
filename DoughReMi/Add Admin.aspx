<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add Admin.aspx.cs" Inherits="DoughReMi.Add_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Add Admin</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="User Profile New.css"/>
     
    
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Add Admin</h2>

            

            <!-- Profile Picture Upload Section -->
            <div class="form-group text-center">
                <asp:Image ID="imgProfilePic" runat="server" CssClass="img-thumbnail mb-3 avatar-img" ImageUrl="/assets/default-avatar.jpg" Height="102px" Width="109px" />
                <asp:Label ID="lblProfilePic" runat="server" Text="File upload size not more than 5MB, only JPG or PNG" CssClass="avatar-help"></asp:Label>
                <asp:FileUpload ID="fuProfilePic" runat="server" CssClass="form-control mt-2" OnChange="UploadProfilePicture"/>
            </div>

            <div class="form-group">
                <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" Text="First Name"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Enter your first name"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Enter your last name"></asp:TextBox>
            </div>

            

            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" Text="Email Address"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email address"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblUsername" runat="server" AssociatedControlID="txtUsername" Text="Username"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter your username"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="gender">Gender</label>
                <asp:DropDownList ID="txtgender" runat="server" CssClass="form-control">
                    <asp:ListItem Value="" Disabled="true" Selected="true"></asp:ListItem>
                    <asp:ListItem Value="male">Male</asp:ListItem>
                    <asp:ListItem Value="female">Female</asp:ListItem>
                    <asp:ListItem Value="other">Other</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group text-center">
            <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn btn-primary" OnClick="btnBack_Click" />
                <asp:Button ID="btnUpdateProfile" runat="server" Text="Add Admin" CssClass="btn btn-primary" OnClick="btnAddProfile_Click" /> 
            </div>
        </div>

        
    </form>
</body>
</html>
