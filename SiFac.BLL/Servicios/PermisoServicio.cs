using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class PermisoServicio : ServicioBase<Permiso>, IPermisoServicio
    {
        public PermisoServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Permisos)
        {
        }
        
        // Implementaciones específicas para Permiso si son necesarias
    }
}