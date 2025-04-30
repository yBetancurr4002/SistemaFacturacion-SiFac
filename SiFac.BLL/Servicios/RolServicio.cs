using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class RolServicio : ServicioBase<Rol>, IRolServicio
    {
        public RolServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Roles)
        {
        }
        
        // Implementaciones específicas para Rol si son necesarias
    }

}