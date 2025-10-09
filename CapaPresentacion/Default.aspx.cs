using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlAlias.SelectedValue))
            {
                lblerror.Text = "Por favor selecciona un alias antes de continuar."; //validacion para evitar el ddl vacio
                return;
            }

            string alias = ddlAlias.SelectedValue; //mandar el alias al chat con querystring
            Response.Redirect($"Chat.aspx?alias={alias}");
        }
    }
}