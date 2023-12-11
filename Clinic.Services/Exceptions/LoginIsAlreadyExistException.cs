namespace Clinic.Services.Repositories.OrganizationRepository;

public class LoginIsAlreadyExistException : Exception
{
    public LoginIsAlreadyExistException(string organizationDtoLogin) : base("Login is already exist")
    {
        
    }
}