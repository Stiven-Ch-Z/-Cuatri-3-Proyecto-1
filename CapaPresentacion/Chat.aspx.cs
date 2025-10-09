using Proyecto1.CapaNegocio;
using Proyecto1.CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1.CapaPresentacion
{
    public partial class Chat : System.Web.UI.Page
    {
        private MensajeNegocio negocio=new MensajeNegocio(); //se hace una instancia de la capa negocio para poder usar sus metodos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string alias=Request.QueryString["alias"]; //se recibe el alias del querystring

                lblAliasActual.Text = alias; //se le define el alias al label
                ViewState["Alias"]=alias; //se guarda para despues utilizarlo en otros eventos como eliminar o editar
                CargarMensaje();//para mostrar los mensajes actuales en la pagina
            }
        }
        private void CargarMensaje()
        {
            RepeaterMensajes.DataSource = negocio.Listar();//llama todos los mensajes guardados en la lista para que el repeater los utilize como fuente
            RepeaterMensajes.DataBind();// lo que muestra los mensajes en pantalla
        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtmensaje.Text))
            {
                txtmensaje.Focus(); //si el textbox esta vacio enfoca el textbox para que el usuario escriba algo
            }
            else 
            {
                var nuevo = new Mensaje //si el textbox tiene algo se crea un nuevo mensaje con el alias y el texto que se escribio
                {
                    Alias = ViewState["Alias"].ToString(),
                    Texto = txtmensaje.Text
                };
                negocio.Agregar(nuevo);
                txtmensaje.Text = "";//se agrega el nuevo mensaje a la lista y se limpia el textbox
                CargarMensaje();
            }
        }
        protected void RepeaterMensajes_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            string alias = ViewState["Alias"].ToString(); //se obtiene el alias guardado en el viewstate para usarlo en las operaciones de editar y eliminar

            switch (e.CommandName)
            {
                case "Editar":
                    // Guardar el ID del mensaje que se está editando
                    ViewState["EditarId"] = Convert.ToInt32(e.CommandArgument);//guarda el id del mensaje que se quiere editar para luego mostrar el textbox para editar el mensaje
                    CargarMensaje();
                    break;

                case "Guardar":
                    int idGuardar = Convert.ToInt32(e.CommandArgument);
                    var txtEditar = (System.Web.UI.WebControls.TextBox)e.Item.FindControl("txtEditar");
                    string nuevoTexto = txtEditar.Text;//toma el nuevo texto del textbox

                    if (!string.IsNullOrWhiteSpace(nuevoTexto)) //si el textbox no esta vacio actualiza el mensaje con el nuevo texto
                    {
                        negocio.Actualizar(idGuardar, alias, nuevoTexto);
                    }

                    ViewState["EditarId"] = null; //quita el modo de edicion
                    CargarMensaje();
                    break;

                case "Cancelar":
                    ViewState["EditarId"] = null;//quita el modo de edicion si se cancela
                    CargarMensaje();
                    break;

                case "Borrar":
                    int idBorrar = Convert.ToInt32(e.CommandArgument);
                    negocio.Eliminar(idBorrar, alias);//elimina el mensaje con el id y alias correspondiente
                    CargarMensaje();
                    break;
            }
        }
        protected void btnRegresar_Click( object sender, EventArgs e )
        {
            Context.Items["mensaje"] = "Regresando al menu principal";
            Server.Transfer("Default.aspx");
        }

    }
}