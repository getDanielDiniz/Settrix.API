using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Settrix.Domain.Repositories;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Domain.Services.LoggedUser;
using Settrix.Infraestructure.DataAccess;
using Settrix.Infraestructure.ExtensionMethods;
using Settrix.Infraestructure.Repositories;
using Settrix.Infraestructure.Security.Authentication;
using Settrix.Infraestructure.Security.Criptography;

namespace Settrix.Infraestructure;
public static class DependencyInjectionExtense
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddSecurity(services, configuration);
        services.AddScoped<ILoggedUserProvider, LoggedUserProvider>();
        
        if (!configuration.IsTestEnvironment())
        {
            //Only on Development or Production
            AddDatabase(services, configuration);
        }
    }

    private static void AddRepositories(IServiceCollection services) {
        services.AddScoped<IReadOnlyUserRepository, UserRepository>();
        services.AddScoped<IWriteOnlyUserRepository, UserRepository>();
    }
    
    private static void AddDatabase(IServiceCollection services, IConfiguration configuration) {
        var conStr = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<SettrixDbContext>(opt => opt.UseNpgsql(conStr));

    }

    private static void AddSecurity(IServiceCollection services, IConfiguration configuration)
    {
        //Password Hashing and Verifying
        services.AddScoped<ICriptographyHanddle, CriptographyHanddle>();
        
        //JWT Generation and Verifying
        var key = configuration["Jwt:SignInKey"];
        int expirationTime = int.Parse(configuration["Jwt:HoursToExpire"]!);
        var issuer = configuration["Jwt:Issuer"];
        services.AddScoped<ILogginUser>(provider => new JwtGenerator(key, expirationTime, issuer));
    }
}
