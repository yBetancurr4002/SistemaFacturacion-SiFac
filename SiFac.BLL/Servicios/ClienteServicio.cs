using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class ClienteServicio : ServicioBase<Cliente>, IClienteServicio
    {
        public ClienteServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Clientes)
        {
        }
        
        // Implementaciones específicas para Cliente si son necesarias
    }
}
