using dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Negocio

{
    public class Compras
    {
        public static List<Compra> ListarCompras()
        {
            AccesoDatos acceso = new AccesoDatos();

            List<Compra> compras = new List<Compra>();

            var lector = acceso.Leer("SELECT * FROM Compras");

            while (lector.Read())
            {
                Compra aux = new Compra
                {
                    Id = (int)lector["Id"],
                    IdUsuario = (int)lector["IdUsuario"],
                    FechaCompra = (DateTime)lector["FechaCompra"],
                    Estado = (string)lector["Estado"],
                    CodigoSeguimiento = (string)lector["CodigoSeguimiento"]
                }; 

                compras.Add(aux);
            }

            return compras;
        }



        public static bool GrabarCompra(Compra compras)
        {
            AccesoDatos acceso = new AccesoDatos();

            List<string> query = new List<string> {
                string.Format("INSERT INTO Compras (IdUsuario, CodigoSeguimiento, Estado) VALUES ('{0}', '{1}', '{2}')", compras.IdUsuario, ' ', compras.Estado)
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

            var lector = acceso.Leer("SELECT co.Id as IdCompra, co.FechaCompra, co.IdUsuario, co.Estado, co.CodigoSeguimiento FROM Compras as co WHERE co.IdUsuario = " + IdUsuario + " ORDER BY co.FechaCompra");

            while (lector.Read())
            {
                Compra aux = new Compra
                {
                    Id = (int)lector["IdCompra"],
                    IdUsuario = (int)lector["IdUsuario"],
                    FechaCompra = (DateTime)lector["FechaCompra"],
                    Estado = (string)lector["Estado"],
                    CodigoSeguimiento = (string)lector["CodigoSeguimiento"]
                };

                compras.Add(aux);
            }

            return compras;
        }

        public static List<DetalleCompra> ListarDetalles()
        {
            AccesoDatos acceso = new AccesoDatos();

            List<DetalleCompra> detalles = new List<DetalleCompra>();

            var lector = acceso.Leer("SELECT * FROM DetalleCompra");

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
