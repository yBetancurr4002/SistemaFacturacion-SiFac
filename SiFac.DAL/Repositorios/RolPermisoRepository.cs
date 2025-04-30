using SiFac.DAL.Contextos;
using SiFac.DAL.Repositorios;

public class RolPermisoRepository : GenericRepository<RolPermiso>
{
    public RolPermisoRepository(SiFacContext context) : base(context)
    {
    }
}