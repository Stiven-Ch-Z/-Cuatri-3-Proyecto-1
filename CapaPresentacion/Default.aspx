<%@ Page Title="Home Page" Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyecto1._Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>Viajes Espaciales (examen)</title>
    <link rel="stylesheet" type="text/css" href="estilos/styles.css" />
</head>

<body>
    <form i="form1" runat="server">
    <div class="Seleccion_alias">
        <h1>¡Bienvenido a FastChat!</h1>
        <h2>¡Selecciona un apodo para comenzar!</h2>
        <hr />
        <div>
            <asp:Label ID="lblalias" runat="server" Text="⬇ Selecciona aqui ⬇" AssociatedControlID="ddlalias" />
            <br /><br />
            <asp:DropDownList ID="ddlplaneta" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Jorge El Curioso</asp:ListItem>
                <asp:ListItem>Esteban Quito</asp:ListItem>
                <asp:ListItem>Tilin</asp:ListItem>
                <asp:ListItem>Jimbo</asp:ListItem>
            </asp:DropDownList>
            <hr />
        </div>
        <div>
            <asp:Button ID="btnenviar" runat="server" Text="Siguiente" OnClick="btnEnviar_Click" />
        </div>
        <div>
            <asp:Label ID="lblmensaje" runat="server" />
        </div>
    </div>
   </form>
</body>
</html>
