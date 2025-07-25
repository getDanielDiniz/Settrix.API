using ComunTestsUtilities.Builders;
using IntegrationTests.Managers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Domain.Types;
using Settrix.Infraestructure.DataAccess;

namespace IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public UserEntityManager User_Employee;
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(services =>
            {
                var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                services.AddDbContext<SettrixDbContext>(config =>
                {
                    config.UseInMemoryDatabase("InMemoryDbForTesting");
                    config.UseInternalServiceProvider(provider);

                });
                    var dbContext = services.BuildServiceProvider().GetRequiredService<SettrixDbContext>();
                    var criptoHand = services.BuildServiceProvider().GetRequiredService<ICriptographyHanddle>();
                    var logginUser = services.BuildServiceProvider().GetRequiredService<ILogginUser>();
                    StartDatabase(dbContext, criptoHand, logginUser);
            });
    }

    private void StartDatabase(
        SettrixDbContext dbContext,
        ICriptographyHanddle criptographyHanddle,
        ILogginUser logginUser
    )
    {
        ADD_EMPLOYEE(dbContext, criptographyHanddle, logginUser);   
        
        dbContext.SaveChanges();
    }

    private void ADD_EMPLOYEE(
        SettrixDbContext dbContext,
        ICriptographyHanddle criptographyHanddle,
        ILogginUser logginUser
    )
    {
        User_Employee = new UserEntityManager(criptographyHanddle, logginUser)
            .WithRole(UserRoleType.Employee);
        dbContext.Users.Add(User_Employee.GetUser);
    }
}