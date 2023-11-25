using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public string CodigoSeguimiento { get; set; }

        public string Estado {  get; set; }

        public decimal Total {  get; set; }

        public bool Envio {  get; set; }
        public List<DetalleCompra> Detalles { get; set; }
   
    }
}
