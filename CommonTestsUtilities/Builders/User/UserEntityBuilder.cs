using Bogus;
using Settrix.Domain.Entities;
using Settrix.Domain.Types;

namespace ComunTestsUtilities.Builders;

public abstract class UserEntityBuilder
{
    public static User Build()
    {
        return new Faker<User>()
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.Password, f => f.Internet.Password(12, prefix: "Mud@"))
            .RuleFor(u => u.Role, _ => UserRoleType.Employee)
            .RuleFor(u => u.CompanyId, f => f.Random.Long(min: 1))
            .RuleFor(u => u.CreatedBy, f => f.Random.Long(min:1))
            .Generate()
            ;
    }
}