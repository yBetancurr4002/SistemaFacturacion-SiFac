using SiFac.BLL.Interfaces;
using SiFac.DAL.Entidades;

public interface IFacturaServicio : IServicioBase<Factura>
{
    Task<Factura> CrearFacturaCompletaAsync(Factura factura, IEnumerable<DetalleFactura> detalles);
    Task<IEnumerable<Factura>> ObtenerFacturasPorClienteAsync(int clienteId);
}