using Settrix.Domain.Services.LoggedUser;

namespace Settrix.API.Token;

public class TokenProvider : ITokenProvider
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public TokenProvider(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    
    public string Get()
    {
        _httpContextAccessor
            .HttpContext!
            .Request
            .Headers
            .TryGetValue("Authorization", out var authorization);
        
        var token = authorization.ToString();
        
        return token["Bearer ".Length..].Trim();
    }
}