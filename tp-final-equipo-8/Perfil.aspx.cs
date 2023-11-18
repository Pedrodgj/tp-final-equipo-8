using System;
using System.Security.Cryptography;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_Usuario"] == null)
            {
                Response.Redirect("/InicioSesion.aspx");
            }

            else
            {
                usuario = Usuarios.LeerPorId((int)Session["ID_Usuario"]);
            }

            if (this.IsPostBack)
            {
                Session["ID_Usuario"] = null;
                Session["Usuario"] = null;
                Response.Redirect("/InicioSesion.aspx");
            }

            tbNombres.Text = usuario.Nombres;
            tbApellido.Text = usuario.Apellidos;
            tbDNI.Text = usuario.DNI;
            tbMail.Text = usuario.Email;
            tbTel.Text = usuario.Telefono;
            calFecha.SelectedDate = usuario.FechaNacimiento;
        }
    }
}