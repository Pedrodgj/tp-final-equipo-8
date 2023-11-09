using dominio;
using System.Collections.Generic;

namespace Negocio
{
    public class Imagenes
    {

        public static List<Imagen> Listar()
        {

            AccesoDatos acceso = new AccesoDatos();
            List<Imagen> imagenes = new List<Imagen>();

            var lector = acceso.Leer("SELECT Id, IdArticulo, ImagenUrl FROM Imagenes ORDER BY Id");

            while (lector.Read())
            {
                Imagen aux = new Imagen
                {
                    Id = (int)lector["Id"],
                    IdArticulo = (int)lector["IdArticulo"],
                    Url = (string)lector["ImagenUrl"],
                };

                imagenes.Add(aux);
            }

            return imagenes;
        }

        public static bool Grabar(Imagen imagen)
        {
            AccesoDatos acceso = new AccesoDatos();
            string query = string.Format("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES ({0},'{1}')", imagen.IdArticulo, imagen.Url);
            return acceso.Ejecutar(query) > 0;
        }

        public static List<Imagen> ByArticuloId(int id)
        {
            AccesoDatos acceso = new AccesoDatos();
            var lector = acceso.Leer("SELECT ImagenUrl FROM Imagenes WHERE IdArticulo = " + id);
            List<Imagen> imagenes = new List<Imagen>();

            while (lector.Read())
            {
                Imagen img = new Imagen()
                {
                    IdArticulo = id,
                    Url = (string)lector["ImagenUrl"],
                };

                imagenes.Add(img);
            }

            return imagenes;
        }
    }
}
