using SiFac.DAL.Entidades;
using Microsoft.EntityFrameworkCore;

namespace SiFac.DAL.Contextos
{
    public class SiFacContext : DbContext
    {
        public SiFacContext(DbContextOptions<SiFacContext> options) : base(options)
        {
        }
        
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetallesFactura { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Persona
            modelBuilder.Entity<Persona>(entity =>
            {
                entity.ToTable("Personas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Direccion).HasMaxLength(200);
                entity.Property(e => e.Telefono).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
            });
            
            // Configuración de Cliente
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CodigoCliente).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Nit).HasMaxLength(20);
                
                // Relación Cliente - Persona (1:1)
                entity.HasOne(c => c.Persona)
                      .WithOne()
                      .HasForeignKey<Cliente>(c => c.PersonaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Configuración de Usuario
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.NombreUsuario).HasMaxLength(50);
                entity.Property(e => e.Contrasena).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Rol).HasMaxLength(50);
                
                // Relación Usuario - Persona (1:1)
                entity.HasOne(u => u.Persona)
                      .WithOne()
                      .HasForeignKey<Usuario>(u => u.PersonaId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Configuración de Producto
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Descripcion).HasMaxLength(500);
            });
            
            // Configuración de Factura
            modelBuilder.Entity<Factura>(entity =>
            {
                entity.ToTable("Facturas");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Total).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Estado).HasMaxLength(20);
                
                // Relación Factura - Cliente (N:1)
                entity.HasOne(f => f.Cliente)
                      .WithMany()
                      .HasForeignKey(f => f.ClienteId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
            
            // Configuración de DetalleFactura
            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.ToTable("DetallesFactura");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18,2)");
                
                // Relación DetalleFactura - Factura (N:1)
                entity.HasOne(d => d.Factura)
                      .WithMany(f => f.DetallesFactura)
                      .HasForeignKey(d => d.FacturaId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                // Relación DetalleFactura - Producto (N:1)
                entity.HasOne(d => d.Producto)
                      .WithMany(p => p.DetallesFactura)
                      .HasForeignKey(d => d.ProductoId)
                      .OnDelete(DeleteBehavior.Restrict);
                
                // Ignorar la propiedad calculada
                entity.Ignore(d => d.Subtotal);
            });
            
            // Configuración de Rol
            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });
            
            // Configuración de Permiso
            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.ToTable("Permisos");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Descripcion).HasMaxLength(200);
            });
            
            // Configuración de RolPermiso
            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.ToTable("RolesPermisos");
                entity.HasKey(e => e.Id);
                
                // Relación RolPermiso - Rol (N:1)
                entity.HasOne(rp => rp.Rol)
                      .WithMany(r => r.RolesPermisos)
                      .HasForeignKey(rp => rp.RolId)
                      .OnDelete(DeleteBehavior.Cascade);
                
                // Relación RolPermiso - Permiso (N:1)
                entity.HasOne(rp => rp.Permiso)
                      .WithMany(p => p.RolesPermisos)
                      .HasForeignKey(rp => rp.PermisoId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}