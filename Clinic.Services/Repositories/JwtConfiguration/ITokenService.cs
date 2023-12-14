using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;

namespace Clinic.Services.Repositories.JwtConfiguration;

public interface ITokenService
{
    ValueTask<string> GenerateTokenAsync(Organization organization);
    
}