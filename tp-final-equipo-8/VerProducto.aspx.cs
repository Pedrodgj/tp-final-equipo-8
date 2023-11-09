using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dominio;
using Negocio;
using System.Globalization;
using System.Net;

namespace tp_carrito_compras_equipo_20
{
    public partial class VerProducto : System.Web.UI.Page
    {
        protected Articulo articulo = new Articulo();
        protected List<Imagen> imagenes = new List<Imagen>();
        public CultureInfo pesos = new CultureInfo("es-AR");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string idProducto = Request.QueryString["id"];
                articulo = Articulos.Ver(idProducto);
                imagenes = Imagenes.ByArticuloId(Convert.ToInt32(idProducto));

                if (articulo.Id == 0) Response.Redirect("/404.aspx");

            }

            foreach (var img in imagenes)
                            {
                                if (esImagen(img.Url) != 200) img.Url = @"imagenes\imagen.png";
                            }
            
                    }

        protected int esImagen(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "HEAD";
            request.AllowAutoRedirect = false;

            try
            {
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    return (int) response.StatusCode;
                }
            }

            catch (WebException e)
            {
                    if (e.Response != null) return Response.StatusCode;
                    else throw;
                }


        }

    }
}