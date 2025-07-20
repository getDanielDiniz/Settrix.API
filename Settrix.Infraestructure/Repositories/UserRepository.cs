using Microsoft.EntityFrameworkCore;
using Settrix.Domain.Entities;
using Settrix.Domain.Repositories;
using Settrix.Infraestructure.DataAccess;

namespace Settrix.Infraestructure.Repositories;
internal class UserRepository : IWriteOnlyUserRepository, IReadOnlyUserRepository
{
    private readonly SettrixDbContext _context;
    public UserRepository(SettrixDbContext context)
    {
        _context = context;
    }
    public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EmailAlreadyExists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking() //Do not need to be trackable!
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}
