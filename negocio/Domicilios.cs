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

        public static bool Grabar(Domicilio dom)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<string> query = new List<string> {
                string.Format("INSERT INTO Domicilio (Calle, Ciudad, Departamento, Numero, Piso, Provincia, CodigoPostal, Referencia) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                dom.Calle, dom.Ciudad, dom.Departamento, dom.Numero, dom.Piso, dom.Provincia, dom.CodigoPostal, dom.Referencia)
            };

            return acceso.Ejecutar(query) > 0;
        }

        public static int GrabarInicial()
        {
            AccesoDatos acceso = new AccesoDatos();
            string query = string.Format("INSERT INTO Domicilio (Calle, Ciudad, Departamento, Numero, Piso, Provincia, CodigoPostal, Referencia) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}'); "
        + "SELECT CAST(scope_identity() AS int)",
                '1', '1', '1', 1, 1, '1', 1, "callefalsa");

            return acceso.EjecutarConID(query);
        }

        public static bool DomicilioPredeterminado(int id)
        {
            AccesoDatos acceso = new AccesoDatos();

            var lector = acceso.Leer("SELECT * FROM Domicilio WHERE Id = " + id + " ORDER BY Id");
            if (!lector.Read()) return false;
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

            return String.Equals(domicilio.Referencia, "callefalsa");
        }

        public static bool Editar(Domicilio domicilio)
        {
            AccesoDatos acceso = new AccesoDatos();

            string query = string.Format("UPDATE Domicilio SET Calle='{0}', Ciudad='{1}', Departamento='{2}', Numero='{3}', Piso='{4}', Provincia='{5}', CodigoPostal='{6}', Referencia='{7}' WHERE Id='" + domicilio.Id + "'", domicilio.Calle, domicilio.Ciudad, domicilio.Departamento, domicilio.Numero, domicilio.Piso, domicilio.Provincia, domicilio.CodigoPostal, domicilio.Referencia);
            return acceso.Ejecutar(query) > 0;
        }
        
    }
}
