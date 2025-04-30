using Microsoft.EntityFrameworkCore;
using SiFac.BLL.Interfaces;
using SiFac.DAL;
using SiFac.DAL.Entidades;
using System.Linq;
using System.Threading.Tasks;

namespace SiFac.BLL.Servicios
{
    public class UsuarioServicio : ServicioBase<Usuario>
    {
        public UsuarioServicio(IUnitOfWork unitOfWork) 
            : base(unitOfWork, unitOfWork.Usuarios)
        {
        }

        public async Task<Usuario> ValidarCredencialesAsync(string nombreUsuario, string contrasena)
        {
            // En un ambiente real, se debe usar hash para la contraseña, esto es solo para demostración
            var usuario = await _repository.FindAsync(u => 
                u.NombreUsuario == nombreUsuario && 
                u.Contrasena == contrasena && 
                u.Estado);
                
            return usuario.FirstOrDefault();
        }
      
    }
}
