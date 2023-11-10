using dominio;
using System;
using System.Collections.Generic;

namespace Negocio

{
    public class Usuarios
    {

        public static List<Usuario> Listar()
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Usuario> articulos = new List<Usuario>();

            var lector = acceso.Leer("SELECT * FROM Usuarios ORDER BY Id");

            while (lector.Read())
            {
                Usuario aux = new Usuario
                {
                    Id = (int)lector["Id"],
                    Apellidos = (string)lector["Apellidos"],
                    Nombres = (string)lector["Nombre"],
                    DNI = (string)lector["DNI"],
                    Email = (string)lector["Email"],
                    FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                    Password = (string)lector["Password"],
                    Telefono = (string)lector["Telefono"],
                    IdTipoUsuario = (int)lector["IdTipoUsuario"],
                    IdDomicilio = (int)lector["IdDomicilio"],
                };

                articulos.Add(aux);
            }

            return articulos;
        }

        public static Usuario Leer(string mail, string password)
        {
            AccesoDatos acceso = new AccesoDatos();

            var lector = acceso.Leer("SELECT * FROM Usuario WHERE Email = '" + mail + "' AND Password = '" + password + "'");

            if (!lector.Read()) return null;

            Usuario usr = new Usuario
            {
                Id = (int)lector["Id"],
                Apellidos = (string)lector["Apellidos"],
                Nombres = (string)lector["Nombre"],
                DNI = (string)lector["DNI"],
                Email = (string)lector["Email"],
                FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                Password = (string)lector["Password"],
                Telefono = (string)lector["Telefono"],
                IdTipoUsuario = (int)lector["IdTipoUsuario"],
                IdDomicilio = (int)lector["IdDomicilio"],
            };

            return usr;
        }

        public static bool Existe(string mail)
        {
            AccesoDatos acceso = new AccesoDatos();
            var lector = acceso.Leer("SELECT Id FROM Usuario WHERE Email = '" + mail + "'");

            return lector.Read();
        }

        public static bool Grabar(Usuario usr)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<string> query = new List<string> {
                string.Format("INSERT INTO Usuario (Apellidos, Nombres, Email, Password, DNI, FechaNacimiento, Telefono, IdTipoUsuario, IdDomicilio, Activo) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')",
                usr.Apellidos, usr.Nombres, usr.Email, usr.Password, usr.DNI, usr.FechaNacimiento.ToString("yyyy-MM-dd"), usr.Telefono, usr.IdTipoUsuario, usr.IdDomicilio, "1")
            };

            return acceso.Ejecutar(query) > 0;
        }

    }
}
