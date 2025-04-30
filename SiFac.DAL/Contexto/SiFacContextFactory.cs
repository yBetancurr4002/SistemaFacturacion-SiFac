using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace SiFac.DAL.Contextos
{
    public class SiFacContextFactory : IDesignTimeDbContextFactory<SiFacContext>
    {
        public SiFacContext CreateDbContext(string[] args)
        {
            // Construir la configuración leyendo el appsettings.json del proyecto API
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../SiFac.API")))
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<SiFacContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new SiFacContext(optionsBuilder.Options);
        }
    }
}
