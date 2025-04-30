using SiFac.BLL.Interfaces;
using SiFac.DAL.Entidades;

namespace SiFac.BLL.Interfaces
{

  public interface IUsuarioServicio : IServicioBase<Usuario>
  {
      Task<bool> ValidarCredencialesAsync(string nombreUsuario, string contrasena);
      // Task CambiarContrasenaAsync(int usuarioId, string nuevaContrasena);
      // Task<IEnumerable<Usuario>> ObtenerUsuariosPorRolAsync(int rolId);
  }

}