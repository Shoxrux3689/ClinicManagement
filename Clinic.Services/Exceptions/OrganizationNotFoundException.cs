namespace Clinic.Services.Exceptions;

public class OrganizationNotFoundException : Exception
{
    public OrganizationNotFoundException(int organizationId) : base("Organization is not found")
    {
        
    }
   
}