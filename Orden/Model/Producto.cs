using System;
using System.ComponentModel.DataAnnotations;

namespace Orden.Model
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Costo { get; set; }
        public string Estado { get; set; }
    }
}
