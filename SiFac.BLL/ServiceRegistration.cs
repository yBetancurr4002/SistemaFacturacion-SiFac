using Microsoft.Extensions.DependencyInjection;
using SiFac.BLL.Interfaces;
using SiFac.BLL.Servicios;

namespace SiFac.BLL
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonaServicio, PersonaServicio>();
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<UsuarioServicio>();
            services.AddScoped<IProductoServicio, ProductoServicio>();
            services.AddScoped<IFacturaServicio, FacturaServicio>();
            services.AddScoped<IRolServicio, RolServicio>();
            services.AddScoped<IPermisoServicio, PermisoServicio>();
        }
    }
}