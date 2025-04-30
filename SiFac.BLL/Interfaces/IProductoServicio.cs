using SiFac.BLL.Interfaces;
using SiFac.DAL.Entidades;

public interface IProductoServicio : IServicioBase<Producto>
{
    Task ActualizarStockAsync(int productoId, int cantidad);
}
