using dominio;
using System;
using System.Collections.Generic;

namespace Negocio

{
    public class Domicilios
        {
        public static Domicilio ListarPorId(int Id)
        {
            AccesoDatos acceso = new AccesoDatos();

            var lector = acceso.Leer("SELECT * FROM Domicilio WHERE Id = " + Id + " ORDER BY Id");
            if (!lector.Read()) return null;
            Domicilio domicilio = new Domicilio
            {
                Id = (int)lector["Id"],
                Calle = (string)lector["Calle"],
                Ciudad = (string)lector["Ciudad"],
                Departamento = (string)lector["Departamento"],
                Numero = (int)lector["Numero"],
                Piso = (int)lector["Piso"],
                Provincia = (string)lector["Provincia"],
                Referencia = (string)lector["Referencia"],
                CodigoPostal = (int)lector["CodigoPostal"],
            };

            return domicilio;
        }

        public static List<Domicilio> Listar()
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Domicilio> domicilios = new List<Domicilio>();

            var lector = acceso.Leer("SELECT * FROM Domicilio ORDER BY Id");

            while (lector.Read())
            {
                Domicilio aux = new Domicilio()
                {
                    Id = (int)lector["Id"],
                    Calle = (string)lector["Calle"],
                    Ciudad = (string)lector["Ciudad"],
                    Departamento = (string)lector["Departamento"],
                    Numero = (int)lector["Numero"],
                    Piso = (int)lector["Piso"],
                    Provincia = (string)lector["Provincia"],
                    Referencia = (string)lector["Referencia"],
                    CodigoPostal = (int)lector["CodigoPostal"],
                };

                domicilios.Add(aux);
            }

            return domicilios;
        }

    }
}
