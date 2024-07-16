<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterNew.aspx.cs" Inherits="DoughReMi.RegisterNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DoughReMi Register Page</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="RegisterNew.css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <section class="login-section">
            <div class="container">
                <div class="wrap">
                    <div class="img">
                       <img src = "assets\baking-gif-login.gif"; style="height:787px; width:522px">
                    </div>

                    <div class="login-wrap">
                        <h3 class="mb-4">Hello, New User!</h3>
                        <div class="form-group-inline">
                            <div class="form-group">
                                <label for="fname">First Name</label>
                                <asp:TextBox ID="fname" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="firstnameRequired" runat="server" ControlToValidate="fname" ErrorMessage="First Name is required" CssClass="text-danger" />
                            </div>
                            <div class="form-group">
                                <label for="lname">Last Name</label>
                                <asp:TextBox ID="lname" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="lastnameRequired" runat="server" ControlToValidate="lname" ErrorMessage="Last Name is required" CssClass="text-danger" />
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="userEmail">Email</label>
                            <asp:TextBox ID="email" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            <asp:CustomValidator ID="emailValidator" runat="server" ControlToValidate="email" ErrorMessage="Email is required and must be in a valid format" CssClass="text-danger" OnServerValidate="ValidateEmail" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <label for="gender">Gender</label>
                            <asp:DropDownList ID="gender" runat="server" CssClass="form-control">
                            <asp:ListItem Value="" Disabled="true" Selected="true"></asp:ListItem>
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                            <asp:ListItem Value="other">Other</asp:ListItem>
                        </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="userName">Username</label>
                            <asp:TextBox ID="username" runat="server" CssClass="form-control" Placeholder="Please Enter Your Username" required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="usernameRequired" runat="server" ControlToValidate="username" ErrorMessage="Username is required" CssClass="text-danger" />
                            <asp:CustomValidator ID="usernameValidator" runat="server" ControlToValidate="username" ErrorMessage="Username is required" CssClass="text-danger" OnServerValidate="ValidateRequiredField" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <label for="passWord">Password</label>
                            <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Please Enter Your Password" required="true"></asp:TextBox>
                            <asp:CustomValidator ID="passwordValidator" runat="server" ControlToValidate="password" ErrorMessage="Password is required and must be at least 8 characters long, containing at least one uppercase letter, one number, and one special character" CssClass="text-danger" OnServerValidate="ValidatePassword" Display="Dynamic" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="Register" runat="server" CssClass="form-control btn btn-primary rounded submit" Text="Register" OnClick="RegisterButton_Click" />
                        </div>
                        <p class="text-center">Already An Existing User? <a href="Login.aspx">Login</a></p>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
