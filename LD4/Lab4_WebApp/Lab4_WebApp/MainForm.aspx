<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Lab4_WebApp.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous">
    <title></title>
    <style>
        .margin-top {
            margin-top: 10%;
        }
        h3 {
            margin-top: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h3 class="text-center">LANKYTINŲ VIETŲ PAIEŠKOS</h3>
        <h3 class="text-center">
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </h3>
            <div class="container margin-top" id="MainContainer" runat="server">
            <div class =" row">
                <div class ="col">
            <asp:Button ID="Button1" runat="server" Height="50px" Text="Apskaičiuoti" Width="200px" CssClass="btn btn-outline-dark btn-lg" OnClick="Button1_Click" />
                </div>
                <div class ="col" id ="controlsColumn" runat="server">
                    <asp:Table ID="Table1" runat="server" CssClass="table table-hover table-dark" GridLines="Both" Visible="False">
                    </asp:Table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
