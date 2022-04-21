<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forma1.aspx.cs" Inherits="PirmasWeb.Forma1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pirmas puslapis</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        	<asp:Label ID="Label1" runat="server" BackColor="Black" ForeColor="White"></asp:Label>
			<br />
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
			<br />
			<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Gerai!" />
        </div>
    </form>
</body>
</html>
