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
            
            List<Compra> sessionCompra = (List<Compra>)Session["comprasActual"];
            compras = sessionCompra;
            ddlOpcion.Visible = false;
            txtBuscar.Visible = false;
            lblBuscar.Visible = false;
            if(compras == null)
            {
                compras = ListarCompras();
                Session["comprasActual"] = compras;
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

        private List<Compra> ListarComprasPorFechas(string query)
        {
            List<Compra> comprasUsuario = new List<Compra>();
            List<Compra> compras;
            compras = Compras.ListarCompraPorFechas(query);

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
                    Session["comprasActual"] = null;
                }
                catch (Exception ex)
                {
                    Session["Msg_error"] = "No se ha podido enviar el correo al usuario! Intente de nuevo o comuniquese con el administrador";
                    Response.Redirect("../admin/Pedidos.aspx");
                    //throw ex;
                }
            }
            
            Negocio.Compras.UpdateCompra(compra);
            Session["comprasActual"] = null;
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
                enviarEmail.ArmarCorreo(usuario.Email, "Compra Cancelada", html);
                enviarEmail.enviarEmail();
                Session["Msg_ok"] = "Se ha realizado correctamente el envio del correo";
                compra.Estado = cancelado.ToString();
                Negocio.Compras.UpdateCompra(compra);
                Session["comprasActual"] = null;
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

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiltro.SelectedItem.Text.ToString() == "Usuario")
            {
                ddlOpcion.Items.Clear();
                ddlOpcion.Items.Add("Nombre");
                ddlOpcion.Items.Add("Email");
                ddlOpcion.Visible = true;

                txtBuscar.Visible = true;
                lblBuscar.Visible = true;
            }

            if(ddlFiltro.SelectedItem.Text.ToString() == "Fecha")
            {
                txtBuscar.Visible = false;
                lblBuscar.Visible = false;
                ddlOpcion.Items.Clear();
                ddlOpcion.Items.Add("Hoy");
                ddlOpcion.Items.Add("Ultima Semana");
                ddlOpcion.Items.Add("Ultimo Mes");
                ddlOpcion.Visible = true;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Compra> sessionCompra = ListarCompras();
            Usuario usuario = null;
            if (ddlFiltro.SelectedItem.Text.ToString() == "Usuario")
            {
                if (ddlOpcion.SelectedItem.Text.ToString() == "Nombre")
                {
                    string query = $"WHERE us.Nombres LIKE('%{txtBuscar.Text}%')";
                    usuario = Usuarios.LeerPorFiltro(query);
                }
                if (ddlOpcion.SelectedItem.Text.ToString() == "Email")
                {
                    string query = $"WHERE us.Email LIKE('%{txtBuscar.Text}%')";
                    usuario = Usuarios.LeerPorFiltro(query);
                }
                if (usuario == null)
                {
                    Session["Msg_error"] = "No se hallaron resultados para tu busqueda";
                    Response.Redirect("Pedidos.aspx");
                }
                Session["comprasActual"] = sessionCompra.FindAll(x => x.IdUsuario == usuario.Id);
                if (ddlEstado.SelectedItem.Text.ToString() != "TODOS")
                {
                    Session["comprasActual"] = sessionCompra.FindAll(x => x.Estado == ddlEstado.Text.ToString());
                }
                Response.Redirect("Pedidos.aspx");
            }
            if (ddlFiltro.SelectedItem.Text.ToString() == "Fecha")
            {
                string query;
                if (ddlOpcion.SelectedItem.Text.ToString() == "Hoy")
                {
                    query = $"CONVERT(DATE, FechaCompra) = CONVERT(DATE, GETDATE())";
                    Session["comprasActual"] = ListarComprasPorFechas(query);
                }
                if (ddlOpcion.SelectedItem.Text.ToString() == "Ultima Semana")
                {
                    query = $"FechaCompra >= DATEADD(DAY, -7, CONVERT(DATE, GETDATE())) AND FechaCompra <= GETDATE()";
                    Session["comprasActual"] = ListarComprasPorFechas(query);
                }
                if (ddlOpcion.SelectedItem.Text.ToString() == "Ultimo Mes")
                {
                    query = $"FechaCompra >= DATEADD(MONTH, -1, DATEADD(DAY, 1, EOMONTH(GETDATE(), -1))) AND FechaCompra <= EOMONTH(GETDATE())";
                    Session["comprasActual"] = ListarComprasPorFechas(query);
                }
                if(ddlEstado.SelectedItem.Text.ToString() != "TODOS")
                {
                    sessionCompra = (List<Compra>)Session["comprasActual"];
                    Session["comprasActual"] = sessionCompra.FindAll(x => x.Estado == ddlEstado.Text.ToString());
                }
                Response.Redirect("Pedidos.aspx");
            }

            if(ddlEstado.SelectedItem.Text.ToString() != "TODOS")
            {
                Session["comprasActual"] = sessionCompra.FindAll(x => x.Estado == ddlEstado.Text.ToString());
                Response.Redirect("Pedidos.aspx");
            }

            Session["comprasActual"] = sessionCompra;
            Response.Redirect("Pedidos.aspx");
        }
    }
    
}