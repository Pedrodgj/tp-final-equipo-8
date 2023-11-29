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

            var lector = acceso.Leer("SELECT * FROM Usuario ORDER BY Id");

            while (lector.Read())
            {
                Usuario aux = new Usuario
                {
                    Id = (int)lector["Id"],
                    Activo = (bool)lector["Activo"],
                    Apellidos = (string)lector["Apellidos"],
                    Nombres = (string)lector["Nombres"],
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

            var lector = acceso.Leer("SELECT Id, Apellidos, Nombres, DNI, Email, FechaNacimiento, Password, Telefono, IdTipoUsuario, IdDomicilio FROM Usuario WHERE Email = '" + mail + "' AND Password = '" + password + "'");

            if (!lector.Read()) return null;

            Usuario usr = new Usuario
            {
                Id = (int)lector["Id"],
                Apellidos = (string)lector["Apellidos"],
                Nombres = (string)lector["Nombres"],
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

        public static Usuario LeerPorId(int Id)
        {
            AccesoDatos acceso = new AccesoDatos();

            var lector = acceso.Leer("SELECT * FROM Usuario WHERE Id = " + Id + "");

            if (!lector.Read()) return null;

            Usuario usr = new Usuario
            {
                Id = (int)lector["Id"],
                Apellidos = (string)lector["Apellidos"],
                Nombres = (string)lector["Nombres"],
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

        public static Usuario LeerPorFiltro(string query)
        {
            AccesoDatos acceso = new AccesoDatos();

            var lector = acceso.Leer($"SELECT us.Nombres, us.Apellidos, us.Email, us.Id, com.Id as IdCompra FROM Usuario AS us INNER JOIN Compras AS com ON us.Id = com.IdUsuario {query}");

            if (!lector.Read()) return null;

            Usuario usr = new Usuario
            {
                Id = (int)lector["Id"],
                Apellidos = (string)lector["Apellidos"],
                Nombres = (string)lector["Nombres"],
                Email = (string)lector["Email"],
            };
            return usr;
        }

        public static bool Existe(string mail)
        {
            AccesoDatos acceso = new AccesoDatos();
            var lector = acceso.Leer("SELECT Id FROM Usuario WHERE Email = '" + mail + "'");

            return lector.Read();
        }

        public static Usuario Login(string mail, string password)
        {
            var usr = Usuarios.Leer(mail,password);
            return usr;
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
