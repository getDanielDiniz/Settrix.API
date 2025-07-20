using Settrix.Domain.Entities;

namespace Settrix.Domain.Security.Authentication;

public interface ILogginUser
{
    string Generate(User user);
}