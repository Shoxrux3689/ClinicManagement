namespace Clinic.Services.Exceptions;

public class OrganizationNotFoundException : Exception
{
    public OrganizationNotFoundException() : base("Organization is not found")
    {
    }
}