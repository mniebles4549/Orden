using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orden.Model
{
    public class Detalle
    {
        [Key]
        public int Id { get; set; }
        public string No_item  { get; set; }
        public string Cantidad { get; set; }
        public string Costo { get; set; }
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
