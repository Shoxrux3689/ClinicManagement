namespace Clinic.Services.Exceptions;

public class OrganizationIsNotExistsException : Exception
{
    public OrganizationIsNotExistsException(int id) : base($"Could not find organization with id : {id}")
    {
        
    }
    
}