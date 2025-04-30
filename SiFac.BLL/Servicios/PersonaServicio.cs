using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class PersonaServicio : ServicioBase<Persona>, IPersonaServicio
    {
        public PersonaServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Personas)
        {
        }
        
        // Implementaciones específicas para Persona si son necesarias
    }
}
