using AutoMapper;
using Clinic.Data.Context;
using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.Services.Exceptions;
using Clinic.Services.Repositories.Generic;
using Clinic.ViewModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Services.Repositories.OrganizationRepository;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly IGenericRepository<Organization> _organizationRepository;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public OrganizationRepository(IMapper mapper, IGenericRepository<Organization> organizationRepository,
        AppDbContext appDbContext)
    {
        _mapper = mapper;
        _organizationRepository = organizationRepository;
        _appDbContext = appDbContext;
    }

    public async ValueTask<OrganizationModel> RegisterOrganization(OrganizationDto organizationDto)
    {
        if (IsLoginExist(organizationDto.Login).Result)
            throw new LoginIsAlreadyExistException(organizationDto.Login);
        var organization = _mapper.Map<Organization>(organizationDto);
        organization.PasswordHash =
            new PasswordHasher<OrganizationDto>().HashPassword(organizationDto, organizationDto.Password);
        await _organizationRepository.InsertAsync(organization);
        return _mapper.Map<OrganizationModel>(organization);
    }

    private async ValueTask<bool> IsLoginExist(string login)
    {
        var isLoginExist = await _organizationRepository.HasAnyAsync(c => c.Login == login);
        return isLoginExist;
    }

    public async ValueTask<IEnumerable<OrganizationModel>?> GetOrganizations()
    {
        var organizations = await _organizationRepository.SelectAll().ToListAsync();
        organizations.Select(c => c.Patients.Select(c => _mapper.Map<PatientModel>(c)));
        return _mapper.Map<IEnumerable<OrganizationModel>>(organizations);
    }

    public async ValueTask<OrganizationModel?> GetOrganizationById(int organizationId)
    {
        var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == organizationId);
        if (organization == null)
            throw new OrganizationNotFoundException(organizationId);
        return await new ValueTask<OrganizationModel?>(_mapper.Map<OrganizationModel>(organization));
    }

    public async ValueTask DeleteOrganization(int organizationId)
    {
        var organization = await _organizationRepository.SelectFirstAsync(c => c.Id == organizationId);
        if (organization == null)
            throw new OrganizationNotFoundException(organizationId);
        await _organizationRepository.DeleteAsync(organization);
    }
}