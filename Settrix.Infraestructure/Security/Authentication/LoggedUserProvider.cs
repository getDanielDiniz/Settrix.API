using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Settrix.Domain.Entities;
using Settrix.Domain.Services.LoggedUser;
using Settrix.Infraestructure.DataAccess;

namespace Settrix.Infraestructure.Security.Authentication;

public class LoggedUserProvider : ILoggedUserProvider
{
    private readonly SettrixDbContext _dbContext;
    private readonly ITokenProvider _tokenProvider;
    
    public LoggedUserProvider(SettrixDbContext dbContext, ITokenProvider tokenProvider)
    {
        _dbContext = dbContext;    
        _tokenProvider = tokenProvider;
    }
    
    public async Task<User> Get()
    {
        var token = _tokenProvider.Get();
        
        JwtSecurityTokenHandler handler = new();
        var tokenString = handler.ReadJwtToken(token);
        var securityId = tokenString.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
        
        
        var user = await _dbContext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.SecurityId == Guid.Parse(securityId));

        return user!;
    }
}