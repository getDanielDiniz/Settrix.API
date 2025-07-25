using Bogus;
using Settrix.Comunication.DTO_s.Request;

namespace ComunTestsUtilities.Builders;

public abstract class RequestCredentialLoginBuilder
{
    public static RequestLoginCredentialsJson Build()
    {
        return new Faker<RequestLoginCredentialsJson>()
            .RuleFor(rcl => rcl.Email, f => f.Internet.Email())
            .RuleFor(rcl => rcl.Password, f => f.Internet.Password(12, prefix: "Mud@"))
            .Generate();
            
    }
}