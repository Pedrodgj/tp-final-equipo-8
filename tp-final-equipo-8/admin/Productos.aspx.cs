using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class Productos : System.Web.UI.Page
    {
        public List<Articulo> articulos;
        public string linkId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                articulos = Articulos.Listar();
            }

            var id = int.Parse(Request.QueryString["id"] ?? "0");

            if (id > 0)
            {
                if (!Articulos.Eliminar(id))
                {
                    Session["Msg_error"] = "No se pudo eliminar el producto " + id;
                    return;
                }
                Session["Msg_ok"] = "No se pudo eliminar el producto " + id;
                Response.Redirect("/admin/Productos.aspx"); // Para eliminar el Query string de la URL
            }
        }

        protected void lnkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/admin/AgregarProducto.aspx?id=" + linkId);
        }
    }
}