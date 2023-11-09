using System.Collections.Generic;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }

        public int Cantidad { get; set; }
        public List<Imagen> Imagenes { get; set; }

    }
}
