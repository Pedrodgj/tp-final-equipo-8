using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio

{
    public class Compras
    {
        //public static List<Articulo> Listar()
        //{
        //    AccesoDatos acceso = new AccesoDatos();
        //    List<Articulo> articulos = new List<Articulo>();

        //    var lector = acceso.Leer("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.Precio, a.IdCategoria, c.Descripcion as Categoria, a.IdMarca, m.Descripcion as Marca FROM Articulos a LEFT OUTER JOIN Categorias c ON c.Id = a.IdCategoria LEFT OUTER JOIN Marcas m ON m.Id = a.IdMarca ORDER BY a.Id");

        //    while (lector.Read())
        //    {
        //        Articulo aux = new Articulo
        //        {
        //            Id = (int)lector["Id"],
        //            Codigo = (string)lector["Codigo"],
        //            Nombre = (string)lector["Nombre"],
        //            Precio = (decimal)lector["Precio"],
        //            Descripcion = (string)lector["Descripcion"],
        //            IdCategoria = lector["IdCategoria"] != DBNull.Value ? (int)lector["IdCategoria"] : -1,
        //            Categoria = lector["Categoria"] != DBNull.Value ? (string)lector["Categoria"] : "",
        //            Marca = lector["Marca"] != DBNull.Value ? (string)lector["Marca"] : "",
        //            IdMarca = lector["IdMarca"] != DBNull.Value ? (int)lector["IdMarca"] : -1,
        //            Imagenes = Imagenes.ByArticuloId((int)lector["Id"]),
        //        };

        //        articulos.Add(aux);
        //    }

        //    return articulos;
        //}



        public static bool GrabarCompra(Compra compras)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<string> query = new List<string> {
                string.Format("INSERT INTO Compras (IdUsuario) VALUES ( " + compras.IdUsuario + ")")
            };

            foreach (var detalle in compras.Detalles)
            { 
                query.Add(string.Format("INSERT INTO DetalleCompra (IdCompra, IdArticulo, Cantidad, PrecioUnitario, Total) VALUES ((SELECT MAX(Id) FROM Compras), '{0}', '{1}', '{2}', '{3}')", detalle.IdArticulo, detalle.Cantidad, detalle.PrecioUnitario, detalle.Total));
            }

            return acceso.Ejecutar(query) > 0;
        }

        public static List<Compra> ListarCompraPorUsuario(int IdUsuario)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<Compra> compras = new List<Compra>();

            var lector = acceso.Leer("SELECT co.Id as IdCompra, co.FechaCompra, co.IdUsuario FROM Compras as co WHERE co.IdUsuario = " + IdUsuario + " ORDER BY co.FechaCompra");

            while (lector.Read())
            {
                Compra aux = new Compra
                {
                    Id = (int)lector["IdCompra"],
                    IdUsuario = (int)lector["IdUsuario"],
                    FechaCompra = (DateTime)lector["FechaCompra"],
                };

                compras.Add(aux);
            }

            return compras;
        }

        public static List<DetalleCompra> ListarDetallePorId(int IdCompra)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<DetalleCompra> detalles = new List<DetalleCompra>();

            var lector = acceso.Leer("SELECT * FROM DetalleCompra as dc WHERE dc.IdCompra = " + IdCompra + "");

            while (lector.Read())
            {
                DetalleCompra aux = new DetalleCompra
                {
                    IdCompra = (int)lector["IdCompra"],
                    IdArticulo = (int)lector["IdArticulo"],
                    Cantidad = (int)lector["Cantidad"],
                    PrecioUnitario = (decimal)lector["PrecioUnitario"],
                    Total = (decimal)lector["Total"]
                };

                detalles.Add(aux);
            }

            return detalles;
        }
    }    
}
