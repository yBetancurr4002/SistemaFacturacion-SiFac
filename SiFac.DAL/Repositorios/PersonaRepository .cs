using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class PersonaRepository : GenericRepository<Persona>
{
    public PersonaRepository(SiFacContext context) : base(context)
    {
    }
}