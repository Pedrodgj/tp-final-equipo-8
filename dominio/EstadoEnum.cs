using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum EstadoPedidoEnum
    {
        [System.ComponentModel.Description("Estado Nuevo")]
        NUEVO,
        [System.ComponentModel.Description("Estado Aceptado")]
        ACEPTADO,
        [System.ComponentModel.Description("Estado Enviado")]
        ENVIADO,
        [System.ComponentModel.Description("Estado Retirar")]
        LISTO_PARA_RETIRAR,
        [System.ComponentModel.Description("Estado Cancelado")]
        CANCELADO,
        [System.ComponentModel.Description("Estado Completado")]
        COMPLETADO
    }
}
