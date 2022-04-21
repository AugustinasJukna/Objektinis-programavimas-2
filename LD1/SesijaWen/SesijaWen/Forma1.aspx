<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="SesijaWen.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" Text="Naujas įrašas"></asp:Label>
			<br />
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Įvesti" />
			<br />
			<br />
			<asp:Label ID="Label2" runat="server" Text="Egzistuojantys įrašai:"></asp:Label>
			<asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px" Height="145px" Width="537px">
			</asp:Table>
        </div>
    </form>
</body>
</html>
