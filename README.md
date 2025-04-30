# SistemaFacturacion-SiFac
Project Built for academic purposes

# SiFAC

La arquitectura de 3 capas es un patrón de diseño de software que divide una aplicación en tres capas lógicas distintas:

## Capa de Presentación (UI):

* Es la interfaz con la que interactúa el usuario.
* Se encarga de mostrar la información y capturar las acciones del usuario.
* No contiene lógica de negocio, solo se comunica con la capa de lógica de negocio.
* Ejemplos: Páginas web, aplicaciones de escritorio, aplicaciones móviles.

## Capa de Lógica de Negocio (BLL):

* Contiene las reglas y la lógica de negocio de la aplicación.
* Procesa los datos recibidos de la capa de presentación y los prepara para la capa de acceso a datos.
* No se preocupa por cómo se almacenan los datos, solo por cómo se procesan.
* Ejemplos: Clases que implementan las reglas de negocio, validaciones, cálculos.

## Capa de Acceso a Datos (DAL):

* Se encarga de la comunicación con la base de datos o cualquier otra fuente de datos.
* Realiza las operaciones de creación, lectura, actualización y eliminación (CRUD) de datos.
* Oculta los detalles de la implementación de la base de datos a las otras capas.
* Ejemplos: Clases que utilizan Entity Framework, ADO.NET, o cualquier otro ORM.

## Configurar un proyecto de N capas en Visual Studio Code

### Requisitos

Antes de comenzar, asegúrate de tener instaladas las siguientes herramientas: 

* Visual Studio Code : Descárgalo e instálalo.
* .NET SDK : Instala la versión más reciente del SDK de .NET.
* Entity Framework Core Tools : Instala las herramientas CLI de EF Core ejecutando: `dotnet tool install --global dotnet-ef`

### Crear proyecto

```bash
# Crear la solución - SistemaGestionGastos SiFac
dotnet new sln -n SiFac

# Crear proyectos individuales
dotnet new mvc -n SiFac.API       # Capa de Presentación
dotnet new classlib -n SiFac.BLL    # Capa de Lógica de Negocio
dotnet new classlib -n SiFac.DAL    # Capa de Acceso a Datos

# Agregar proyectos a la solución
dotnet sln add SiFac.API
dotnet sln add SiFac.BLL
dotnet sln add SiFac.DAL
```

### Configurar Dependencias entre Proyectos

```bash
# SiFac.API depende de BLL y DAL
dotnet add SiFac.API reference SiFac.BLL
# dotnet add SiFac.API reference SiFac.DAL

# SiFac.BLL depende de DAL
dotnet add SiFac.BLL reference SiFac.DAL
```


## Capa de Datos

## Arquitectura

```css
SiFac.DAL/
│
├── Contextos/
│   └── SiFacContext.cs           <-- Contexto principal de EF Core
│
├── Entidades/
│   ├── Persona.cs
│   ├── Cliente.cs
│   ├── Usuario.cs
│   ├── Producto.cs
│   ├── Factura.cs
│   ├── DetalleFactura.cs
│   ├── Rol.cs
│   ├── Permiso.cs
│   └── RolPermiso.cs
│
├── Repositorios/
│   ├── GenericRepository.cs       <-- Repositorio genérico base
│   ├── PersonaRepository.cs       <-- Implementación específica para Persona
│   ├── ClienteRepository.cs       <-- Implementación específica para Cliente
│   ├── UsuarioRepository.cs       <-- Implementación específica para Usuario
│   ├── ProductoRepository.cs      <-- Implementación específica para Producto
│   ├── FacturaRepository.cs       <-- Implementación específica para Factura
│   ├── DetalleFacturaRepository.cs <-- Implementación específica para DetalleFactura
│   ├── RolRepository.cs           <-- Implementación específica para Rol
│   ├── PermisoRepository.cs       <-- Implementación específica para Permiso
│   ├── RolPermisoRepository.cs    <-- Implementación específica para RolPermiso
│   └── UnitOfWork.cs              <-- Implementación del Unit of Work
│
└── ... (otros archivos de la capa de datos)
```

### Configuración de paquetes.

