<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Main Page.aspx.cs" Inherits="DoughReMi.Admin_Main_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Dashboard</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <link rel="stylesheet" href="Admin.css" />
    <style type="text/css">
        .company-logo {
            height: 65px;
            width: 82px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Sidebar -->
        <nav id="sidebar">
            <div class="sidebar-header">
                <img src="assets\company-logo.jpeg" alt="Company Logo" class="company-logo" />
            </div>
        
            <ul class="list-unstyled components">
                <!-- User Management -->
                <li class="non-clickable">
                    <span class="label">User Management</span>
                    <ul class="list-unstyled">
                        <li>
                            <asp:HyperLink ID="HyperLinkManageUser" runat="server" NavigateUrl="Manage User.aspx">Manage User</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLinkManageAdmin" runat="server" NavigateUrl="Manage Admin.aspx">Manage Admin</asp:HyperLink>
                        </li>
                    </ul>
                </li>
                
                <!-- Content Management -->
                <li class="non-clickable">
                    <span class="label">Content Management</span>
                    <ul class="list-unstyled">
                        <li>
                            <asp:HyperLink ID="HyperLinkManageQuiz" runat="server" NavigateUrl="Admin Quiz Dashboard.aspx">Manage Quiz &amp; Assessments</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLinkManageForums" runat="server" NavigateUrl="Admin Forum.aspx">Manage Discussion Forums</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLinkManageMenu" runat="server" NavigateUrl="Admin Ingredient.aspx">Manage Ingredient</asp:HyperLink>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLinkManageVideos" runat="server" NavigateUrl="#manage-videos">Manage Videos</asp:HyperLink>
                        </li>
                    </ul>
                </li>
                
                
                
            </ul>    
        </nav>

        <!-- Page Content -->
        <div id="content">
            <!-- Top Header with Profile Picture and Username -->
            <header>
                <div class="profile">
                    <asp:ImageButton ID="ProfilePicture" runat="server" CssClass="profile-picture" ImageUrl="/assets/default-avatar.jpg" Height="43px" Width="43px" />
                    <asp:Label ID="usernamelbl" runat="server" CssClass="username"></asp:Label>
                </div>
            </header>
            
            <!-- Main Content Area -->
            <div class="main-content">
                <!-- Your main content goes here -->
                <h2>Welcome to Your Admin Dashboard</h2>
                <p>This is where you can manage users, content, and more.</p>
            </div>

            <!-- Info Boxes -->
                <div class="info-boxes">
                    <div class="info-box">
                        <h3>Total Registered Users</h3>
                        <asp:Label ID="lblRegisteredUsers" runat="server" CssClass="info-number"></asp:Label>
                    </div>

                    <div class="info-box">
                        <h3>Total Admins</h3>
                        <asp:Label ID="lblTotalAdmins" runat="server" CssClass="info-number"></asp:Label>
                    </div>

                    <div class="info-box">
                        <h3>Total Users</h3>
                        <asp:Label ID="lblTotalUsers" runat="server" CssClass="info-number"></asp:Label>
                    </div>


                    
                </div>
        </div>
    </form>
</body>
</html>
