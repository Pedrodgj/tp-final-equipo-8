using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20
{
    public partial class Comprar : System.Web.UI.Page
    {
        public Usuario usuario = null;
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        private decimal ivaPorcentaje = 0.21m;
        protected void Page_Load(object sender, EventArgs e)
        {
            articulos = (List<Articulo>)Session["articulos"];
            if (articulos == null)
            {
                return;
            }

            decimal total = 0;
            foreach (var arti in articulos)
            {
                total += (arti.Precio * arti.Cantidad);
            }

            lblTotal.Text = string.Format(pesos, "{0:C}", total);
            decimal totalConIva = total * ivaPorcentaje;
            lblIva.Text = string.Format(pesos, "{0:C}", totalConIva);
            decimal totalAPagar = total + totalConIva;
            lblTotalPagar.Text = string.Format(pesos, "{0:C}", totalAPagar);

            if (Session["ID_Usuario"] == null)
            {
                return;
            }
            int idUsuario = (int)Session["ID_Usuario"];
            usuario = Negocio.Usuarios.LeerPorId(idUsuario);
            txtNombre.Text = usuario.Nombres;

        }
    }
}