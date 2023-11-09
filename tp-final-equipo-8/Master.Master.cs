using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20
{
    public partial class Master : System.Web.UI.MasterPage
    {

        public int cantidadArticulos = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            /*totalCarrito.Text = Convert.ToString(cantidadArticulos);
            if (Session["cantArticulos"] != null)
            {
                totalCarrito.Text = Session["cantArticulos"].ToString();
            }*/
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}