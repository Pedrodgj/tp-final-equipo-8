using dominio;
using System;
using System.Collections.Generic;

namespace Negocio
{
    public class Categorias
    {

        public static List<Categoria> Listar()
        {

            AccesoDatos acceso = new AccesoDatos();
            List<Categoria> categorias = new List<Categoria>();

            var lector = acceso.Leer("SELECT Id, Descripcion FROM Categorias ORDER BY Id");

            while (lector.Read())
            {
                Categoria aux = new Categoria
                {
                    Id = (int)lector["Id"],
                    Descripcion = (string)lector["Descripcion"],
                };

                categorias.Add(aux);
            }

            return categorias;
        }

        public static bool Grabar(Categoria categoria)
        {
            AccesoDatos acceso = new AccesoDatos();
            string query = string.Format("INSERT INTO Categorias (Descripcion) VALUES ('{0}')", categoria.Descripcion);
            return acceso.Ejecutar(query) > 0;
        }

        public static bool Editar(Categoria categoria)
        {
            AccesoDatos acceso = new AccesoDatos();

            string query = string.Format("UPDATE Categorias SET Descripcion='" + categoria.Descripcion + "' WHERE Id='" + categoria.Id + "'");
            return acceso.Ejecutar(query) > 0;
        }

        public static bool Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                string query = string.Format("delete from CATEGORIAS where id = " + id);
                return datos.Ejecutar(query) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
