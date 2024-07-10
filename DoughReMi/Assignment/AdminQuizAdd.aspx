<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminQuizAdd.aspx.cs" Inherits="WAPP_Assignment.Assignment.AdminQuizAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Quiz</title>
    <link rel="stylesheet" type="text/css" href="AdminQuizAdd.css" />
</head>
<body>
     <nav id="desktop-nav">
        <div class="logo">
            <a href="Main Page.aspx">DoughReMi</a>

        </div>
        <ul class="topnav">
            <li class="dropdown">
                <a href="#menu-recipe" class="dropbutton">Menu & Recipes</a>    
            </li>

            <li><a href="#quiz-assessments">Quiz & Assessments</a></li>
            <li><a href="#ingredients">Ingredients</a></li>
            <li><a href="#forums">Forums</a></li>
            <li><a href="#bookmark">Bookmark</a></li>
            <li><a href="#terms-condition">Terms and Condition</a></li>
        </ul>

        <div class="register-button">
            <a href=Register.aspx>Register</a>
        </div>
        <div class="login-button">
            <a href=Login.aspx class="button">Login</a>
        </div>
    </nav>
    <form id="form1" runat="server" class="form-container">
        <div>
            <h1>Add Quiz</h1>
            <table class="show">
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label1" runat="server" Text="Title : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="title" runat="server" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label2" runat="server" Text="Difficulty : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="difficulty" runat="server" AutoPostBack="True" CssClass="form-control" Width="115px">
                            <asp:ListItem>Easy</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Hard</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label3" runat="server" Text="Question 1 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="question1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label4" runat="server" Text="Choices for Question 1 : "></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="Label6" runat="server" Text="A : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceAq1" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label7" runat="server" Text="B : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceBq1" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label8" runat="server" Text="C : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceCq1" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label9" runat="server" Text="D : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceDq1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label5" runat="server" Text="Answer for Question 1: "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="ansQ1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label10" runat="server" Text="Question 2 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="question2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label11" runat="server" Text="Choices for Question 2 : "></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="Label22" runat="server" Text="A : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceAq2" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label23" runat="server" Text="B : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceBq2" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label24" runat="server" Text="C : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceCq2" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label25" runat="server" Text="D : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceDq2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label12" runat="server" Text="Answer for Question 2 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="ansQ2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label13" runat="server" Text="Question 3 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="question3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label14" runat="server" Text="Choices for Question 3 : "></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="Label26" runat="server" Text="A : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceAq3" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label27" runat="server" Text="B : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceBq3" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label28" runat="server" Text="C : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceCq3" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label29" runat="server" Text="D : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceDq3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label15" runat="server" Text="Answer for Question 3 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="ansQ3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label16" runat="server" Text="Question 4 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="question4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label17" runat="server" Text="Choices for Question 4 : "></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="Label30" runat="server" Text="A : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceAq4" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label31" runat="server" Text="B : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceBq4" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label32" runat="server" Text="C : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceCq4" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label33" runat="server" Text="D : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceDq4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label18" runat="server" Text="Answer for Question 4 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="ansQ4" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label19" runat="server" Text="Question 5 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="question5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label20" runat="server" Text="Choices for Question 5 : "></asp:Label>
                    </td>
                    <td class="auto-style1"><asp:Label ID="Label34" runat="server" Text="A : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceAq5" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label35" runat="server" Text="B : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceBq5" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label36" runat="server" Text="C : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceCq5" runat="server"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label37" runat="server" Text="D : "></asp:Label>
&nbsp;
                        <asp:TextBox ID="choiceDq5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="Label21" runat="server" Text="Answer for Question 5 : "></asp:Label>
                    </td>
                    <td class="auto-style1">
                        <asp:TextBox ID="ansQ5" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="cancel" runat="server" Text="Cancel" OnClick="cancel_Click" />
                    </td>
                    <td class="auto-style1">
                        <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="Add" CssClass="btn-submit"/>
                    </td>
                </tr>
            </table>
        </div>
        <br />
    </form>
</body>
</html>
