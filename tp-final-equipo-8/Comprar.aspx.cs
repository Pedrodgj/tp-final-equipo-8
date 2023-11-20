using dominio;
using Negocio;
using System;
using System.Collections;
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
        public Usuario usuario;
        public List<Articulo> articulos { get; set; }
        public CultureInfo pesos = new CultureInfo("es-AR");
        private decimal ivaPorcentaje = 0.21m;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            articulos = (List<Articulo>)Session["articulos"];
            if (usuario == null)
            {
                return;
            }
            else
            {
                Domicilio domicilio;
                //usuario = (Usuario)Session["Usuario"];
                domicilio = Negocio.Domicilios.ListarPorId(usuario.IdDomicilio);
                txtProvincia.Text = domicilio.Provincia.ToString();
                txtCiudad.Text = domicilio.Ciudad.ToString();
                txtCalle.Text = domicilio.Calle.ToString();
                txtNumero.Text = domicilio.Numero.ToString();
                txtDepartamento.Text = domicilio.Departamento.ToString();
                txtPiso.Text = domicilio.Piso.ToString();
                txtCodigoPostal.Text = domicilio.CodigoPostal.ToString();
                txtCodigoPostal.Text = domicilio.CodigoPostal.ToString();
            }

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

           
            
           
        }

        protected void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Session["Msg_error"] = null;
                Session["Msg_ok"] = null;

                string _nombre = Request.Form["nombre"];
                string _apellido = Request.Form["apellido"];
                string _mail = Request.Form["mail"];
                string _dni = Request.Form["dni"];
                string _telefono = Request.Form["telefono"];
                string fecha = Request.Form["fecha_nacimiento"];
                DateTime _fecha_nacimiento = DateTime.Parse(Request.Form["fecha_nacimiento"]);
                string _password = Request.Form["password"];
                string _password_confirmacion = Request.Form["password_confirmacion"];

                // Controlamos que el usuario NO exista con el mismo mail
                if (Usuarios.Existe(_mail))
                {
                    Session["Msg_error"] = "Ya existe un usuario registrado con el Email " + _mail;
                    Response.Redirect("/Registro.aspx");
                    // Redirigir con el error usando Session.
                }

                // Las contraseña deben coincidir
                if (_password.Trim() != _password_confirmacion.Trim())
                {
                    Session["Msg_error"] = "Las contraseñas no coinciden";
                    Response.Redirect("/Registro.aspx");
                }

                bool res = Usuarios.Grabar(new Usuario
                {
                    Nombres = _nombre,
                    Apellidos = _apellido,
                    Email = _mail,
                    Password = _password,
                    DNI = _dni,
                    FechaNacimiento = _fecha_nacimiento,
                    Telefono = _telefono,
                    IdTipoUsuario = 2, // Cliente
                    IdDomicilio = 2 // Por ahora a cara de perro una ya creada con anterioridad
                });

                if (!res)
                {
                    Session["Msg_error"] = "No se ha podido registrar al usuario. Vuelva a probar en unos minutos.";
                    Response.Redirect("/Registro.aspx");
                }
                Session["Msg_ok"] = "El registro fue exitoso. Inicie sesión con sus credenciales";
                Response.Redirect("/InicioSesion.aspx");
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            int IdUsuario = usuario.Id;
            List<DetalleCompra> detalleCompras = new List<DetalleCompra>();

            foreach (var art in articulos)
            {
                DetalleCompra detalle = new DetalleCompra();
                detalle.IdArticulo = art.Id;
                detalle.Cantidad = art.Cantidad;
                detalle.PrecioUnitario = art.Precio;
                detalle.Total = (art.Precio * art.Cantidad) * ivaPorcentaje;
                detalleCompras.Add(detalle);
            }
            compra.IdUsuario = IdUsuario;
            compra.Detalles = detalleCompras;
            Compras.GrabarCompra(compra);

            Response.Redirect("Perfil.aspx");
        }
    }
}