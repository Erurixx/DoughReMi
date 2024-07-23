<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit Tart.aspx.cs" Inherits="DoughReMi.Menu_and_Recipe___Jas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu and Recipe</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <meta charset="utf-8" />
    <link rel="stylesheet" href="MR.css"/>
    <link rel="stylesheet" href="Main Page.css"/>
    
    <style type="text/css">
        .recipe-image {
            height: 312px;
            width: 365px;
        }
    </style>
    
</head>
<body>
    
    <form id="form1" runat="server">
        <nav id="desktop-nav">
        <div class="logo">
            <a href="Main Page After Logged In.aspx">DoughReMi</a>
        </div>
        <ul class="topnav">
            <li><a href="Menu and Recipe - Jas">Menu & Recipes</a></li>
            <li><a href="User Quiz Dashboard.aspx">Quiz & Assessments</a></li>
            <li><a href="User Ingredient.aspx">Ingredients</a></li>
            <li><a href="User Forum.aspx">Forums</a></li>
            <li><a href="#bookmark">Bookmark</a></li>
            <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
        </ul>

         <div class="profile">
            <asp:ImageButton ID="ProfilePicture" runat="server" CssClass="profile-picture" ImageUrl="/assets/default-avatar.jpg" OnClick="ProfilePicture_Click" Height="43px" Width="43px" />
            
            <asp:Label ID="usernamelbl" runat="server" CssClass="username"></asp:Label>

            <div id="profile-dropdown" class="dropdown-content">
                <a href="User Profile.aspx">Manage Profile</a>
                <a href="Change Password.aspx">Change Password</a>
                <asp:LinkButton ID="LogoutLink" runat="server" OnClick="LogoutLink_Click">Log Out</asp:LinkButton>
            </div>
        </div>
    </nav>
        <div id="content">
        <div class="menu-section">
            <h3>Menu</h3>
            <div class="menu-item">
                <h4>Fruit Tart</h4>
                <p>&nbsp;</p>
                <p style="width: 1347px">Fresh fruit slices and a sweet custard filling on top of a bite-sized cookie shell–these mini fruit tarts aren’t just beautiful, they’re delicious and refreshing. Growing up (and even now), fruit tarts were a big staple for birthday parties.</p>
                <p style="width: 1347px">&nbsp;</p>
               
                <img src="assets\tart image.jpg" alt="Recipe Image" class="recipe-image" /><br />
&nbsp;<div class="additional-description">
                    <p style="width: 1335px">Maybe it’s because the use of fruit on top of sugary custard gave some semblance of a healthier treat, at least more so than frosting and cake, but nevertheless, it was a delicious option. With this mini fruit tart recipe I can prep tarts ahead of time and make up any excuse to celebrate at home!</p>
                    <p style="width: 1335px">&nbsp;</p>
                </div>
                <div class="step-by-step">
                    <h3>Instructions</h3>
                     <ul style="list-style-type: none; padding-left: 0;">
                        <li><strong>Dough:</strong></li>
                        <li>1. In a stand mixer using the paddle attachment, combine the flour, salt, sugar, and butter. Mix on the lowest setting until the butter gets broken down into smaller pieces, about one minute of mixing. Add the egg yolks one at a time, then add the heavy cream and vanilla extract.</li>
                        <li>2. Mix on medium (setting 4 or 6) for about two minutes or until the mixture begins to look like crumbly sand. Test the dough by stopping the mixer and pinching some sandy dough between your fingers. If it sticks to itself and forms a piece of dough, you’re ready to knead. If it’s too dry, try adding one tablespoon of heavy cream at a time to adjust.</li>
                        <li>3. Remove the mixing bowl from the stand mixer and use your hand to form the sand into a ball of dough. I like to do this in the bowl because it’s less of a mess.</li>
                        <li>4. Scoop about three tablespoons of dough and use your hands to mold and flatten the dough straight into the tart molds. (Three tablespoons is about 60 grams of dough for a four-inch tart mold).</li>

                        <!-- Add more steps as needed -->
                    </ul>
                </div>

                <div class="video-preview">
            <h3>Recipe Video</h3>
            <iframe width="560" height="315" src="https://www.youtube.com/embed/nL1v55MUOio" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
        </div>

            </div>
        </div>

            
    </form>
</body>
</html>
