<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Lab_1_WebApp.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <title></title>
    <style>
        .class{
            padding: 300px;
        }

        .right-padding {
            padding-left: 500px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container class">
            <h1 class="text-center">SKORPIONO PAIEŠKOS</h1>
        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="fileName" DataValueField="fileName" CssClass="alert-success">
        </asp:DropDownList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/Data.xml"></asp:XmlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Išspręsti" CssClass="btn btn-outline-success btn-lg" />
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" CssClass="table table-success  table-hover" GridLines="Both">
            </asp:Table>
        <p>
            &nbsp;</p>
            <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
        <asp:Table ID="Table1" runat="server" GridLines="Both" CssClass="table table-success table-hover">
        </asp:Table>
            </div>
    </form>
</body>
</html>


