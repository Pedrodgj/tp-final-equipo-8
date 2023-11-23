using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using dominio;
using Negocio;

namespace tp_carrito_compras_equipo_20
{
    public partial class Perfil : System.Web.UI.Page
    {
        public Usuario usuario = new Usuario();
        public Domicilio domicilio = new Domicilio();
        public List<Compra> compras = new List<Compra>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = null;
            
            if (Session["ID_Usuario"] == null)
            {
                Response.Redirect("/InicioSesion.aspx");
            } else
            {
                usuario = (Usuario)Session["Usuario"];
                compras = ListarCompras(usuario.Id);
            }
                
                
                domicilio = Domicilios.ListarPorId(usuario.IdDomicilio);
     

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

            if (!String.Equals(domicilio.Referencia, "callefalsa"))
            {
                lbDomicilio.Text = "Aca podes ver tu domicilio actual y editarlo";

                tbCalle.Text = domicilio.Calle;
                tbCiudad.Text = domicilio.Ciudad;
                tbDepartamento.Text = domicilio.Departamento;
                tbNumero.Text = Convert.ToString(domicilio.Numero);
                tbPiso.Text = Convert.ToString(domicilio.Piso);
                tbProvincia.Text = domicilio.Provincia;
                tbCP.Text = Convert.ToString(domicilio.CodigoPostal);
                tbReferencia.Text = domicilio.Referencia;
            }

            else lbDomicilio.Text = "Parece que no tenes ningun domicilio agendado! Agenda uno."; 
            

        }

        private List<Compra> ListarCompras(int IdUsuario)
        {
            List<Compra> comprasUsuario = new List<Compra>();
            List<Compra> compras;
            compras = Compras.ListarCompraPorUsuario(IdUsuario);

            foreach (Compra compra in compras)
            {
                compra.Detalles = ListarDetalles(compra.Id);
                comprasUsuario.Add(compra);
            }

            return comprasUsuario;
        }

        private List<DetalleCompra> ListarDetalles(int IdCompra)
        {
            List<DetalleCompra> detalleCompra;
            detalleCompra = Compras.ListarDetallePorId(IdCompra);
            return detalleCompra;
        }

        protected void btnDomicilio_Click(object sender, EventArgs e)
        {
            domicilio.Calle = tbCalle.Text;
            domicilio.Ciudad = tbCiudad.Text;
            domicilio.Departamento = tbDepartamento.Text;
            domicilio.Numero = Convert.ToInt32(tbNumero.Text);
            domicilio.Piso = Convert.ToInt32(tbPiso.Text);
            domicilio.Provincia = tbProvincia.Text;
            domicilio.CodigoPostal = Convert.ToInt32(tbCP.Text);
            domicilio.Referencia = tbReferencia.Text;

            Domicilios.Editar(domicilio);
        }
    }
}