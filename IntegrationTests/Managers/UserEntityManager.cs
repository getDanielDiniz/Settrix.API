using ComunTestsUtilities.Builders;
using Settrix.Domain.Security.Authentication;
using Settrix.Domain.Security.Criptography;
using Settrix.Domain.Types;

namespace IntegrationTests.Managers;

public class UserEntityManager
{
    private Settrix.Domain.Entities.User User { get; }
    private string Token { get; }
    private string NotHashedPassword { get; }
    
    public UserEntityManager(
        ICriptographyHanddle criptographyHanddle,
        ILogginUser logginUser
    )
    {
        User = UserEntityBuilder.Build();
        NotHashedPassword = User.Password;
        User.Password = criptographyHanddle.HashPassword(User.Password);
        Token = logginUser.Generate(User);
    }
    
    //Callbacks to get the state
    public Settrix.Domain.Entities.User GetUser => User;
    public string GetToken => Token;
    public string GetNotHashedPassword => NotHashedPassword;
    
    //Builders to set the state
    public UserEntityManager WithRole(UserRoleType role)
    {
        User.Role = role;
        return this;
    }
    
    
}