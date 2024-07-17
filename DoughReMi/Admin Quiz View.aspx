<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin Quiz View.aspx.cs" Inherits="DoughReMi.AdminQuizView" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Quiz</title>
    <link rel="stylesheet" type="text/css" href="Admin Quiz View.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="page-title">
            <h2>Admin Quiz Dashboard</h2>
        </div>
        <br />
        <div class="form-container">
            <asp:Label ID="titleLabel" runat="server" Text="Title : " CssClass="title-label"></asp:Label>
            <asp:Label ID="title" runat="server" CssClass="title-value"></asp:Label>
            <br />
            <br />
            <asp:Label ID="difficultyLabel" runat="server" Text="Difficulty : " CssClass="difficulty-label"></asp:Label>
            <asp:Label ID="difficulty" runat="server" CssClass="difficulty-value"></asp:Label>
            <br />
            <br />
            <div class="question-container">
                <asp:Label ID="Label2" runat="server" Text="Question 1 : " CssClass="question-label"></asp:Label>
                <asp:Label ID="q1" runat="server" CssClass="question-value"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Choices for Question 1 : " CssClass="choices-label"></asp:Label>
                <div class="choices-container">
                    <asp:Label ID="Label6" runat="server" Text="A : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice1a" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label7" runat="server" Text="B : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice1b" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label8" runat="server" Text="C : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice1c" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label9" runat="server" Text="D : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice1d" runat="server" CssClass="choice-value"></asp:Label>
                </div>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Answer for Question 1: " CssClass="answer-label"></asp:Label>
                <asp:Label ID="ansq1" runat="server" CssClass="answer-value"></asp:Label>
            </div>

            <div class="question-container">
                <asp:Label ID="Label5" runat="server" Text="Question 2 : " CssClass="question-label"></asp:Label>
                <asp:Label ID="q2" runat="server" CssClass="question-value"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label10" runat="server" Text="Choices for Question 2 : " CssClass="choices-label"></asp:Label>
                <div class="choices-container">
                    <asp:Label ID="Label22" runat="server" Text="A : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice2a" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label23" runat="server" Text="B : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice2b" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label24" runat="server" Text="C : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice2c" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label25" runat="server" Text="D : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice2d" runat="server" CssClass="choice-value"></asp:Label>
                </div>
                <br />
                <asp:Label ID="Label11" runat="server" Text="Answer for Question 2: " CssClass="answer-label"></asp:Label>
                <asp:Label ID="ansq2" runat="server" CssClass="answer-value"></asp:Label>
            </div>

            <div class="question-container">
                <asp:Label ID="Label12" runat="server" Text="Question 3 : " CssClass="question-label"></asp:Label>
                <asp:Label ID="q3" runat="server" CssClass="question-value"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label13" runat="server" Text="Choices for Question 3 : " CssClass="choices-label"></asp:Label>
                <div class="choices-container">
                    <asp:Label ID="Label26" runat="server" Text="A : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice3a" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label27" runat="server" Text="B : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice3b" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label28" runat="server" Text="C : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice3c" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label29" runat="server" Text="D : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice3d" runat="server" CssClass="choice-value"></asp:Label>
                </div>
                <br />
                <asp:Label ID="Label14" runat="server" Text="Answer for Question 3: " CssClass="answer-label"></asp:Label>
                <asp:Label ID="ansq3" runat="server" CssClass="answer-value"></asp:Label>
            </div>

            <div class="question-container">
                <asp:Label ID="Label15" runat="server" Text="Question 4 : " CssClass="question-label"></asp:Label>
                <asp:Label ID="q4" runat="server" CssClass="question-value"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label16" runat="server" Text="Choices for Question 4 : " CssClass="choices-label"></asp:Label>
                <div class="choices-container">
                    <asp:Label ID="Label30" runat="server" Text="A : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice4a" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label31" runat="server" Text="B : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice4b" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label32" runat="server" Text="C : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice4c" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label33" runat="server" Text="D : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice4d" runat="server" CssClass="choice-value"></asp:Label>
                </div>
                <br />
                <asp:Label ID="Label17" runat="server" Text="Answer for Question 4: " CssClass="answer-label"></asp:Label>
                <asp:Label ID="ansq4" runat="server" CssClass="answer-value"></asp:Label>
            </div>

            <div class="question-container">
                <asp:Label ID="Label18" runat="server" Text="Question 5 : " CssClass="question-label"></asp:Label>
                <asp:Label ID="q5" runat="server" CssClass="question-value"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label19" runat="server" Text="Choices for Question 5 : " CssClass="choices-label"></asp:Label>
                <div class="choices-container">
                    <asp:Label ID="Label34" runat="server" Text="A : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice5a" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label35" runat="server" Text="B : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice5b" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label36" runat="server" Text="C : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice5c" runat="server" CssClass="choice-value"></asp:Label>
                    <br />
                    <asp:Label ID="Label37" runat="server" Text="D : " CssClass="choice-label"></asp:Label>
                    <asp:Label ID="choice5d" runat="server" CssClass="choice-value"></asp:Label>
                </div>
                <br />
                <asp:Label ID="Label20" runat="server" Text="Answer for Question 5: " CssClass="answer-label"></asp:Label>
                <asp:Label ID="ansq5" runat="server" CssClass="answer-value"></asp:Label>
            </div>

            <br />
            <asp:Button ID="Back" runat="server" Text="Back to Previous Page" OnClick="Back_Click" CssClass="back-button" />
        </div>
    </form>
</body>
</html>
