<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="Individual.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1" crossorigin="anonymous">
</head>
<body>
        <form id="form1" runat="server">
            <div class="container">
                <div class ="col">
                <h1>REGISTRACIJA</h1><br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" ForeColor="Red" CssClass="alert alert-danger"/>
                    <br />
            <br />
            <h4>Vardas:
                    </h4>
            <asp:TextBox ID="TextBox1" runat="server" Width="306px" class="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas yra privaloma" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas gali būti tik iš lotyniškų raidžių" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate1"></asp:CustomValidator>
            <br />
            <h4>Pavardė:</h4>
            <asp:TextBox ID="TextBox2" runat="server" Width="307px" class="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Pavardė yra privaloma" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Pavardė gali būti tik iš lotyniškų raidžių" ForeColor="Red" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
            <br />
            <h4>Mokyklos pavadinimas:</h4>
            <asp:TextBox ID="TextBox3" runat="server" Width="307px" class="form-control" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Mokyklos pavadinimas yra privalomas" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Mokyklos pavadinimas gali būti tik iš lietuviškų raidžių" ForeColor="Red" OnServerValidate="CustomValidator3_ServerValidate"></asp:CustomValidator>
            <br />
            <h4>Amžius:</h4>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:RangeValidator runat="server" ControlToValidate="DropDownList1" ErrorMessage="Amžius yra privalomas" ForeColor="Red" MaximumValue="19" MinimumValue="7" Type="Integer">*</asp:RangeValidator>
            <br />
            <h4>Programavimo kalbos:</h4>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="pavadinimas" DataValueField="pavadinimas">
            </asp:CheckBoxList>
            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/kalbos.xml"></asp:XmlDataSource>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Height="45px" OnClick="Button1_Click" Text="Registruoti" Width="159px" class="btn btn-primary"/>
            <asp:Button ID="Button2" runat="server" Height="45px" OnClick="Button2_Click" Text="Ištrinti visus įrašus" Width="159px" class="btn btn-danger ms-5" CausesValidation="False"/>
                    <br />
            <br />
            <asp:Label ID="Label1" runat="server" padding="40"></asp:Label>
            <br />
            <br />
            </div>
                <div class="col">
                    <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="2px" Height="36px" Width="47px" CellPadding="10" CellSpacing="2" CssClass="table table-hover table-dark">
                    </asp:Table>
                </div>
        </form>
</body>
</html>
