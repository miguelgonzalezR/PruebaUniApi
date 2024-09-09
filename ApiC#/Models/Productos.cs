using System.ComponentModel.DataAnnotations;

namespace ApiC_.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }

        public string NombreProducto { get; set; }

        public string DescripcionProducto { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public DateTime FechaIngreso { get; set; }

    }
}
