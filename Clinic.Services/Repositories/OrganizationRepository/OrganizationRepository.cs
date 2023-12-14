using AutoMapper;
using Clinic.Data.Context;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.Generic;
using Clinic.Services.Repositories.JwtConfiguration;
using Clinic.ViewModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories.OrganizationRepository;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly IGenericRepository<Organization> _organizationRepository;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public OrganizationRepository(IMapper mapper, IGenericRepository<Organization> organizationRepository, ITokenService tokenService)
    {
        _mapper = mapper;
        _organizationRepository = organizationRepository;
        _tokenService = tokenService;
    }

    public async ValueTask<string> LoginOrganization(LoginOrganizationDto loginOrganizationDto)
    {
        var organization = await _organizationRepository.SelectFirstAsync
            (c => c.Login == loginOrganizationDto.Login);
        if (organization == null)
            throw new OrganizationNotFoundException();
        var result = new PasswordHasher<Organization>().VerifyHashedPassword(organization, organization.PasswordHash,
            loginOrganizationDto.Password);
        if (result != PasswordVerificationResult.Success)
        {
            throw new LoginValidationException();
        }
        
        var token = await _tokenService.GenerateTokenAsync(organization);
        return token;
    }

    public async ValueTask<OrganizationModel> AddOrganization(CreateOrganizationDto createOrganizationDto)
    {
        if (IsLoginExist(createOrganizationDto.Login).Result)
            throw new LoginIsAlreadyExistException(createOrganizationDto.Login);
        var organization = _mapper.Map<Organization>(createOrganizationDto);
        organization.PasswordHash =
            new PasswordHasher<Organization>().HashPassword
                (organization, createOrganizationDto.Password);
        await _organizationRepository.InsertAsync(organization);
        return _mapper.Map<OrganizationModel>(organization);
    }

    private async ValueTask<bool> IsLoginExist(string login)
    {
        var isLoginExist = await _organizationRepository.HasAnyAsync(c => c.Login == login);
        return isLoginExist;
    }
    
}
//
//     public async ValueTask<IEnumerable<OrganizationModel>?> GetOrganizations()
//     {
//         var organizations = await _organizationRepository.SelectAll().ToListAsync();
//         organizations.Select(c => c.Patients.Select(c => _mapper.Map<PatientModel>(c)));
//         return _mapper.Map<IEnumerable<OrganizationModel>>(organizations);
//     }
//
//     public async ValueTask<OrganizationModel?> GetOrganizationById(int organizationId)
//     {
//         var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == organizationId);
//         if (organization == null)
//             throw new OrganizationNotFoundException(organizationId);
//         return await new ValueTask<OrganizationModel?>(_mapper.Map<OrganizationModel>(organization));
//     }
//
//     public async ValueTask DeleteOrganization(int organizationId)
//     {
//         var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == organizationId);
//         if (organization == null)
//             throw new OrganizationNotFoundException(organizationId);
//         await _organizationRepository.DeleteAsync(organization);
//     }
// }