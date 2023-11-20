using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class Pedidos : System.Web.UI.Page
    {
        public List<Compra> compras;
        public CultureInfo pesos = new CultureInfo("es-AR");
        protected void Page_Load(object sender, EventArgs e)
        {
            compras = ListarCompras();
      



            if (IsPostBack)
            {

            }
        }

        private List<Compra> ListarCompras()
        {
            List<Compra> comprasUsuario = new List<Compra>();
            List<Compra> compras;
            compras = Compras.ListarCompras();

            foreach (Compra compra in compras)
            {
                compra.Detalles = ListarDetalles(compra.Id);
                comprasUsuario.Add(compra);
            }

            return compras;
        }

        private List<DetalleCompra> ListarDetalles(int IdCompra)
        {
            List<DetalleCompra> detalleCompra;
            detalleCompra = Compras.ListarDetallePorId(IdCompra);
            return detalleCompra;
        }

    }
}