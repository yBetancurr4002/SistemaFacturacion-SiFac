using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;

public class ProductoRepository : GenericRepository<Producto>
{
    public ProductoRepository(SiFacContext context) : base(context)
    {
    }
}