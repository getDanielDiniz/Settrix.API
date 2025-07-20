using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Settrix.Infraestructure.DataAccess;

internal class SettrixDatabaseFactory: IDesignTimeDbContextFactory<SettrixDbContext>
{
    public SettrixDbContext CreateDbContext(string[] args)
    {
        //Config necessária para migrations funcionar
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        var configuration = builder.Build();
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        var optionsBuilder = new DbContextOptionsBuilder<SettrixDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new SettrixDbContext(optionsBuilder.Options);
    }
}