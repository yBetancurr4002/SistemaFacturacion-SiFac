using Microsoft.EntityFrameworkCore;
using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class FacturaServicio : ServicioBase<Factura>, IFacturaServicio
    {
        private readonly IProductoServicio _productoServicio;
        
        public FacturaServicio(IUnitOfWork unitOfWork, IProductoServicio productoServicio) 
            : base(unitOfWork, unitOfWork.Facturas)
        {
            _productoServicio = productoServicio;
        }
        
        public async Task<Factura> CrearFacturaCompletaAsync(Factura factura, IEnumerable<DetalleFactura> detalles)
        {
            // Verificar que la factura y los detalles sean válidos
            if (factura == null)
            {
                throw new ArgumentNullException(nameof(factura));
            }
            
            if (detalles == null || !detalles.Any())
            {
                throw new ArgumentException("La factura debe tener al menos un detalle");
            }
            
            // Calcular el total de la factura basado en los detalles
            factura.Total = detalles.Sum(d => d.Cantidad * d.PrecioUnitario);
            
            // Establecer la fecha si no está definida
            if (factura.Fecha == DateTime.MinValue)
            {
                factura.Fecha = DateTime.Now;
            }
            
            // Crear la factura
            await _repository.AddAsync(factura);
            await _unitOfWork.CompleteAsync();
            
            // Asociar los detalles a la factura creada
            foreach (var detalle in detalles)
            {
                detalle.FacturaId = factura.Id;
                await _unitOfWork.DetallesFactura.AddAsync(detalle);
                
                // Actualizar el stock de productos
                await _productoServicio.ActualizarStockAsync(detalle.ProductoId, -detalle.Cantidad);
            }
            
            await _unitOfWork.CompleteAsync();
            
            return factura;
        }
        
        public async Task<IEnumerable<Factura>> ObtenerFacturasPorClienteAsync(int clienteId)
        {
            return await _repository.FindAsync(f => f.ClienteId == clienteId);
        }
    }
}
