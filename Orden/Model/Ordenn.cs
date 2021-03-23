using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orden.Model
{
    public class Ordenn
    {
        [Key]
        public int Id { get; set; }
        public string Estado { get; set; }
        public DateTime? Fecha { get; set; }
        public string Cliente { get; set; }
        public string Costo { get; set; }
        [ForeignKey("Detalle")]
        public int DetalleId { get; set; }
        public Detalle Detalle { get; set; }
    }
}
