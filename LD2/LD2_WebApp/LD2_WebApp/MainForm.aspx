<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="LD2_WebApp.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl" crossorigin="anonymous">
    <style>
        .textboxes {
            margin-bottom: 17px;
        }
        #Label {
            margin-top: 40px;
        }

        .main {
            margin-top:45px;
        }

        #header {
            margin-top:30px;
        }

    </style>
</head>
<body class="bg-dark text-white">
    <form id="form1" runat="server">
        <div class="container">
            <h3 id="header"class="text-center">MARŠRUTŲ PAIEŠKOS</h3>
            <div class="row align-items-start main">
                <div class="col">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="White" CssClass="alert alert-danger" DisplayMode="List" Font-Bold="True" ForeColor="Red" />
                 <br />
            <h5>Įveskite pradinį miestą:</h5>
                <asp:TextBox ID="TextBox1" CssClass="textboxes" runat="server" Height="35px" Width="300px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="TextBox1" Display="None" ErrorMessage="Miesto pavadinimas negali turėti skaičių, skyriklių ar specialiųjų simbolių." ForeColor="Red" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br />
            <h5>Įveskite didžiausią leistiną gyventojų kiekį mieste:</h5>
                <asp:TextBox ID="TextBox2" CssClass="textboxes" runat="server" Height="35px" Width="300px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Turi būti įvestas sveikasis skaičius" OnServerValidate="CustomValidator1_ServerValidate" Display="None" ForeColor="Red"></asp:CustomValidator>
            <br />
            <h5>Įveskite minimalų maršruto atstumą kilometrais:</h5>
                <asp:TextBox ID="TextBox3" CssClass="textboxes" runat="server" Height="35px" Width="300px"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TextBox3" Display="None" ErrorMessage="Privaloma įvesti sveikąjį skaičių" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Surasti" CssClass="btn btn-light" />
                    <br />
                    <h5 runat="server" visible="false" id="Label">Miestas, kurio nenorite aplankyti:</h5>
                    <asp:TextBox ID="TextBox4" runat="server" Height="35px" Visible="False" Width="300px" CssClass="textboxes"></asp:TextBox>
                    <asp:CustomValidator ID="CustomValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Miesto pavadinimas negali turėti skaičių, skyriklių ar specialiųjų simbolių." ForeColor="Red" Display="None" OnServerValidate="CustomValidator4_ServerValidate"></asp:CustomValidator>
                    <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ištrinti" Visible="False" CssClass="btn btn-light" />
            </div>
            <div class="col">
                <asp:Table ID="Table1" runat="server" GridLines="Both" Visible="False" CellPadding="1" CellSpacing="1" CssClass="table table-primary table-striped table-hover" BorderStyle="Solid">
            </asp:Table>
                <asp:Table ID="Table2" runat="server" GridLines="Both" Visible="False" CellPadding="1" CellSpacing="1" CssClass="table table-primary table-striped table-hover" BorderStyle="Solid">
            </asp:Table>
                <asp:Table ID="Table3" runat="server" GridLines="Both" Visible="False" CellPadding="1" CellSpacing="1" CssClass="table table-primary table-striped table-hover" BorderStyle="Solid">
            </asp:Table>
                <asp:Table ID="Table4" runat="server" GridLines="Both" Visible="False" CellPadding="1" CellSpacing="1" CssClass="table table-primary table-striped table-hover">
            </asp:Table>
            </div>
                </div>
        </div>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="None" ErrorMessage="Privaloma įvesti pradinį miestą" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="None" ErrorMessage="Privaloma įvesti didžiausią leistiną gyventojų kiekį mieste" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="None" ErrorMessage="Privaloma įvesti minimalų maršruto atstumą kilometrais" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="CustomValidator5" runat="server" Display="None" ErrorMessage="Trūksta duomenų failo/failų!" ForeColor="Red" OnServerValidate="CustomValidator5_ServerValidate"></asp:CustomValidator>
        </p>
    </form>
</body>
</html>
