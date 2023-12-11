using Clinic.Domain.Dto_s;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.OrganizationRepository;

public interface IOrganizationRepository
{
    ValueTask<OrganizationModel> RegisterOrganization(OrganizationDto organizationDto);
    ValueTask<IEnumerable<OrganizationModel>?> GetOrganizations();
    ValueTask<OrganizationModel?> GetOrganizationById(int organizationId);
    ValueTask DeleteOrganization(int organizationId);
}