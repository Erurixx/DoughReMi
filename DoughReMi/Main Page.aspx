<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main Page.aspx.cs" Inherits="DoughReMi.Main_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>DoughReMi Main Page</title>
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <meta charset="utf-8" />
    <meta name="viewport" content="initial-scale=1, width=device-width" />
    <script src="Main Page.js"></script>
    <!-- Others -->
    <link rel="stylesheet" href="MPAL New.css" />
    <!-- Title & Logo Font -->
    <link rel="stylesheet"
          href="https://fonts.googleapis.com/css2?family=Bebas+Neue&display=swap" />
    <!-- Body Font -->
    <link rel="stylesheet"
          href="https://fonts.googleapis.com/css2?family=Inter:wght@100..900&display=swap" />
    <script src="https://kit.fontawesome.com/014d9f8d85.js" crossorigin="anonymous"></script>
</head>

<body>

    <nav id="desktop-nav">
        <div class="logo">
            <a href="Main Page.aspx">DoughReMi</a>

        </div>
        <ul class="topnav">
            <li class="dropdown">
                <a href="Guest Menu Recipe.aspx">Menu & Recipes</a>    
            </li>

            
            <li><a href="Guest Ingredient.aspx">Ingredients</a></li>
            
            
            <li><a href="Terms and Condition.aspx">Terms and Condition</a></li>
        </ul>

        <div class="register-button">
            <a href="RegisterNew.aspx">Register</a>
        </div>
        <div class="login-button">
            <a href="Login.aspx" class="button">Login</a>
        </div>
    </nav>

    <section id="home">
        <div class="home-container">
            <div class="home-title ml11">
                <h1>Learn Anytime,<br></h1>
                <h2>Anywhere with Our<br>Baking<br>Platform</h2>
            </div>
        </div>
    </section>

    <section id="description">
        <div class="info">
            <div class="container">
                <div class="details-course">
                    <img class="course-img" alt="" src="assets/personalized-content.png">
                </div>
                <div class="explain-course">
                    <h1>Personalized Content</h1>
                    <p>We customize your learning experience. <br> And ensure you get the knowledge you want.</p>
                </div>
            </div>

            <div class="container">
                <div class="details-course">
                    <img class="everyone-img" alt="" src="assets/everyone.png">
                </div>
                <div class="explain-course">
                    <h1>Available For Everyone</h1>
                    <p>Learning is for everyone.<br>Our platform is open to all, anytime, anywhere.</p>
                </div>
            </div>

            <div class="container">
                <div class="details-course">
                    <img class="trusted-img" alt="" src="assets/trusted-content.png">
                </div>
                <div class="explain-course">
                    <h1>Trusted Content</h1>
                    <p>Trust our content. Learn confidently.</p>
                </div>
            </div>

            <div class="container">
                <div class="details-course">
                    <img class="trusted-img" alt="" src="assets/community.png">
                </div>
                <div class="explain-course">
                    <h1>Engage With Communities</h1>
                    <p>Connect with communities. Engage, learn, grow.</p>
                </div>
            </div>
        </div>
    </section>

    <section id="audience">
        <div class="audience-title">
            <h1>The Website is Perfect For...</h1>
        </div>
        <!-- Buttons -->
        <div class="button-group">
            <button class="button" onclick="showContent('parents-kids')">Parents & Kids</button>
            <button class="button" onclick="showContent('beginner-bakers')">Beginner Bakers</button>
            <button class="button" onclick="showContent('experienced-bakers')">Experience Bakers</button>
        </div>
        <!-- Contents -->
        <div id="parents-kids" class="audience-content">
            <div class="content-item">
                <img src="assets/student.jpg">
                <div class="content-text">
                    <h1>Parents & Kids</h1>
                    <p>
                        Our platform is designed to enhance your family baking experience. Whether you're looking to teach your kids new baking skills or deepen your own culinary knowledge, we offer the tools and content to support you. As parents and young bakers, you'll have access to features such as a kid-friendly recipe library, fun baking tutorials, community forums, ingredient guides, step-by-step instructions, and creative decorating ideas
                    </p>
                </div>
            </div>
        </div>

        <div id="beginner-bakers" class="audience-content">
            <div class="content-item">
                <img src="assets/teacher.jpg">
                <div class="content-text">
                    <h1>Beginner Bakers</h1>
                    <p>
                        Our platform is designed to make your introduction to baking enjoyable and stress-free. If you're new to baking and eager to learn, we offer the resources and support you need. As a beginner baker, you'll benefit from features such as beginner-friendly recipes, detailed video tutorials, interactive forums, basic baking techniques, step-by-step guides, and practical tips to help you succeed with every bake.
                    </p>
                </div>
            </div>
        </div>

        <div id="experienced-bakers" class="audience-content">
            <div class="content-item">
                <img src="assets/others.jpg">
                <div class="content-text">
                    <h1>Experienced Bakers</h1>
                    <p>
                        Our platform is designed to elevate your baking experience. Whether you want to explore new techniques or master classic recipes, we provide the tools and content to help you grow. As an enthusiastic baker, you'll have access to features such as an extensive recipe collection, advanced tutorials, vibrant community forums, in-depth ingredient guides, precise step-by-step instructions, and innovative decorating ideas.
                    </p>
                </div>
            </div>
        </div>
    </section>

    <footer>
        <div class="footer-container">
            <div class="footer-section-contact-info">
                <h1>Contact Us</h1>
                <p><a href="mailto:support@doughremi.com">Email: support@doughremi.com</a></p>
                <p>Phone: +6019-111-1111 </p>
                <p>
                    Address: DoughReMi @ Bukit Jalil City, 22, Persiaran Jalil Utama, <br>Bukit Jalil,
                    57000 Kuala Lumpur, Federal Territory of Kuala Lumpur
                </p><iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3984.158263181738!2d101.67038617480871!3d3.052269196923532!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31cc4bb78b2afe53%3A0xd85886d6a40d7dcb!2sZUS%20Coffee%20-%20Bukit%20Jalil!5e0!3m2!1sen!2smy!4v1716103419493!5m2!1sen!2smy"
                            width="400" height="300" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
        </div>

        <div class="footer-bottom">
            <p>&copy; 2024 DoughReMi. All rights reserved.</p>
        </div>
    </footer>

</body>
</html>
