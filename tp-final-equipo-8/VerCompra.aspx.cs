using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20
{
    public partial class VerCompra : System.Web.UI.Page
    {
        public List<DetalleCompra> detallePedido = new List<DetalleCompra>();
        public Compra compra = new Compra();
        public int id;
        public Articulo articulo = new Articulo();
        public CultureInfo pesos = new CultureInfo("es-AR");
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["usuario"];
            if(usuario == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
            id = int.Parse(Request.QueryString["id"] ?? "0");
            detallePedido = Compras.ListarDetallePorId(id);
            compra = Compras.ListarCompraPorId(id);
        }
    }
}