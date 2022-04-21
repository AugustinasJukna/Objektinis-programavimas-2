<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="Lab5_WebApp.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <title>5 laboratorinis darbas</title>
    <style>
        .textboxes {
            margin-bottom: 20px;
        }

        .margin-bottom {
            margin-bottom: 20px;
        }

        #LinkButton1 {
            text-decoration: none;
            color: black;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1 class ="text-center" style ="margin-top: 25px"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">PRENUMERATŲ PAIEŠKA</asp:LinkButton>
        </h1>
        <div id="mainContainer" class="container" runat="server">
            <h3 id="errorLabel" runat="server" class="text-center" style="background-color: black; color: white; font-weight: bold; padding: 10px;"></h3>
              <asp:Panel ID="Panel1" runat="server" Visible="true">
                <h5 style="margin-top: 20px">Įveskite ieškomą mėnesį:</h5>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="textboxes" Width="255px"></asp:TextBox>
                <h5>Įveskite ieškomos įvedimo datos periodo pradžią:</h5>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="textboxes" Width="255px"></asp:TextBox>
                <h5>Įveskite ieškomos įvedimo datos periodo pabaigą:</h5>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="textboxes" Width="255px"></asp:TextBox>
                <br/>
              </asp:Panel>
            <div class="text-center">
            <asp:Button ID="Button1" runat="server" Text="Apskaičiuoti" CssClass="btn btn-outline-dark btn-lg margin-bottom" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="Surikiuoti" CssClass="btn btn-outline-dark btn-lg margin-bottom" Visible="false" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="Ištrinti" CssClass="btn btn-outline-dark btn-lg margin-bottom" Visible="false" OnClick="Button3_Click" />
            </div>
        </div>
    </form>
</body>
</html>
