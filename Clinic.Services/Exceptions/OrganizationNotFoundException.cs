namespace Clinic.Services.Repositories.OrganizationRepository;

public class OrganizationNotFoundException : Exception
{
    public OrganizationNotFoundException(int organizationId) : base("Organization is not found")
    {
        throw new NotImplementedException();
    }
   
}