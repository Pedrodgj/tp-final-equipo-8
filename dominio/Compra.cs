using System;
using System.Collections.Generic;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public string CodigoSeguimiento { get; set; }

        public List<DetalleCompra> Detalles { get; set; }
   
    }
}
