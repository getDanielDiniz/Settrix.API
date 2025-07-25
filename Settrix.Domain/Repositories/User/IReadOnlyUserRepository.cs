using Settrix.Domain.Entities;

namespace Settrix.Domain.Repositories;

public interface IReadOnlyUserRepository
{
    Task<bool> EmailAlreadyExists(string email);
    Task<User?> GetByEmail(string email); 
}