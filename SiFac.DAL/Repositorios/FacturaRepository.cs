using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class FacturaRepository : GenericRepository<Factura>
{
    public FacturaRepository(SiFacContext context) : base(context)
    {
    }
}