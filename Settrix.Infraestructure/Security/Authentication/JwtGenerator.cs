using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Settrix.Domain.Entities;
using Settrix.Domain.Security.Authentication;

namespace Settrix.Infraestructure.Security.Authentication;

internal class JwtGenerator : ILogginUser
{
    private readonly string _signKey;
    private readonly string _issuer;
    private readonly int _hoursToExpire;

    public JwtGenerator(string signKey, int hoursToExpire,
        string issuer)
    {
        _signKey = signKey;
        _hoursToExpire = hoursToExpire;
        _issuer = issuer;
    }
    
    public string Generate(User user)
    {

        var claims = new ClaimsIdentity([
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
            new Claim(ClaimTypes.Sid, user.SecurityId.ToString())
        ]);

        var simKey = GenerateKey(_signKey);
        
        var opt = new SecurityTokenDescriptor()
        {
            Subject = claims,
            SigningCredentials = new SigningCredentials(simKey, SecurityAlgorithms.HmacSha256),
            Expires = DateTime.UtcNow.AddHours(_hoursToExpire),
            TokenType = "JWT",
            Issuer = _issuer,
            Audience = _issuer
            
        };
        
        JwtSecurityTokenHandler handler = new();
        var token = handler.CreateToken(opt);
        var tokenString = handler.WriteToken(token);
        
        return tokenString;
    }


    private SymmetricSecurityKey GenerateKey(string key)
    {
        return new SymmetricSecurityKey(Convert.FromBase64String(key));
    }
}