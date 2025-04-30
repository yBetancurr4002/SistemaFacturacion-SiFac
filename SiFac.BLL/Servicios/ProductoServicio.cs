using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class ProductoServicio : ServicioBase<Producto>, IProductoServicio
    {
        public ProductoServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Productos)
        {
        }
        
        public async Task ActualizarStockAsync(int productoId, int cantidad)
        {
            var producto = await _repository.GetByIdAsync(productoId);
            if (producto == null)
            {
                throw new Exception($"No se encontró el producto con ID {productoId}");
            }
            
            // Si la cantidad es negativa, se asume que es una venta y se reduce el stock
            if (producto.Stock + cantidad < 0)
            {
                throw new Exception("No hay suficiente stock para realizar esta operación");
            }
            
            producto.Stock += cantidad;
            await ActualizarAsync(producto);
        }
    }
}
