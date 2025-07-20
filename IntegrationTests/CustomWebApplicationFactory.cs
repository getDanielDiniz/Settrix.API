using ComunTestsUtilities.Builders;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Infraestructure.DataAccess;

namespace IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    private string _email { get; set; }
    private string _name { get; set; }
    private string _password { get; set; }
    
    public string GetEmail => _email;
    public string GetName => _name;
    public string GetPassword => _password;
    
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
                    StartDatabase(dbContext, criptoHand);
            });
    }

    private void StartDatabase(SettrixDbContext dbContext, ICriptographyHanddle criptographyHanddle)
    {
        var user = UserEntityBuilder.Build();
        _email = user.Email;
        _name = user.Name;
        _password = user.Password;
        
        user.Password = criptographyHanddle.HashPassword(user.Password);
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
    }
}