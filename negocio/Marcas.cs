using dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Marcas
    {

        public static List<Marca> Listar()
        {

            AccesoDatos acceso = new AccesoDatos();
            List<Marca> marcas = new List<Marca>();

            var lector = acceso.Leer("SELECT Id, Descripcion FROM Marcas ORDER BY Id");

            while (lector.Read())
            {
                Marca aux = new Marca
                {
                    Id = (int)lector["Id"],
                    Descripcion = (string)lector["Descripcion"],
                };

                marcas.Add(aux);
            }

            return marcas;
        }

        public static bool Grabar(Marca marca)
        {
            AccesoDatos acceso = new AccesoDatos();
            string query = string.Format("INSERT INTO Marcas (Descripcion) VALUES ('{0}')", marca.Descripcion);
            return acceso.Ejecutar(query) > 0;
        }

        public static bool Editar(Marca marca)
        {
            AccesoDatos acceso = new AccesoDatos();

            string query = string.Format("UPDATE Marcas SET Descripcion='" + marca.Descripcion + "' WHERE Id='" + marca.Id + "'");
            return acceso.Ejecutar(query) > 0;
        }

        public static bool Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                string query = string.Format("delete from MARCAS where id = " + id);
                return datos.Ejecutar(query) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
