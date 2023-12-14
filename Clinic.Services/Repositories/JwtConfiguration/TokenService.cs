using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.ViewModel.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.Services.Repositories.JwtConfiguration;

public class TokenService : ITokenService
{
    private readonly JwtOption _jwtOption;

    public TokenService(IOptions<JwtOption> jwtOption)
    {
        _jwtOption = jwtOption.Value;
    }


    public async ValueTask<string> GenerateTokenAsync(Organization organization)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, organization.Id.ToString()),
            new Claim(ClaimTypes.Name, organization.Login),
        };
        var signingKey = Encoding.UTF32.GetBytes(_jwtOption.SigningKey);
        
        var security = new JwtSecurityToken(
            issuer: _jwtOption.ValidIssuer,
            audience: _jwtOption.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddSeconds(_jwtOption.ExpiresInSeconds),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(signingKey), 
                SecurityAlgorithms.HmacSha256)
        );
        var token = new JwtSecurityTokenHandler().WriteToken(security);
        return token;

    }
}