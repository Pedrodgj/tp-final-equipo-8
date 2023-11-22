using dominio;
using Negocio;
using System;

namespace tp_carrito_compras_equipo_20
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["ID_Usuario"] != null)
            {
                Response.Redirect("/Perfil.aspx");
            }

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
                if (Usuarios.Existe(_mail)) {
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

                bool res = Usuarios.Grabar(new Usuario{ 
                    Nombres = _nombre,
                    Apellidos = _apellido,
                    Email = _mail,
                    Password = _password,
                    DNI = _dni,
                    FechaNacimiento = _fecha_nacimiento,
                    Telefono = _telefono,
                    IdTipoUsuario = 2, // Cliente
                    IdDomicilio = (int)Domicilios.GrabarInicial() // Por ahora a cara de perro una ya creada con anterioridad
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
    }
}