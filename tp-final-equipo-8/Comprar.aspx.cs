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
        private Domicilio domicilio;
        private decimal ivaPorcentaje = 0.21m;
        private decimal totalAPagar;
        private decimal total;
        private decimal totalConIva;
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
                domicilio = Negocio.Domicilios.ListarPorId(usuario.IdDomicilio);
                if (!this.IsPostBack)
                {
                    //usuario = (Usuario)Session["Usuario"];
                    txtProvincia.Text = domicilio.Provincia.ToString();
                    txtProvincia.Enabled = false;
                    txtCiudad.Text = domicilio.Ciudad.ToString();
                    txtCiudad.Enabled = false;
                    txtCalle.Text = domicilio.Calle.ToString();
                    txtCalle.Enabled = false;
                    txtNumero.Text = domicilio.Numero.ToString();
                    txtNumero.Enabled = false;
                    txtDepartamento.Text = domicilio.Departamento.ToString();
                    txtDepartamento.Enabled = false;
                    txtPiso.Text = domicilio.Piso.ToString();
                    txtPiso.Enabled = false;
                    txtCodigoPostal.Text = domicilio.CodigoPostal.ToString();
                    txtCodigoPostal.Enabled = false;
                    txtReferencia.Text = domicilio.Referencia.ToString();
                    txtReferencia.Enabled = false;
                }
            }

            if (articulos == null)
            {
                return;
            }
            total = 0;
            foreach (var arti in articulos)
            {
                total += (arti.Precio * arti.Cantidad);
            }

            lblTotal.Text = string.Format(pesos, "{0:C}", total);
            totalConIva = total * ivaPorcentaje;
            lblIva.Text = string.Format(pesos, "{0:C}", totalConIva);
            totalAPagar = total + totalConIva;
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
            string html;
            string imagen = "";
            foreach (var art in articulos)
            {
                if (art.Imagenes == null)
                {
                    imagen = @"imagenes\imagen.png";
                    return;
                }

                if (art.Imagenes.Count > 0)
                {
                    imagen = art.Imagenes[0].Url;
                }
                else imagen = @"imagenes\imagen.png";
            }

                if (retiroEnvio.Checked == true)
            {
                html = $"<html lang=\"es\"><head>  <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                    $"<title>Correo Electrónico</title>" +
                    $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                    $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                    $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                    $"<body> <div class=\"container\">" +
                    $"<h1>Realizar Pago</h1> <p>Para finalizar la compra, es necesario realizar la compra por medio de este link de Mercado Pago.</p> <p>Una vez realizada la compra, enviar el comprobante de pago a tp_final_ecommerce@ecommerce.com.</p><a href=\"https://d2r9epyceweg5n.cloudfront.net/apps/5576-es_AR-Mercado%20Pago.jpg\">Mercado Pago</a>" +
                    $"<p>Una vez enviado el comprobante, el vendedor se comunicara con usted para hacerle llegar el domicilio para retirar la compra.</p>" +
                    $"</div></body></html>";
            } else
            {
                html = $"<html lang=\"es\"><head>  <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                    $"<title>Correo Electrónico</title>" +
                    $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                    $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                    $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                    $"<body> <div class=\"container\">" +
                    $"<h1>Realizar Pago</h1> <p>Para finalizar la compra, es necesario realizar la compra por medio de este link de Mercado Pago.</p> <p>Una vez realizada la compra, enviar el comprobante de pago a tp_final_ecommerce@ecommerce.com.</p><a target=\"_blank\" href=\"https://d2r9epyceweg5n.cloudfront.net/apps/5576-es_AR-Mercado%20Pago.jpg\">Mercado Pago</a>" +
                    $"<p>Una vez enviado el comprobante, se le estara enviando otro correo con el codigo de seguimiento de su compra.</p>" +
                    $"</div></body></html>";
            }

            foreach (var art in articulos)
            {
                html += $"<li class=\"flex items-center gap-4\">\r\n  <img\r\n    src=\"{imagen}\"\r\n    alt=\"\"\r\n    style=\"height: 64px; width: 64px; border-radius: 50%; object-fit: cover;\"\r\n  />\r\n</li>" +
                    $"<div>\r\n<h3 class=\"text-sm text-slate-300\">{art.Nombre}</h3>\r\n\r\n<dl class=\"mt-0.5 space-y-px text-[15px] text-slate-500\">\r\n" +
                    $"<div>\r\n<dt class=\"inline\">Descripcion:</dt>\r\n <dd class=\"inline\">{art.Descripcion}</dd>\r\n </div>\r\n\r\n" +
                    $"<div>\r\n <dt class=\"inline\">Precio:</dt>\r\n <dd class=\"inline\">{art.Precio}</dd>\r\n</div>\r\n</dl>\r\n" +
                    $"</div>\r\n\r\n <div class=\"flex flex-1 items-center justify-end gap-2\">\r\n<form>\r\n <label class=\"sr-only\"> Cantidad </label>\r\n\r\n" +
                    $"<div>\r\n\r\n <div class=\"flex items-center gap-1\">\r\n" +
                    $"<input\r\n type=\"number\"\r\n value=\"{art.Cantidad}\"\r\n min=\"1\"\r\n disabled\r\n class=\"h-10 w-16 rounded border-slate-700 bg-slate-800 text-slate-400 [-moz-appearance:_textfield] sm:text-sm [&::-webkit-outer-spin-button]:m-0 [&::-webkit-outer-spin-button]:appearance-none [&::-webkit-inner-spin-button]:m-0 [&::-webkit-inner-spin-button]:appearance-none\"\r\n/>\r\n\r\n" +
                    $"\r\n</div>\r\n</div>\r\n</form>";
            }

            html += $"<div style=\"margin-bottom: 20px;\">\r\n    <div style=\"display: flex; justify-content: space-between; align-items: center; border-bottom: 1px solid #ccc; padding: 8px 0;\">\r\n      <span style=\"font-weight: bold;\">Total:</span>\r\n      <span style=\"color: #000000;\">{total}</span>\r\n    </div>\r\n" +
                $"<div style=\"display: flex; justify-content: space-between; align-items: center; border-bottom: 1px solid #ccc; padding: 8px 0;\">\r\n      <span style=\"font-weight: bold;\">Total con IVA:</span>\r\n      <span style=\"color: #000000;\">{totalConIva}</span>\r\n    </div>\r\n" +
                $"<div style=\"display: flex; justify-content: space-between; align-items: center; padding: 8px 0;\">\r\n      <span style=\"font-weight: bold;\">Total a pagar:</span>\r\n      <span style=\"color: #000000;\">{totalAPagar}</span>\r\n    </div>\r\n  </div>";
            
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
            compra.Envio = acordarEnvio.Checked;
            compra.Total = totalAPagar;
            Compras.GrabarCompra(compra);

            Response.Redirect("PedidoFinalizado.aspx");
        }

        protected void btnEditarDomicilio_Click(object sender, EventArgs e)
        {
            if(txtProvincia.Enabled == false)
            {
                txtProvincia.Enabled = true;
                txtCiudad.Enabled = true;
                txtCalle.Enabled = true;
                txtNumero.Enabled = true;
                txtDepartamento.Enabled = true;
                txtPiso.Enabled = true;
                txtCodigoPostal.Enabled = true;
                txtReferencia.Enabled = true;
                btnEditarDomicilio.Visible = false;
                btnGuardarDomicilio.Visible = true;
            } else
            {
                txtProvincia.Enabled = false;
                txtCiudad.Enabled = false;
                txtCalle.Enabled = false;
                txtNumero.Enabled = false;
                txtDepartamento.Enabled = false;
                txtPiso.Enabled = false;
                txtCodigoPostal.Enabled = false;
                txtReferencia.Enabled = false;
                btnGuardarDomicilio.Visible = false;
                //Domicilio domicilio = new Domicilio();
                //domicilio.Id = domicilio.Id;
                //domicilio.Provincia = txtProvincia.Text;
                //domicilio.Ciudad = txtCiudad.Text;
                //domicilio.Calle = txtCalle.Text;
                //domicilio.Numero =  int.Parse(txtNumero.Text);
                //domicilio.Departamento = txtDepartamento.Text;
                //domicilio.Piso = int.Parse(txtPiso.Text);
                //domicilio.CodigoPostal = int.Parse(txtCodigoPostal.Text);    
                //domicilio.Referencia = txtReferencia.Text;
                //Negocio.Domicilios.Editar(domicilio);

            }
        }

        protected void btnGuardarDomicilio_Click(object sender, EventArgs e)
        {
            Domicilio nuevoDomicilio = new Domicilio();
            nuevoDomicilio.Id = domicilio.Id;
            string nuevaProvincia = txtProvincia.Text;
            nuevoDomicilio.Provincia = txtProvincia.Text;
            nuevoDomicilio.Ciudad = txtCiudad.Text;
            nuevoDomicilio.Calle = txtCalle.Text;
            nuevoDomicilio.Numero = int.Parse(txtNumero.Text);
            nuevoDomicilio.Departamento = txtDepartamento.Text;
            nuevoDomicilio.Piso = int.Parse(txtPiso.Text);
            nuevoDomicilio.CodigoPostal = int.Parse(txtCodigoPostal.Text);
            nuevoDomicilio.Referencia = txtReferencia.Text;
            Negocio.Domicilios.Editar(nuevoDomicilio);
            Response.Redirect("Comprar.aspx");
        }

        protected void acordarEnvio_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == acordarEnvio && acordarEnvio.Checked)
            {
                retiroEnvio.Checked = false; // Si radioButton1 se selecciona, deselecciona radioButton2
            }
            else if (sender == retiroEnvio && retiroEnvio.Checked)
            {
                acordarEnvio.Checked = false; // Si radioButton2 se selecciona, deselecciona radioButton1
            }
        }
    }
}