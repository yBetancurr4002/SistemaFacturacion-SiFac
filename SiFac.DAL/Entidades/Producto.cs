using System;
using System.Collections.Generic;

namespace SiFac.DAL.Entidades
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        
        // Propiedades de navegación
        public virtual ICollection<DetalleFactura> DetallesFactura { get; set; }
    }
}
