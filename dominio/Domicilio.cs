using System;
using System.Collections.Generic;

namespace dominio
{
    public class Domicilio
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public int Numero { get; set; }
        public int Piso { get; set; }
        public string Provincia { get; set; }
        public string Referencia { get; set; }
    }
}
