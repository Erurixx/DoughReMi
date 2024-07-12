<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Manage Admin.aspx.cs" Inherits="DoughReMi.Manage_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Admin</title>
    <link rel="stylesheet" href="ManageContent.css" />
    <link rel="stylesheet" href="User Profile New.css"/>
    <link rel="stylesheet" href="Main Page.css" />
    <style type="text/css">
        
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <nav id="desktop-nav">  
        <ul class="topnav">   
            <li class="dropdown">
                    <a href="#content-management" class="dropbutton">User Management</a>
                    <div class="dropdown-content">
                        <a href="Manage User.aspx">Manage User</a>
                        <a href="Manage Admin.aspx">Manage Admin</a>
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

        <div class="admin-container">
            
            <asp:Button ID="AddUserButton" runat="server" Text="Add New User" OnClick="AddUserButton_Click" CssClass="btn btn-primary" />

            <div class="search-container">
                <asp:TextBox ID="SearchTextBox" runat="server" CssClass="search-box" placeholder="Search by Username or Email" Height="40px" Width="278px"></asp:TextBox>
                <asp:Button ID="SearchButton" runat="server" Text="Search" OnClick="SearchButton_Click" CssClass="btn btn-primary" />
            </div>


            <asp:GridView ID="UserGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="UserGridView_RowCommand" DataKeyNames="Id" CssClass="user-grid" Width="1415px">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="User ID" />
                    <asp:BoundField DataField="fname" HeaderText="First Name" />
                    <asp:BoundField DataField="lname" HeaderText="Last Name" />
                    <asp:BoundField DataField="userName" HeaderText="Username" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="gender" HeaderText="Gender" />
                    
                    <asp:ButtonField ButtonType="Button" CommandName="DeleteUser" Text="Delete" ItemStyle-CssClass="delete-button"/>
                </Columns>
            </asp:GridView>
        </div>

        <div class="form-group text-center">
                <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn btn-primary" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>

