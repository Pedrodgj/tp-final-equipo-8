using System;
using System.Collections.Generic;

namespace dominio
{
    public class DetalleCompra
    {
        public int IdCompra { get; set; }
        public int IdArticulo { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

    }
}
