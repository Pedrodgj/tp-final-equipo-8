using dominio;
using System;
using System.Collections.Generic;

namespace Negocio

{
    public class Domicilios
        {
        public static List<Domicilio> Listar()
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Domicilio> domicilios = new List<Domicilio>();

            var lector = acceso.Leer("SELECT * FROM Domicilio ORDER BY Id");

            while (lector.Read())
            {
                Domicilio aux = new Domicilio()
                {
                    //Id = (int)lector["Id"],
                    //Apellidos = (string)lector["Apellidos"],
                    //Nombres = (string)lector["Nombre"],
                    //DNI = (string)lector["DNI"],
                    //Email = (string)lector["Email"],
                    //FechaNacimiento = (DateTime)lector["FechaNacimiento"],
                    //Password = (string)lector["Password"],
                    //Telefono = (string)lector["Telefono"],
                    //IdTipoUsuario = (int)lector["IdTipoUsuario"],
                    //IdDomicilio = (int)lector["IdDomicilio"],
                };

                domicilios.Add(aux);
            }

            return domicilios;
        }

        

    }
}
