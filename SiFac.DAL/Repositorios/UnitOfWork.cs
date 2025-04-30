using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;
using SiFac.DAL.Repositorios;
using System;
using System.Threading.Tasks;

namespace SiFac.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Persona> Personas { get; }
        GenericRepository<Cliente> Clientes { get; }
        GenericRepository<Usuario> Usuarios { get; }
        GenericRepository<Producto> Productos { get; }
        GenericRepository<Factura> Facturas { get; }
        GenericRepository<DetalleFactura> DetallesFactura { get; }
        GenericRepository<Rol> Roles { get; }
        GenericRepository<Permiso> Permisos { get; }
        GenericRepository<RolPermiso> RolesPermisos { get; }
        
        Task<int> CompleteAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly SiFacContext _context;
        private PersonaRepository _personaRepository;
        private ClienteRepository _clienteRepository;
        private UsuarioRepository _usuarioRepository;
        private ProductoRepository _productoRepository;
        private FacturaRepository _facturaRepository;
        private DetalleFacturaRepository _detalleFacturaRepository;
        private RolRepository _rolRepository;
        private PermisoRepository _permisoRepository;
        private RolPermisoRepository _rolPermisoRepository;

        public UnitOfWork(SiFacContext context)
        {
            _context = context;
        }

        public GenericRepository<Persona> Personas => _personaRepository ??= new PersonaRepository(_context);
        public GenericRepository<Cliente> Clientes => _clienteRepository ??= new ClienteRepository(_context);
        public GenericRepository<Usuario> Usuarios => _usuarioRepository ??= new UsuarioRepository(_context);
        public GenericRepository<Producto> Productos => _productoRepository ??= new ProductoRepository(_context);
        public GenericRepository<Factura> Facturas => _facturaRepository ??= new FacturaRepository(_context);
        public GenericRepository<DetalleFactura> DetallesFactura => _detalleFacturaRepository ??= new DetalleFacturaRepository(_context);
        public GenericRepository<Rol> Roles => _rolRepository ??= new RolRepository(_context);
        public GenericRepository<Permiso> Permisos => _permisoRepository ??= new PermisoRepository(_context);
        public GenericRepository<RolPermiso> RolesPermisos => _rolPermisoRepository ??= new RolPermisoRepository(_context);

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}