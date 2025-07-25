using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Settrix.Application.Mapping;
using Settrix.Application.UseCases.Company.Create;
using Settrix.Application.UseCases.User.Create;
using Settrix.Application.UseCases.User.Login;

namespace Settrix.Application;
public static class DependencyInjectionExtense
{
    public static void AddApplication(this IServiceCollection services, IConfigurationBuilder configuration )
    {
        AddUseCases(services);
        AddMapper(services, configuration);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        //User UseCases
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        
        //Company UseCases
        services.AddScoped<ICreateCompanyUseCase, CreateCompanyUseCase>();
    }

    private static void AddMapper(IServiceCollection services, IConfigurationBuilder configuration) {
        services.AddAutoMapper(typeof(MappingProfile));
    }
}
