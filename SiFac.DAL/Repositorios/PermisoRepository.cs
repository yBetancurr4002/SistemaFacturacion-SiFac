using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class PermisoRepository : GenericRepository<Permiso>
{
    public PermisoRepository(SiFacContext context) : base(context)
    {
    }
}