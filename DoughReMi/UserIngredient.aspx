<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserIngredient.aspx.cs" Inherits="DoughReMi.UserIngredient" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="UserIngredient.css" />
   
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>
                <asp:Label ID="Label1" runat="server" Text="Ingredients"></asp:Label>
            </h1>
            <p>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="grid-view">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" >
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:ImageField DataImageUrlField="Image" HeaderText="Image">
                        </asp:ImageField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IngredientConnectionString %>" SelectCommand="SELECT [Name], [Description], [Image] FROM [indTable]"></asp:SqlDataSource>
            </p>
        </div>
    </form>
</body>
</html>
