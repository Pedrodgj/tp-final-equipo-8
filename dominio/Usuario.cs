using System;
using System.Collections.Generic;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Activo { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public int IdTipoUsuario { get; set; }
        public int IdDomicilio { get; set; }
    }
}
