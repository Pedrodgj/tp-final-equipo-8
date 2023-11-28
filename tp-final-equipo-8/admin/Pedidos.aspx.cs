using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_carrito_compras_equipo_20.admin
{
    public partial class Pedidos : System.Web.UI.Page
    {
        public List<Compra> compras;
        public CultureInfo pesos = new CultureInfo("es-AR");
        public EstadoPedidoEnum nuevo = EstadoPedidoEnum.NUEVO;
        public EstadoPedidoEnum aceptado = EstadoPedidoEnum.ACEPTADO;
        public EstadoPedidoEnum envio = EstadoPedidoEnum.ENVIADO;
        public EstadoPedidoEnum retirar = EstadoPedidoEnum.LISTO_PARA_RETIRAR;
        public EstadoPedidoEnum cancelado = EstadoPedidoEnum.CANCELADO;
        public EstadoPedidoEnum completado = EstadoPedidoEnum.COMPLETADO;
        private string seleccionado;
        public Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            if(usuario == null )
            {
                Response.Redirect("../InicioSesion.aspx");
            } else if(usuario.IdTipoUsuario != 1)
            {
                Response.Redirect("../Perfil.aspx");
            }
            
            var id = Request.QueryString["id"];
            var delete = Request.QueryString["delete"];

            if (id != null)
            {
                int idCompra = int.Parse(id);
                informarEstado(idCompra);
                Response.Redirect("Pedidos.aspx");
                return;
            } 
            
            if(delete == "true")
            {
                int idCompra = int.Parse(id);
                cancelarPedido(idCompra);
                Response.Redirect("Pedidos.aspx");
                return;
            }          

            compras = ListarCompras();
            ddlOpcion.Visible = false;
            ddlFiltro.Items.Add("");
            ddlFiltro.Items.Add("Usuario");
            ddlFiltro.Items.Add("Fecha");

        }

        private List<Compra> ListarCompras()
        {
            List<Compra> comprasUsuario = new List<Compra>();
            List<Compra> compras;
            compras = Compras.ListarCompras();

            foreach (Compra compra in compras)
            {
                compra.Detalles = ListarDetalles(compra.Id);
                comprasUsuario.Add(compra);
            }

            return compras;
        }

        private List<DetalleCompra> ListarDetalles(int IdCompra)
        {
            List<DetalleCompra> detalleCompra;
            detalleCompra = Compras.ListarDetallePorId(IdCompra);
            return detalleCompra;
        }

        private void informarEstado(int IdCompra)
        {
            Compra compra;
            bool envioCorreo = false;
            compra = Negocio.Compras.ListarCompraPorId(IdCompra);
            string asunto;
                       

            switch (compra.Estado)
            {
                case "NUEVO":
                    {
                        compra.Estado = aceptado.ToString();
                        envioCorreo = true;
                    }
                    break;
                case "ACEPTADO":
                    {
                        if(compra.Envio == false)
                        {
                            compra.Estado = retirar.ToString();

                        } else {
                            while (compra.CodigoSeguimiento == " ")
                            {
                                compra.CodigoSeguimiento = procesarEstadoAceptado();
                                compra.Estado = envio.ToString();
                            }
                        }
                        envioCorreo = true;                       
                    }
                    break;
                case "ENVIADO":
                    {
                        compra.Estado = completado.ToString();
                    }
                    break;
                case "LISTO_PARA_RETIRAR":
                    {
                        compra.Estado = completado.ToString();
                    }
                    break;
                case "COMPLETADO":
                    {
                        compra.Estado = completado.ToString();
                    }
                    break;
                default:
                    compra.Estado = "";
                    break;
            }

            if(envioCorreo == true)
            {
                Usuario usuario = Negocio.Usuarios.LeerPorId(compra.IdUsuario);
                EmailService enviarEmail = new EmailService();

                string html = $"<html lang=\"es\"><head>  <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                    $"<title>Tp-Final-Grupo-8</title>" +
                    $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                    $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                    $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                    $"<body> <div class=\"container\">" +
                    $"<h1>Compra Aprobada</h1> <p>Muchas gracias por confiar en nosotros.</p> ";
                if(compra.Estado == aceptado.ToString())
                {
                    asunto = "Compra Aprobada";
                    html += $"<p> Tu compra ha sido Aceptada. En breve le estare llegando otro correo con mas informacion</p>" +
                    $"</div></body></html>";
                }
                else if(compra.Envio == true)
                {
                    asunto = "Codigo Seguimiento";
                    html += $"<p> Tu compra ha sido aprobada. Te hacemos llegar el codigo de seguimiento {compra.CodigoSeguimiento} </p>" +
                    $"</div></body></html>";
                } else
                {
                    asunto = "Direccion Retirar Pedido";
                    Domicilio currentDomicilio = Negocio.Domicilios.ListarPorId(usuario.IdDomicilio);
                    html += $"<p> Tu compra ha sido aprobada. Te hacemos llegar la direccion donde retirar tus productos </p>" +
                    $"<p> Provincia: {currentDomicilio.Provincia} </p>" +
                    $"<p> Ciudad: {currentDomicilio.Ciudad} </p>" +
                    $"<p> Codigo Postal: {currentDomicilio.CodigoPostal} </p>" +
                    $"<p> Calle: {currentDomicilio.Calle} </p>" +
                    $"<p> Altura: {currentDomicilio.Numero} </p>" +
                    $"<p> Departamento: {currentDomicilio.Departamento} </p>" +
                    $"<p> Piso: {currentDomicilio.Piso} </p>" +
                    $"</div></body></html>";
                }
                try
                {
                    enviarEmail.ArmarCorreo(usuario.Email, asunto, html);
                    enviarEmail.enviarEmail();
                    Session["Msg_ok"] = "Se ha realizado correctamente el envio del correo";
                }
                catch (Exception ex)
                {
                    Session["Msg_error"] = "No se ha podido enviar el correo al usuario! Intente de nuevo o comuniquese con el administrador";
                    Response.Redirect("../admin/Pedidos.aspx");
                    //throw ex;
                }
            }
            
            Negocio.Compras.UpdateCompra(compra);
        }

        private void cancelarPedido(int IdCompra)
        {
            Usuario currentUsuario = (Usuario)Session["Usuario"];
            Compra compra = Negocio.Compras.ListarCompraPorId(IdCompra);
            Usuario usuario = Negocio.Usuarios.LeerPorId(compra.IdUsuario);
            EmailService enviarEmail = new EmailService();
            string html = $"<html lang=\"es\"><head>  <meta charset=\"UTF-8\"> <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" +
                    $"<title>Tp-Final-Grupo-8</title>" +
                    $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                    $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                    $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                    $"<body> <div class=\"container\">" +
                    $"<h1>Compra Cancelada</h1> <p>Su compra ha sido cancelada. Ante cualquier duda, comuniquese al siguiente numero: </p> " +
                    $"<p> {currentUsuario.Telefono} </p>";

            try
            {
                usuario.Email = "pedrodgj1497@gmail.com";
                enviarEmail.ArmarCorreo(usuario.Email, "Compra Cancelada", html);
                enviarEmail.enviarEmail();
                Session["Msg_ok"] = "Se ha realizado correctamente el envio del correo";
                compra.Estado = cancelado.ToString();
                Negocio.Compras.UpdateCompra(compra);
            }
            catch (Exception ex)
            {
                Session["Msg_error"] = "No se ha podido enviar el correo al usuario! Intente de nuevo o comuniquese con el administrador";
                Response.Redirect("../admin/Pedidos.aspx");
                //throw ex;
            }
        }

        private string procesarEstadoAceptado()
        {
  
            bool existeCodigo;
            string codigoSeguimiento = generarCodigoSeguimiento();
            existeCodigo = Negocio.Compras.validarExisteCodigoSeguimiento(codigoSeguimiento);
            if(existeCodigo == true)
            {
                return codigoSeguimiento;                
            } else
            {
                return " ";
            }
        }

        private string generarCodigoSeguimiento()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; 

            int length = 10; 
            StringBuilder idBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                idBuilder.Append(chars[index]);
            }

            string generatedId = idBuilder.ToString();
            return generatedId;
        }       
    }
    
}