<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoughReMi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DoughReMi Login Page</title>
    <link rel="stylesheet" href="Login.css" /> 
</head>
<body>
    <form id="form1" runat="server">
        <section class="login-section">
            <div class="container">
                <div class="wrap">
                    <div class="img">
                        <img src = "assets\baking-gif-login.gif"; style="height: 612px; width: 463px">

                    </div>
                    <div class="login-wrap">
                        <h3 class="mb-4">Welcome Back!</h3>
                        <div class="form-group">
                            <label for="username">Username</label>
                            <asp:TextBox ID="username" runat="server" CssClass="form-control" Placeholder="Please Enter Your Username" required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="usernameRequired" runat="server" ControlToValidate="username" ErrorMessage="Username is required" CssClass="text-danger" />
                        </div>
                        <div class="form-group">
                            <label for="password">Password</label>
                            <asp:TextBox ID="password" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Please Enter Your Password" required="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="passwordRequired" runat="server" ControlToValidate="password" ErrorMessage="Password is required" CssClass="text-danger" />
                        </div>
                        <div class="form-group">
                            <asp:Button ID="SignInButton" runat="server" CssClass="form-control btn btn-primary rounded submit" Text="Login" OnClick="SignInButton_Click" />
                        </div>
                        <p class="text-center">Not a member? <a href="RegisterNew.aspx">Sign Up</a></p>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
