<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Terms and Condition.aspx.cs" Inherits="DoughReMi.Terms_and_Condition" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8" />
    <link rel="icon" href="assets\company-logo 32x32.jpeg" type="image/x-icon" />
    <title>Terms & Conditions</title>
    <link rel="stylesheet" href="terms and condition.css">
    <link rel="stylesheet" href="User Profile New.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="full-page">
            <div class="terms-text">
                <h2>Terms & Conditions</h2>
                <p>Last Edit: 09/07/2024</p>
                <p>Greetings Users,</p>
                <p>
                    Welcome to DOUGHREMI! These terms and conditions outline the rules and regulations for the use of our website.
                    By accessing this website, we assume you accept these terms and conditions in full. Do not continue to use DOUGHREMI's website if you do not accept all of the terms and conditions stated on this page.
                </p>
                <br>
                <p>&bull; This Agreement shall begin on the date hereof.</p>
                <br>
                <p>&bull; Certain parts of this website offer the opportunity for users to post and exchange opinions, information, material, and data ('Comments') in areas of the website. DOUGHREMI does not screen, edit, publish, or review Comments prior to their appearance on the website, and Comments do not reflect the views or opinions of DOUGHREMI, its agents, or affiliates. Comments reflect the view and opinion of the person who posts such a view or opinion. To the extent permitted by applicable laws DOUGHREMI shall not be responsible or liable for the Comments or for any loss cost, liability, damages, or expenses caused and or suffered as a result of any use of and/or posting of and/or appearance of the Comments on this website.</p>
                <br>
                <p>&bull; DOUGHREMI reserves the right to monitor all Comments and to remove any Comments which it considers in its absolute discretion to be inappropriate, offensive, or otherwise in breach of these Terms and Conditions.</p>
            </div>

            <div class="form-group text-center">
                <asp:Button ID="btnBack" runat="server" Text="Back to Previous Page" CssClass="btn btn-primary" OnClick="btnBack_Click" />
            </div>
        </div>
    </form>
</body>
</html>
