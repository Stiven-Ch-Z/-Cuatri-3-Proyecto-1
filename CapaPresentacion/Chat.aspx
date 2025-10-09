<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Proyecto1.CapaPresentacion.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>FastChat</title>
    <link rel="stylesheet" type="text/css" href="Estilos/estilos.css" />
</head>
<body>
    <form id="form1" runat="server" class="contenedor-caja">
      <div class="caja-chat"> 
        <div class="chat-header">
                <h3>FastChat</h3>
                <p>Alias actual: <asp:Label ID="lblAliasActual" runat="server" CssClass="alias"></asp:Label></p>
            </div>
           <div class="mensajes" id="chatScroll">
                <asp:Repeater ID="RepeaterMensajes" runat="server" OnItemCommand="RepeaterMensajes_ItemCommand">
                    <ItemTemplate>
                        <div class='<%# ((string)Eval("Alias") == (string)ViewState["Alias"]) ? "burbuja-propia" : "burbuja-otro" %>'>
                            <%-- aqui dependiendo si el usuario tiene un alias diferente o es el mismo de lo mensajes previos van a posionarse en diferentes partes ya sea izquierda o derecha --%>
                            <p><%# Eval("Alias") %>:</p>
                            <p><%# Eval("Texto") %></p> <%-- aqui se crea los espacios donde se muestra el alias y el texto --%>
                            <small><%# ((DateTime)Eval("FechaHora")).ToString("HH:mm") %> <%# (bool)Eval("Editado") ? "(editado)" : "" %></small>
                            <%-- con esto se crea la hora tipo militar y checa si el texto fue editado creando el mensaje (editado) si --%>
                            <asp:Panel ID="PanelAcciones" runat="server" Visible='<%# (string)Eval("Alias") == (string)ViewState["Alias"] %>'>
                        <%--el panel es lo que permite ver los botones de editar y eliminar SOLO si el alias es el mismo del que escribio el mensaje --%>
                                <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="btn-mini" />
                                <asp:Button ID="btnEliminar" runat="server" Text="Borrar" CommandName="Borrar" CommandArgument='<%# Eval("Id") %>' CssClass="btn-mini btn-delete" />
                            </asp:Panel>
                            <asp:Panel ID="PanelEdicion" runat="server" Visible='<%# (int)Eval("Id") == (int)(ViewState["EditarId"] ?? -1) %>'>
                         <%-- con este panel se identifica si el mensaje que se esta editando si tiene el mismo id, para luego mostrar el txtbox para poder cambira el texto y sus botones --%>
                                <asp:TextBox ID="txtEditar" runat="server" Text='<%# Eval("Texto") %>' CssClass="txtMensaje"></asp:TextBox>
                                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CommandName="Guardar" CommandArgument='<%# Eval("Id") %>' CssClass="btn-mini" />
                                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CommandName="Cancelar" CssClass="btn-mini" />
                            </asp:Panel>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
          <div class="entrada_texto">
              <asp:TextBox ID="txtmensaje" runat="server" CssClass="txtMensaje" placeholder="Escribe su mensaje..."></asp:TextBox>
              <asp:Button ID="btnenviar" runat="server" Text="Enviar" CssClass="btn-enviar" OnClick="btnEnviar_Click" />
              <asp:Button ID="btnregresar" runat="server" Text="Regresar" CssClass="btn-volver" OnClick="btnRegresar_Click" />
          </div>
          

        
       </div>
    </form>
</body>
</html>
