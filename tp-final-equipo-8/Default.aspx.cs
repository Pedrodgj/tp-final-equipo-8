using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Globalization;

namespace tp_carrito_compras_equipo_20
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        public List<Marca> marcas { get; set; } 
        public List<Categoria> cats { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            articulos = Articulos.Listar();
            marcas = Marcas.Listar();
            cats = Categorias.Listar();
        }
    }

}