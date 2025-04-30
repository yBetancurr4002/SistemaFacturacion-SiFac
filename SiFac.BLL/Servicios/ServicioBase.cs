using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class ServicioBase<T> : IServicioBase<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly GenericRepository<T> _repository;

        public ServicioBase(IUnitOfWork unitOfWork, GenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> ObtenerTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<T> ObtenerPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado)
        {
            return await _repository.FindAsync(predicado);
        }

        public virtual async Task CrearAsync(T entidad)
        {
            await _repository.AddAsync(entidad);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task CrearVariosAsync(IEnumerable<T> entidades)
        {
            await _repository.AddRangeAsync(entidades);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task ActualizarAsync(T entidad)
        {
            _repository.Update(entidad);
            await _unitOfWork.CompleteAsync();
        }

        public virtual async Task EliminarAsync(int id)
        {
            var entidad = await _repository.GetByIdAsync(id);
            if (entidad != null)
            {
                _repository.Remove(entidad);
                await _unitOfWork.CompleteAsync();
            }
        }

        public virtual async Task EliminarVariosAsync(IEnumerable<T> entidades)
        {
            _repository.RemoveRange(entidades);
            await _unitOfWork.CompleteAsync();
        }
    }
}