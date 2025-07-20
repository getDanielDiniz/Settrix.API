using Settrix.Domain.Entities;

namespace Settrix.Domain.Repositories;
public interface IWriteOnlyUserRepository
{
    Task CreateUser(User user);
}
