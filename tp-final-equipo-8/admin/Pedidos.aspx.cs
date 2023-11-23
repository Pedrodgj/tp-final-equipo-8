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
        private EstadoPedidoEnum nuevo = EstadoPedidoEnum.NUEVO;
        private EstadoPedidoEnum aceptado = EstadoPedidoEnum.ACEPTADO;
        private EstadoPedidoEnum en_progreso = EstadoPedidoEnum.EN_PROGRESO;
        private EstadoPedidoEnum cancelado = EstadoPedidoEnum.CANCELADO;
        private EstadoPedidoEnum completado = EstadoPedidoEnum.COMPLETADO;
        private string seleccionado;
        protected void Page_Load(object sender, EventArgs e)
        {
            compras = ListarCompras();
    

            var id = Request.QueryString["id"];
            var delete = Request.QueryString["delete"];
            if(delete == "true")
            {
                int idCompra = int.Parse(id);
                cancelarPedido(idCompra);
                Response.Redirect("Pedidos.aspx");
                return;
            }

            if (id != null)
            {

                int idCompra = int.Parse(id);
                informarEstado(idCompra);
                Response.Redirect("Pedidos.aspx");
                return;
            } 
             
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
            //string valorSeleccionado = estados.SelectedValue;
                       

            switch (compra.Estado)
            {
                case "NUEVO":
                    {
                        while (compra.CodigoSeguimiento == " ")
                        {
                            envioCorreo = true;
                            compra.CodigoSeguimiento = procesarEstadoAceptado();
                        }
                        compra.Estado = aceptado.ToString();
                    }
                    break;
                case "ACEPTADO":
                    {
                        while (compra.CodigoSeguimiento == " ")
                        {
                            envioCorreo = true;
                            compra.CodigoSeguimiento = procesarEstadoAceptado();
                        }
                       
                        compra.Estado = en_progreso.ToString();
                    }
                    break;
                case "EN_PROGRESO":
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
                    $"<title>Correo Electrónico</title>" +
                    $"<style>  body {{font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0;}}" +
                    $".container {{width: 80%; margin: 0 auto; text-align: center; padding: 40px 0;}}" +
                    $"h1 {{color: #333333; margin-bottom: 20px;}} p {{color: #666666; margin-bottom: 10px;}} a{{color: #007BFF; text-decoration: none; font-weight: bold;}} a:hover {{ text-decoration: underline;}} </style> </head>" +
                    $"<body> <div class=\"container\">" +
                    $"<h1>Compra Aprobada</h1> <p>Esta es una descripción del contenido del correo electrónico.</p> <p> Tu compra ha sido aprobada. Te hacemos llegar el codigo de seguimiento {compra.CodigoSeguimiento} </p>" +
                    $"</div></body></html>";
                try
                {
                    enviarEmail.ArmarCorreo(usuario.Email, "Codigo de seguimiento", html);
                    enviarEmail.enviarEmail();
                    Session["Msg_ok"] = "Se ha realizado correctamente el envio del codigo de seguimiento al usuario";
                }
                catch (Exception ex)
                {
                    Session["Msg_error"] = "No se ha podido enviar el correo al usuario con el codigo de seguimiento! Intente de nuevo o comuniquese con el administrador";
                    Response.Redirect("admin/Pedidos.aspx");
                    //throw ex;
                }
            }
            
            Negocio.Compras.UpdateCompra(compra);
        }

        private void cancelarPedido(int IdCompra)
        {
            Compra compra = Negocio.Compras.ListarCompraPorId(IdCompra);
            compra.Estado = cancelado.ToString();
            Negocio.Compras.UpdateCompra(compra);
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