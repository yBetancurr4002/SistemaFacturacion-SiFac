using SiFac.DAL.Contextos;
using SiFac.DAL.Repositorios;

public class RolRepository : GenericRepository<Rol>
{
    public RolRepository(SiFacContext context) : base(context)
    {
    }
}