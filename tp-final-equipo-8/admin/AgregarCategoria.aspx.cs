using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using dominio;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        public int id;
        public string descripcion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                id = int.Parse(Request.Form["codigo"] ?? "0");
                descripcion = Request.Form["nombre"];
                var c = new dominio.Categoria
                {
                    Id = id,
                    Descripcion = descripcion
                };

                if (id > 0)
                {
                    if (!Negocio.Categorias.Editar(c))
                    {
                        Session["Msg_error"] = "No se ha podido actualizar la Categoria " + id;
                        return;
                    }
                    Session["Msg_ok"] = "Categoria actualizada con exito!";
                }else
                {
                    if (!Negocio.Categorias.Grabar(c))
                    {
                        Session["Msg_error"] = "No se ha podido grabar la Categoria " + id;
                        return;
                    }
                    Session["Msg_ok"] = "Categoria creada con exito!";
                }
                Response.Redirect("/admin/Categorias.aspx");

            }else
            {
                id = int.Parse(Request.QueryString["id"] ?? "0");
                descripcion = "";
                if (id > 0)
                {
                    var c = Negocio.Categorias.Leer(id);
                    if (c != null)
                    {
                        descripcion = c.Descripcion;
                    }
                }
            }
        }
    }
}