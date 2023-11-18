using System;
using System.Security.Cryptography;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public Domicilio domicilio = new Domicilio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID_Usuario"] == null)
            {
                Response.Redirect("/InicioSesion.aspx");
            }

            else
            {
                usuario = Usuarios.LeerPorId((int)Session["ID_Usuario"]);
                domicilio = Domicilios.ListarPorId(usuario.Id);
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

            tbCalle.Text = domicilio.Calle;
            tbCiudad.Text = domicilio.Ciudad;
            tbDepartamento.Text = domicilio.Departamento;
            tbNumero.Text = Convert.ToString(domicilio.Numero);
            tbPiso.Text = Convert.ToString(domicilio.Piso);
            tbProvincia.Text = domicilio.Provincia;
            tbCP.Text = Convert.ToString(domicilio.CodigoPostal);
            tbReferencia.Text = domicilio.Referencia;

        }
    }
}