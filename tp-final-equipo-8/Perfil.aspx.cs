using System;
using System.Security.Cryptography;

namespace tp_carrito_compras_equipo_20
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_Usuario"] == null)
            {
                Response.Redirect("/InicioSesion.aspx");
            }

            if (this.IsPostBack)
            {
                Session["ID_Usuario"] = null;
                Session["Usuario"] = null;
                Response.Redirect("/InicioSesion.aspx");
            }
        }
    }
}