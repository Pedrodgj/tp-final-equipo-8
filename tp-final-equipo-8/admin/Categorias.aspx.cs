using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class Categorias : System.Web.UI.Page
    {
        public List<dominio.Categoria> categorias;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                categorias = Negocio.Categorias.Listar();
            }

            var id = int.Parse(Request.QueryString["id"] ?? "0");

            if (id > 0)
            {
                if (!Negocio.Categorias.Eliminar(id)) 
                {
                    Session["Msg_error"] = "No se pudo eliminar la Categoria " + id;
                    return;
                }
                Session["Msg_ok"] = "No se pudo eliminar la Categoria " + id;
                Response.Redirect("/admin/Categorias.aspx"); // Para eliminar el Query string de la URL
            }
        }
    }
}