```bash
cd ../SiFac.DAL
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### **2. Diseño de la Entidad "Personas"**

### **Descripción**

La tabla `Personas` será la entidad base que contendrá información común para todos los tipos de personas en el sistema (por ejemplo, clientes, empleados, etc.). Esta tabla permitirá reutilizar datos y evitar redundancias.

### **Campos**

- `Id` (PK, int, autoincremental): Identificador único.
- `Nombre` (string): Nombre completo de la persona.
- `Direccion` (string): Dirección de residencia.
- `Telefono` (string): Número de contacto.
- `Email` (string): Correo electrónico.
- `FechaCreacion` (DateTime): Fecha de creación del registro.

### **3. Diseño de la Entidad "Clientes"**

### **Descripción**

La tabla `Clientes` heredará de `Personas` y añadirá atributos específicos para clientes, como un número de identificación fiscal (NIT) o un código de cliente.

### **Campos**

- `Id` (PK, FK, int): Hereda el `Id` de `Personas`.
- `CodigoCliente` (string): Código único para identificar al cliente.
- `Nit` (string): Número de identificación fiscal (opcional).

### **Relación**

- Relación de **herencia** : `Clientes` tiene una relación 1:1 con `Personas`.

### **4. Diseño de la Entidad "Usuarios"**

### **Descripción**

La tabla `Usuarios` permitirá gestionar la autenticación y autorización del sistema. Incluirá campos para roles y permisos.

### **Campos**

- `Id` (PK, int, autoincremental): Identificador único.
- `PersonaId` (FK, int): Referencia a la tabla `Personas`.
- `NombreUsuario` (string): Nombre de usuario único. (Opcional)
- `Contrasena` (string): Contraseña encriptada.
- `Rol` (string): Rol del usuario (ejemplo: "Administrador", "Vendedor").
- `Estado` (bit): Estado del usuario (activo/inactivo).
- `FechaCreacion` (DateTime): Fecha de creación del registro.

### **Relación**

- Relación de **herencia** : `Usuarios` tiene una relación 1:1 con `Personas`.

### 5. **Entidad: Productos**

### **Descripción**

La tabla `Productos` almacena la información de los productos o servicios que se ofrecen en el sistema. Esta entidad es esencial para registrar detalles como el nombre, precio y stock de cada producto, lo que permite su uso en la creación de facturas.

### **Campos**

- `Id` (PK, int, autoincremental): Identificador único del producto.
- `Nombre` (string): Nombre del producto o servicio.
- `Precio` (decimal): Precio unitario del producto.
- `Stock` (int): Cantidad disponible en inventario.
- `Descripcion` (string, opcional): Descripción adicional del producto.
- `FechaCreacion` (DateTime): Fecha de creación del registro.

### **Relaciones**

- Relación **1:N**  con `DetalleFactura`: Un producto puede aparecer en muchos detalles de factura.

### **Entidad: Facturas**

### **Descripción**

La tabla `Facturas` registra la información general de cada factura emitida. Contiene detalles como la fecha de emisión, el cliente asociado y el total calculado. Esta entidad actúa como un encabezado que agrupa los detalles de los productos vendidos.

### **Campos**

- `Id` (PK, int, autoincremental): Identificador único de la factura.
- `Fecha` (DateTime): Fecha y hora de emisión de la factura.
- `ClienteId` (FK, int): Identificador del cliente asociado a la factura.
- `Total` (decimal): Total calculado de la factura (suma de todos los subtotales de `DetalleFactura`).
- `Estado` (string, opcional): Estado de la factura (ejemplo: "Pendiente", "Pagada").
- `FechaCreacion` (DateTime): Fecha de creación del registro.

### **Relaciones**

- Relación **1:N**  con `DetalleFactura`: Una factura puede tener muchos detalles de factura.
- Relación **N:1**  con `Clientes`: Una factura está asociada a un solo cliente.

### **Entidad: DetalleFactura**

### **Descripción**

La tabla `DetalleFactura` almacena los detalles específicos de los productos incluidos en una factura. Cada registro representa un producto vendido, junto con su cantidad, precio unitario y subtotal calculado.

### **Campos**

- `Id` (PK, int, autoincremental): Identificador único del detalle de factura.
- `FacturaId` (FK, int): Identificador de la factura asociada.
- `ProductoId` (FK, int): Identificador del producto vendido.
- `Cantidad` (int): Cantidad de unidades vendidas del producto.
- `PrecioUnitario` (decimal): Precio unitario del producto en el momento de la venta.
- `Subtotal` (decimal, calculado): Subtotal calculado como `Cantidad * PrecioUnitario`.

### **Relaciones**

- Relación **N:1**  con `Facturas`: Un detalle de factura pertenece a una sola factura.
- Relación **N:1**  con `Productos`: Un detalle de factura está asociado a un solo producto.

### **6. Gestión de Roles y Permisos**

### **Descripción**

Para gestionar roles y permisos, puedes usar una tabla adicional llamada `Permisos` y una tabla intermedia `RolesPermisos`.

### Configuración del contexto

Ahora, implementemos el contexto de Entity Framework Core:

```cs
using Microsoft.EntityFrameworkCore;
using SiFac.DAL.Entidades;

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
```

### Repositorio

#### Repositorio Genérico

```cs
using Microsoft.EntityFrameworkCore;
using SiFac.DAL.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiFac.DAL.Repositorios
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly SiFacContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(SiFacContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
```

#### Repositorios específicos

```cs
using SiFac.DAL.Contextos;
using SiFac.DAL.Entidades;

namespace SiFac.DAL.Repositorios
{
    public class PersonaRepository : GenericRepository<Persona>
    {
        public PersonaRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class ClienteRepository : GenericRepository<Cliente>
    {
        public ClienteRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class UsuarioRepository : GenericRepository<Usuario>
    {
        public UsuarioRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class ProductoRepository : GenericRepository<Producto>
    {
        public ProductoRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class FacturaRepository : GenericRepository<Factura>
    {
        public FacturaRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class DetalleFacturaRepository : GenericRepository<DetalleFactura>
    {
        public DetalleFacturaRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class RolRepository : GenericRepository<Rol>
    {
        public RolRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class PermisoRepository : GenericRepository<Permiso>
    {
        public PermisoRepository(SiFacContext context) : base(context)
        {
        }
    }

    public class RolPermisoRepository : GenericRepository<RolPermiso>
    {
        public RolPermisoRepository(SiFacContext context) : base(context)
        {
        }
    }
}
```

## Patrón unit work

Implementamos el patrón Unit of Work para gestionar transacciones y centralizar el acceso a los repositorios.

Según el patrón Unit of Work (UoW) , el objetivo principal es centralizar y coordinar las operaciones de acceso a datos para garantizar la consistencia transaccional y evitar la duplicación de código. La implementación que has proporcionado está bien estructurada y sigue los principios del patrón UoW. Sin embargo, su ubicación dentro de la arquitectura debe ser cuidadosamente considerada para mantener una separación clara de responsabilidades.


### Configurando Presentation Layer

Finalmente, vamos a crear un script para la configuración de servicios de Entity Framework en el proyecto API:

```cs
// Add this code to Program.cs in the SiFac.API project

using Microsoft.EntityFrameworkCore;
using SiFac.DAL;
using SiFac.DAL.Contextos;

// ...

// Configuración de la base de datos
builder.Services.AddDbContext<SiFacContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el UnitOfWork como servicio
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ...
```

Y agrega al `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=SiFacDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  },
  "Logging": {
    "
```

## Capa Negocio

### Estrcutura

```cs
SiFac.BLL/
│
├── Interfaces/
│   ├── IPersonaServicio.cs
│   ├── IClienteServicio.cs
│   ├── IUsuarioServicio.cs
│   ├── IProductoServicio.cs
│   ├── IFacturaServicio.cs
│   ├── IRolServicio.cs
│   └── IPermisoServicio.cs
│
├── Servicios/
│   ├── PersonaServicio.cs
│   ├── ClienteServicio.cs
│   ├── UsuarioServicio.cs
│   ├── ProductoServicio.cs
│   ├── FacturaServicio.cs
│   ├── RolServicio.cs
│   └── PermisoServicio.cs
│
└── ServiceRegistration.cs 
```

 la capa de servicios (BLL - Business Logic Layer) para nuestro proyecto SiFac. Implementa las interfaces y los servicios que se conectarán con la capa de datos que hemos desarrollado previamente.

### Interfaces de Servicios:

* `IServicioBase<T>`: Interfaz base con operaciones CRUD genéricas
* Interfaces específicas para cada entidad del sistema (IPersonaServicio, IClienteServicio, etc.)
* Métodos especializados en interfaces específicas como autenticación de usuarios y gestión de facturas


### Implementaciones de Servicios:

`ServicioBase<T>`: Implementación base que proporciona operaciones CRUD genéricas
Servicios específicos para cada entidad que heredan de la clase base:

* PersonaServicio
* ClienteServicio
* UsuarioServicio (con lógica de autenticación)
* ProductoServicio (con lógica de gestión de inventario)
* FacturaServicio (con lógica compleja para crear facturas y actualizar stock)
* RolServicio y PermisoServicio

#### Registro de Servicios:

Método de extensión para registrar todos los servicios en el contenedor de inyección de dependencias

* Actualización de Program.cs: Código para incluir los servicios de negocio en la aplicación API

Esta implementación de la capa de servicios proporciona varios beneficios:

* Abstracción: Los controladores de la API solo interactúan con las interfaces de servicio, no directamente con los repositorios
* Encapsulamiento de la lógica de negocio: Toda la lógica compleja está en los servicios, no en los controladores
* Reutilización: La funcionalidad común está en la clase base
* Mantenibilidad: Cada servicio tiene una responsabilidad clara y específica
* Testabilidad: Las interfaces facilitan la creación de mocks para pruebas unitarias

### Interfaces

Generamos una interfaz base y a partir de ahí, extendemos interfaces específicas por entidad:

```cs
using SiFac.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SiFac.BLL.Interfaces
{
    public interface IServicioBase<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodosAsync();
        Task<T> ObtenerPorIdAsync(int id);
        Task<IEnumerable<T>> BuscarAsync(Expression<Func<T, bool>> predicado);
        Task CrearAsync(T entidad);
        Task CrearVariosAsync(IEnumerable<T> entidades);
        Task ActualizarAsync(T entidad);
        Task EliminarAsync(int id);
        Task EliminarVariosAsync(IEnumerable<T> entidades);
    }

    public interface IPersonaServicio : IServicioBase<Persona>
    {
        // Métodos específicos para Persona si son necesarios
    }

    public interface IClienteServicio : IServicioBase<Cliente>
    {
        // Métodos específicos para Cliente si son necesarios
    }

    public interface IUsuarioServicio : IServicioBase<Usuario>
    {
        Task<Usuario> AutenticarAsync(string nombreUsuario, string contrasena);
    }

    public interface IProductoServicio : IServicioBase<Producto>
    {
        Task ActualizarStockAsync(int productoId, int cantidad);
    }

    public interface IFacturaServicio : IServicioBase<Factura>
    {
        Task<Factura> CrearFacturaCompletaAsync(Factura factura, IEnumerable<DetalleFactura> detalles);
        Task<IEnumerable<Factura>> ObtenerFacturasPorClienteAsync(int clienteId);
    }

    public interface IRolServicio : IServicioBase<Rol>
    {
        // Métodos específicos para Rol si son necesarios
    }

    public interface IPermisoServicio : IServicioBase<Permiso>
    {
        // Métodos específicos para Permiso si son necesarios
    }
}
```


### Servicios

Implementamos un servicio base y un servicio por cada entidad específica:



#### Program.cs

Finalmente inyectar las dependencias:

```cs
// SiFac.BLL
using Microsoft.Extensions.DependencyInjection;
using SiFac.BLL.Interfaces;
using SiFac.BLL.Servicios;

namespace SiFac.BLL
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Registrar todos los servicios de negocio
            services.AddScoped<IPersonaServicio, PersonaServicio>();
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IProductoServicio, ProductoServicio>();
            services.AddScoped<IFacturaServicio, FacturaServicio>();
            services.AddScoped<IRolServicio, RolServicio>();
            services.AddScoped<IPermisoServicio, PermisoServicio>();
        }
    }
}
```

En `program.cs`:

```cs
using SiFac.BLL;

builder.Services.AddBusinessServices();
```

## Capa de presentación

### Estrcutura

```css
SiFac.API/
│
├── Controllers/              # Controladores MVC
│   ├── ClientesController.cs
│   ├── UsuariosController.cs
│   └── ProductosController.cs
│
├── Views/                    # Vistas Razor
│   ├── Clientes/
│   ├── Usuarios/
│   └── Productos/
│
├── Models/                   # ViewModels (opcionales)
│
├── wwwroot/                  # Archivos estáticos (CSS, JS, etc.)
│
├── appsettings.json          # Cadena de conexión
├── Program.cs
└── Startup.cs (si usas Startup)
```

### Migraciones

Ejecutar migraciones:

```bash
# cd SiFac.DAL
dotnet ef migrations add InitialCreate --startup-project ../SiFac.API
dotnet ef database update --startup-project ../SiFac.API
```
**Nota**

Si presentas el error similar a: `Unable to create a 'DbContext' of type 'RuntimeType'. The exception 'Unable to resolve service for type 'Microsoft.EntityFrameworkCore.DbContextOptions1[SiFac.DAL.Contextos.SiFacContext]' while attempting to activate 'SiFac.DAL.Contextos.SiFacContext'.' was thrown while attempting to create an instance. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728`.

1. Crea el archivo `C:\Users\Usuario\Documents\Docencia\HerramientasIII\Proyectos\SistemaFacturacion-SiFac\SiFac.DAL\Contexto\SiFacContextFactory.cs` (Revisa su contenido en el repositorio)
2. Soluciona errores resultantes.
3. Ejecuta nuevamente las migraciones.

### Primer ejecución

1. ubicate en la capa de presentación
2. ejecuta el comando: `dotnet watch run`

## Cliente
