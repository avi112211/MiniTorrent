<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Sign Up For AviTorrent<br />
        <br />
        Please fill the bellow fields:<br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Re-Password"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="RePassword" runat="server" TextMode="Password" Height="22px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Send" OnClick="Button1_Click"/>
        <br />
        <br />
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="RePassword" ErrorMessage="Passwords don't match" ForeColor="Red"></asp:CompareValidator>
        <br />
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Password have to be at least 4 char" ForeColor="Red" OnServerValidate="CustomValidator1_ServerValidate" SetFocusOnError="True"></asp:CustomValidator>
        <br />
        <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="Password have to be at least 4 char" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="Red" Text="Username already in use" Visible="False"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
