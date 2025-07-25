using Bogus;
using Settrix.Comunication.DTO_s.Request;
using Settrix.Domain.Types;

namespace CommunTestsUtilities;

public abstract class RequestRegisterUserBuilder 
{
    public static RequestRegisterUserJson Build()
    {
        var faker = new Faker<RequestRegisterUserJson>()
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password,
                f => f.Internet.Password(12, prefix: "Mud@"))
            .RuleFor(u => u.Role, f => UserRoleType.Employee);

        return faker.Generate();
    }

}
