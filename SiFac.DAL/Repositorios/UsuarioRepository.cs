using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class UsuarioRepository : GenericRepository<Usuario>
{
    public UsuarioRepository(SiFacContext context) : base(context) {}

}