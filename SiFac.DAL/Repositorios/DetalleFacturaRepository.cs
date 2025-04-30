using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class DetalleFacturaRepository : GenericRepository<DetalleFactura>
{
    public DetalleFacturaRepository(SiFacContext context) : base(context){}
}