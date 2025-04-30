using System;
using System.Collections.Generic;

namespace SiFac.DAL.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int ClienteId { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // Propiedades de navegación
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<DetalleFactura> DetallesFactura { get; set; }
    }
}
