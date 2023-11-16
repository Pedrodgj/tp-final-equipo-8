using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class Marcas : System.Web.UI.Page
    {
        public List<Marca> marcas;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                marcas = Negocio.Marcas.Listar();
                var id = int.Parse(Request.QueryString["id"] ?? "0");
                var accion = Request.QueryString["accion"] ?? "";
                if (id > 0 && accion == "borrar")
                {
                    if (Negocio.Marcas.Eliminar(id))
                    {
                        Session["Msg_ok"] = "Se ha eliminado la Marca con ID " + id;
                        Response.Redirect("/admin/Marcas.aspx");
                    }else {
                        Session["Msg_error"] = "No Se ha podido eliminado la Marca con ID " + id;
                    }
                }
            }
        }
    }
}