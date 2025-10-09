<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto1._Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Proyecto-1</title>
    <link rel="stylesheet" type="text/css" href="Estilos/estilos.css" />
</head>

<body>
    <form i="form1" runat="server">
    <div class="panel">
        <h1>¡Bienvenido a FastChat!</h1>
        <h2>¡Primero selecciona un apodo!</h2>
        <hr />
        <div>
            <asp:Label ID="lblalias" runat="server" Text="⬇ Elije aqui ⬇" CssClass="Droplista" AssociatedControlID="ddlAlias" />
            <br /><br />
            <asp:DropDownList ID="ddlAlias" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Jorge El Curioso</asp:ListItem>
                <asp:ListItem>Esteban Quito</asp:ListItem>
                <asp:ListItem>Tilin</asp:ListItem>
                <asp:ListItem>Jimbo</asp:ListItem>
            </asp:DropDownList>
            <hr />
        </div>
        <div>
            <asp:Button ID="btnenviar" runat="server" Text="Siguiente" CssClass="btn" OnClick="btnEnviar_Click" />
        </div>
        <div>
            <asp:Label ID="lblerror" runat="server" />
        </div>
    </div>
   </form>
</body>
</html>
