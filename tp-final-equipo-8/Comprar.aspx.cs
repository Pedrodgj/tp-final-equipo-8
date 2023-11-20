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
            EmailService enviarEmail = new EmailService();

            string html = $"<html lang=\"es\"><head>  <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                $"<title>Correo Electrónico</title>" +
                $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                $"<body> <div class=\"container\">" +
                $"<h1>Título del Correo</h1> <p>Esta es una descripción del contenido del correo electrónico.</p> <p>Puedes encontrar más información en el siguiente enlace:</p><a href=\"https://www.youtube.com/watch?v=ED-OaXOc6DY\">Enlace de Ejemplo</a>" +
                $"</div></body></html>";
            
            try
            {
                enviarEmail.ArmarCorreo(usuario.Email, "Realizar Compra", html);
                enviarEmail.enviarEmail();
            }
            catch (Exception ex)
            {
                Session["Msg_error"] = "No se ha podido enviar al correo el link de pago! Intente de nuevo o comuniquese con el administrador";
                Response.Redirect("Comprar.aspx");
                //throw ex;
            }
            EstadoPedidoEnum nuevo = EstadoPedidoEnum.NUEVO;
            Compra compra = new Compra();
            int IdUsuario = usuario.Id;
            List<DetalleCompra> detalleCompras = new List<DetalleCompra>();

            foreach (var art in articulos)
            {
                DetalleCompra detalle = new DetalleCompra();
                detalle.IdArticulo = art.Id;
                detalle.Cantidad = art.Cantidad;
                detalle.PrecioUnitario = art.Precio;
                decimal ivaTotal = (art.Precio * art.Cantidad) * ivaPorcentaje;
                detalle.Total = ivaTotal + (art.Precio * art.Cantidad);
                detalleCompras.Add(detalle);
            }
            compra.IdUsuario = IdUsuario;
            compra.Detalles = detalleCompras;
            compra.Estado = nuevo.ToString();
            Compras.GrabarCompra(compra);

            Response.Redirect("PedidoFinalizado.aspx");
        }
    }
}