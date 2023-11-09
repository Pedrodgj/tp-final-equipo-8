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
    public partial class Productos : System.Web.UI.Page
    {
        //iniciar todos los atributos (articulos) de la session y verificar dentro de la funcion page load si estan en null o no
        //si no estan en null, mostrar los elementos dentro del carrito con las cantidad, precio y total a pagar. 
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        public int cantidadArticulos = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = Request.QueryString["id"];
            var delete = Request.QueryString["delete"];

            if(delete == "true")
            {
                eliminarProducto(id);
                Response.Redirect("Productos.aspx");
                return;
            }

            articulos = (List<Articulo>)Session["articulos"];
            if (articulos == null)
            {
                articulos = new List<Articulo>();
                if (id != null)
                {
                    Articulo art = Articulos.Ver(id);
                    art.Cantidad = art.Cantidad +1;
                    articulos.Add(art);
                    Session["articulos"] = articulos;
                    return;
                }
            }

            List<Articulo> articulosTotal = Articulos.Listar();

            if(id != null)
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
            
            decimal total = 0;
            foreach (var arti in articulos)
            {
                total += (arti.Precio * arti.Cantidad);
                cantidadArticulos += arti.Cantidad;
            }

            lblTotalPagar.Text = string.Format(pesos, "{0:C}", total);
            Session["cantArticulos"] = cantidadArticulos;
        }

        private void eliminarProducto(string id)
        {
            List<Articulo> articulosActuales = (List<Articulo>)Session["articulos"];
            bool flag = false;
            foreach (var art in articulosActuales)
            {
                if(art.Id.ToString() == id)
                {
                    if(art.Cantidad > 1)
                    {
                        art.Cantidad = art.Cantidad - 1;
                    } else
                    {
                        flag = true;
                    }
                } 
            }
            if(flag == true) articulosActuales.RemoveAll(articulo => articulo.Id.ToString() == id);

            Session["articulos"] = articulosActuales;
        }
    }
}