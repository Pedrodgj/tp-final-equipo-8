using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;
using System.Globalization;
using System.Net.Mail;

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
            var id = Request.QueryString["id"];
            bool primerArticulo;

            Usuario usuario = (Usuario)Session["Usuario"];
            if (usuario != null)
            {
                MensajeLiteral.Text = "Se ha enviado a su correo electrónico " + usuario.Email + " el link de pago.";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

            articulos = (List<Articulo>)Session["articulos"];
            if (articulos == null)
            {
                primerArticulo = true;
            }
            else
            {
                primerArticulo = false;
            }
            if (primerArticulo == true)
            {
                articulos = new List<Articulo>();
                if (id != null)
                {
                    Articulo art = Articulos.Ver(id);
                    art.Cantidad = art.Cantidad + 1;
                    articulos.Add(art);
                    Session["articulos"] = articulos;
                    //return;
                }
            }
            else
            {
                List<Articulo> articulosTotal = Articulos.Listar();

                if (id != null)
                {
                    bool exist = false;
                    foreach (var art in articulosTotal)
                    {
                        if (id == art.Id.ToString())
                        {
                            foreach (var articu in articulos)
                            {
                                if (art.Id == articu.Id)
                                {
                                    articu.Cantidad = articu.Cantidad + 1;
                                    exist = true;
                                }
                            }

                            if (exist != true)
                            {
                                art.Cantidad = art.Cantidad + 1;
                                articulos.Add(art);
                            }
                        }
                    }
                }

                Session["articulos"] = articulos;
            }
            
            decimal total = 0;
            foreach (var arti in articulos)
            {
                total += (arti.Precio * arti.Cantidad);
                cantidadArticulos += arti.Cantidad;
            }

            lblTotal.Text = string.Format(pesos, "{0:C}", total);
            decimal totalConIva = total * ivaPorcentaje;
            lblIva.Text = string.Format(pesos, "{0:C}", totalConIva);
            decimal totalAPagar = total + totalConIva;
            lblTotalPagar.Text = string.Format(pesos, "{0:C}", totalAPagar);
            Session["cantArticulos"] = cantidadArticulos;

            Session["articulos"] = null;
        }
    }
}