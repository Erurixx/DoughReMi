<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Main Page.aspx.cs" Inherits="DoughReMi.Admin_Main_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Dashboard</title>
    <link rel="stylesheet" href="Admin Main Page.css" />
    <link rel="stylesheet" href="Main Page.css" />
</head>
<body>
    <form id="form1" runat="server">
        <nav id="desktop-nav">
        
        <ul class="topnav">
            

            
            <li class="dropdown">
                    <a href="#content-management" class="dropbutton">User Management</a>
                    <div class="dropdown-content">
                        <a href="Manage User.aspx">Manage User</a>
                        <a href="#manage-">Manage Admin</a>
                    </div>
                </li>
            <li class="dropdown">
                    <a href="#content-management" class="dropbutton">Content Management</a>
                    <div class="dropdown-content">
                        <a href="#manage">Manage Quiz & Assessments</a>
                        <a href="#manage-">Manage Discussion Forums</a>
                        <a href="#manage">Manage Menu & Recipes</a>
                        <a href="#manage">Manage Videos</a>
                    </div>
                </li>
        </ul>    
    </nav>
        
            

        <div class="dashboard">
            
            <div class="dashboard-cards">
                <div class="card">
                    <h2>Total Users</h2>
                    <p>150</p>
                </div>
                <div class="card">
                    <h2>Active Users</h2>
                    <p>120</p>
                </div>
                <div class="card">
                    <h2>New Posts</h2>
                    <p>30</p>
                </div>
                <div class="card">
                    <h2>Reports</h2>
                    <p>5</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
