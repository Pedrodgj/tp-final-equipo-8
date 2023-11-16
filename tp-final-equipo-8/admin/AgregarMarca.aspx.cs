using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class AgregarMarca : System.Web.UI.Page
    {
        public int id;
        public string descripcion;
        public string accion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                id = int.Parse(Request.QueryString["id"] ?? "0");
                accion = Request.QueryString["accion"];
                descripcion = "";
                if (id > 0)
                {
                    var m = Negocio.Marcas.Leer(id);
                    if (m != null) {
                        descripcion = m.Descripcion;
                    }
                }
            }
            else
            {
                id = int.Parse(Request.Form["codigo"]);
                descripcion = Request.Form["descripcion"];

                var m = new dominio.Marca
                {
                    Id = id,
                    Descripcion = descripcion
                }; 

                if (id > 0)
                {
                    if (!Negocio.Marcas.Editar(m)) 
                    {
                        Session["Msg_error"] = "No se pudo actualizar la Marca " + descripcion;
                        return;
                    }
                }else
                {
                    if (!Negocio.Marcas.Grabar(m))
                    {
                        Session["Msg_error"] = "No se pudo grabar la Marca " + descripcion;
                        return;
                    }
                }
                Session["Msg_ok"] = "Grabación realizada con éxito!";
                Response.Redirect("/Admin/Marcas.aspx");
            }
        }
    }
}