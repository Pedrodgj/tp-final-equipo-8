using dominio;
using System;
using System.Collections.Generic;

namespace Negocio

{
    public class Articulos
    {

        public static List<Articulo> Listar()
        {
            AccesoDatos acceso = new AccesoDatos();
            List<Articulo> articulos = new List<Articulo>();

            var lector = acceso.Leer("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca FROM Articulos a LEFT OUTER JOIN Categorias c ON c.Id = a.IdCategoria LEFT OUTER JOIN Marcas m ON m.Id = a.IdMarca ORDER BY a.Id");

            while (lector.Read())
            {
                Articulo aux = new Articulo
                {
                    Id = (int)lector["Id"],
                    Codigo = (string)lector["Codigo"],
                    Nombre = (string)lector["Nombre"],
                    Precio = (decimal)lector["Precio"],
                    Descripcion = (string)lector["Descripcion"],
                    IdCategoria = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : -1,
                    Categoria = lector["Categoria"] != DBNull.Value ? (string)lector["Categoria"] : "",
                    Marca = lector["Marca"] != DBNull.Value ? (string)lector["Marca"] : "",
                    IdMarca = lector["IdMarca"] != DBNull.Value ? (int)lector["IdMarca"] : -1,
                    Imagenes = Imagenes.ByArticuloId((int)lector["Id"]),
                };

                articulos.Add(aux);
            }

            return articulos;
        }

        public static Articulo Ver(string id)
        {
            AccesoDatos acceso = new AccesoDatos();
            Articulo aux = new Articulo();

            var lector = acceso.Leer("SELECT a.Id, Codigo, a.Nombre, a.Precio, a.Descripcion, a.IdMarca, a.IdCategoria, a.Precio, b.Descripcion AS Categoria, c.Descripcion AS Marca FROM Articulos AS a INNER JOIN Categorias AS b ON a.IdCategoria = b.Id INNER JOIN Marcas AS c ON a.IdMarca = c.Id WHERE a.Id = '" + id + "'");
            
            while (lector.Read())
            {

                aux.Id = (int)lector["Id"];
                aux.Codigo = (string)lector["Codigo"];
                aux.Nombre = (string)lector["Nombre"];
                aux.Precio = (decimal)lector["Precio"];
                aux.Descripcion = (string)lector["Descripcion"];
                aux.IdCategoria = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : -1;
                aux.Categoria = lector["Categoria"] != DBNull.Value ? (string)lector["Categoria"] : "";
                aux.Marca = lector["Marca"] != DBNull.Value ? (string)lector["Marca"] : "";
                aux.IdMarca = lector["IdMarca"] != DBNull.Value ? (int)lector["IdMarca"] : -1;
                aux.Imagenes = Imagenes.ByArticuloId((int)lector["Id"]);

            }

            return aux;
        }

        public static bool Existe(string codigo)
        {
            AccesoDatos acceso = new AccesoDatos();
            var lector = acceso.Leer("SELECT Id FROM Articulos WHERE Codigo = '" + codigo + "'");

            return lector.Read();
        }

        public static bool Grabar(Articulo articulo)
        {
            Console.WriteLine(articulo);
            AccesoDatos acceso = new AccesoDatos();
            
            List<string> query = new List<string> { 
                string.Format("INSERT INTO Articulos (Codigo, Nombre, Descripcion, IdCategoria, IdMarca, Precio) VALUES ('{0}','{1}','{2}',{3},{4},REPLACE(CAST({5} AS NVARCHAR), '.', ','))", articulo.Codigo, articulo.Nombre, articulo.Descripcion, articulo.IdCategoria, articulo.IdMarca, articulo.Precio.ToString().Replace(",", "."))
            };

            foreach (var imagen in articulo.Imagenes)
            {
                query.Add(string.Format("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES ((SELECT MAX(Id) FROM Articulos), '{0}')", imagen.Url));
            }

            return acceso.Ejecutar(query) > 0;
        }

        public static bool Editar(Articulo articulo)
        {
            AccesoDatos acceso = new AccesoDatos();
            List<string> query = new List<string>
            {
                string.Format("UPDATE Articulos SET Codigo='" + articulo.Codigo + "', Nombre='" + articulo.Nombre + "', Descripcion='" + articulo.Descripcion + "', IdCategoria='" + articulo.IdCategoria + "', IdMarca='" + articulo.IdMarca + "', Precio='" + articulo.Precio + "' WHERE Id='" + articulo.Id + "'"),
                string.Format("DELETE FROM Imagenes WHERE IdArticulo = '{0}'", articulo.Id)
            };

            foreach (var imagen in articulo.Imagenes)
            {
                query.Add(string.Format("INSERT INTO Imagenes (IdArticulo, ImagenUrl) VALUES ({0}, '{1}')", articulo.Id, imagen.Url));
            }

            return acceso.Ejecutar(query) > 0;
        }

        public static List<Articulo> Filtrar(string campo, string criterio, string filtro1, string filtro2)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                List<Articulo> articulos = new List<Articulo>();
                string query = string.Format("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca FROM Articulos a LEFT OUTER JOIN Categorias c ON c.Id = a.IdCategoria LEFT OUTER JOIN Marcas m ON m.Id = a.IdMarca where ");
                if(campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor que":
                            query += "a.Precio > " + filtro1;
                            break;
                        case "Menor que":
                            query += "a.Precio < " + filtro1;
                            break;
                        case "Entre":
                            query += "a.Precio between " + filtro1 + " and " + filtro2;
                            break;
                        default:
                            break;
                    }
                } else if (campo == "Marca")
                {
                    query += "m.Descripcion = " + "'" + criterio + "'";
                } 
                else
                {
                    query += "c.Descripcion = " + "'" + criterio + "'";
                }
                var lector = datos.Leer(query);
                while (lector.Read())
                {
                    Articulo aux = new Articulo
                    {
                        Id = (int)lector["Id"],
                        Codigo = (string)lector["Codigo"],
                        Nombre = (string)lector["Nombre"],
                        Precio = (decimal)lector["Precio"],
                        Descripcion = (string)lector["Descripcion"],
                        IdCategoria = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : -1,
                        Categoria = lector["Categoria"] != DBNull.Value ? (string)lector["Categoria"] : "",
                        Marca = lector["Marca"] != DBNull.Value ? (string)lector["Marca"] : "",
                        IdMarca = lector["IdMarca"] != DBNull.Value ? (int)lector["IdMarca"] : -1,
                        Imagenes = Imagenes.ByArticuloId((int)lector["Id"]),
                    };

                    articulos.Add(aux);
                }

                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                string query = string.Format("delete from Articulos where id = " + id);
                return datos.Ejecutar(query) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
