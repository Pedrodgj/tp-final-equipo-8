using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class AgregarProducto : System.Web.UI.Page
    {

        public int id;
        public string codigo;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Categoria> categorias = Negocio.Categorias.Listar();
            List<Marca> marcas = Negocio.Marcas.Listar();

            ddlCategoria.DataSource = categorias;
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id";
            ddlCategoria.DataBind();

            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Descripcion";
            ddlMarca.DataValueField = "Id";
            ddlMarca.DataBind();

            if (this.IsPostBack)
            {
                btnAgregar.Text = "Editar";

                codigo = Request.QueryString["id"];
                id = int.Parse(codigo ?? "0");


                Articulo articulo = Articulos.Ver(codigo);
                tbCodigo.Text = articulo.Codigo;
                tbDescripcion.Text = articulo.Descripcion;
                tbNombre.Text = articulo.Nombre;
                tbPrecio.Text = Convert.ToString(articulo.Precio);

                if (id > 0)
                {
                    if (!Negocio.Articulos.Editar(articulo))
                    {
                        Session["Msg_error"] = "No se ha podido actualizar el producto " + id;
                        return;
                    }
                    Session["Msg_ok"] = "Producto actualizado con exito!";
                }
                else
                {
                    if (!Negocio.Articulos.Grabar(articulo))
                    {
                        Session["Msg_error"] = "No se ha podido grabar el producto " + id;
                        return;
                    }
                    Session["Msg_ok"] = "Producto creado con exito!";
                    btnAgregar.Text = "Agregar";
                }
                Response.Redirect("/admin/Productos.aspx");

            

            }
            else
            {
                btnAgregar.Text = "Agregar";
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}