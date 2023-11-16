using Negocio;
using System;

namespace tp_carrito_compras_equipo_20
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Session["ID_Usuario"] = null;
                string mail = Request.Form["mail"];
                string password = Request.Form["password"];

                var usr = Usuarios.Login(mail, password);

                if (usr != null)
                {
                    Session["Msg_ok"] = "Login Correcto!";
                    Session["Usuario"] = usr;

                    if (usr.IdTipoUsuario == 1) // usuario admin
                    {
                        Response.Redirect("/Admin/Panel.aspx");
                    }
                    else
                    {
                        Response.Redirect("/Perfil.aspx");
                    }
                }
                Session["Msg_error"] = "Usuario o contraseña incorrectos. Por favor, verifique y vuelva a intentar...";
            }
            else
            {
                if (Session["ID_Usuario"] != null)
                {
                    Response.Redirect("/Perfil.aspx");
                }
            }

        }
    }
}