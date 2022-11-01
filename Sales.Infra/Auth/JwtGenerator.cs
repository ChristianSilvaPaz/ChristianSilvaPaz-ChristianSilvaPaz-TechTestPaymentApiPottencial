using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sales.Domain.Entities;
using Sales.Domain.Interfaces.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sales.Infra.Auth;

public class JwtGenerator : ITokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("TokenKey").Value);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Username),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
