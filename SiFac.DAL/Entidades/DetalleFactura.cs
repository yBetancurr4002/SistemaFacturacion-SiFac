namespace SiFac.DAL.Entidades
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        
        // Propiedad calculada
        public decimal Subtotal => Cantidad * PrecioUnitario;
        
        // Propiedades de navegación
        public virtual Factura Factura { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
