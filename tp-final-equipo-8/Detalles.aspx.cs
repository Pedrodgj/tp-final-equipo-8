using dominio;
using Negocio;
using System;
using System.Web;
using System.Web.UI;

namespace tp_carrito_compras_equipo_20
{
    public partial class Detalles : Page
    {
        public string Titulo { get; set; }

        public Articulo articulo { get; set; }

        public const string URL_NO_IMAGEN = "https://imgs.search.brave.com/JhrXXieZJmygk_GbDJ0sf92xUjr0edVIHMLdvep22Gc/rs:fit:500:0:0/g:ce/aHR0cHM6Ly90NC5m/dGNkbi5uZXQvanBn/LzA1Lzk3LzQ3Lzk1/LzM2MF9GXzU5NzQ3/OTU1Nl83YmJRN3Q0/WjhrM3hiQWxvSEZI/VmRaSWl6V0sxUGRP/by5qcGc";

        protected void Page_Load(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(Request.QueryString["id"]);

            articulo = Articulos.Listar().Find((ar) => ar.Id == codigo);

            if (articulo == null) HttpNotFound();

            if (articulo.Imagenes.Count == 0)
            {
                articulo.Imagenes.Add(new Imagen{
                    Url = URL_NO_IMAGEN
                });
            }

            Title = "TP Carrito de Compras - Detalles Articulo " + articulo.Codigo;
            Titulo = "Detalles del Articulo " + articulo.Codigo;
        }

        private void HttpNotFound() 
        {
            Response.Clear();
            Response.StatusCode = 404;
            Response.End();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}