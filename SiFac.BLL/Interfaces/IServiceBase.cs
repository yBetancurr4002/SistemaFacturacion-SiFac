using SiFac.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiFac.BLL.Interfaces
{
    public interface IServicioBase<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerPorIdAsync(int id);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);
        Task CrearAsync(T entidad);
        Task CrearVariosAsync(IEnumerable<T> entidades);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);
        Task EliminarVariosAsync(IEnumerable<T> entidades);
    }
}
