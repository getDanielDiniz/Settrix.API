using Settrix.Domain.Entities;

namespace Settrix.Domain.Services.LoggedUser;

public interface ILoggedUserProvider
{
    public Task<User> Get();
}