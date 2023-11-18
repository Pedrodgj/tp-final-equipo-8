using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;
using System.Globalization;

namespace tp_carrito_compras_equipo_20
{
    public partial class PedidoFinalizado : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        public int cantidadArticulos = 0;
        private decimal ivaPorcentaje = 0.21m;
        protected void Page_Load(object sender, EventArgs e)
        {
            articulos = (List<Articulo>)Session["articulos"];
        }
    }
}