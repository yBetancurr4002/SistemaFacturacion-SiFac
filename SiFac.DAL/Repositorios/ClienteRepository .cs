using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class ClienteRepository : GenericRepository<Cliente>
{
    public ClienteRepository(SiFacContext context) : base(context) {}
    
}