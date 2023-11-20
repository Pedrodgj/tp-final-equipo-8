using dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
            } else
            {
                Usuario usuario = (Usuario)Session["Usuario"];
                ListarCompras(usuario.Id);
            }

            if (this.IsPostBack)
            {
                Session["ID_Usuario"] = null;
                Session["Usuario"] = null;
                Response.Redirect("/InicioSesion.aspx");
            }
        }

        private List<Compra> ListarCompras(int IdUsuario)
        {
            List<Compra> comprasUsuario = new List<Compra>();
            List<Compra> compras;
            compras = Compras.ListarCompraPorUsuario(IdUsuario);

            foreach (Compra compra in compras)
            {
                compra.Detalles = ListarDetalles(compra.Id);
                comprasUsuario.Add(compra);
            }

            return comprasUsuario;
        }

        private List<DetalleCompra> ListarDetalles(int IdCompra)
        {
            List<DetalleCompra> detalleCompra;
            detalleCompra = Compras.ListarDetallePorId(IdCompra);
            return detalleCompra;
        }
    }
}