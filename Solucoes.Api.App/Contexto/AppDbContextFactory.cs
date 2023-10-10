using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Solucoes.Modelo.Contexto;

namespace Solucoes.Api.App.Contexto
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Solucoes.Api.App"));

            return new AppDbContext(builder.Options);

        }
    }
}
