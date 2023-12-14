namespace Clinic.Services.Exceptions;

public class LoginValidationException : Exception
{
    public LoginValidationException(): base("Login or password is incorrect please try again ")
    {

    }
    
}