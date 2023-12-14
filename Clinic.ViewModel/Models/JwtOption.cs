namespace Clinic.ViewModel.Models;

public class JwtOption
{
    public string SigningKey { get; set; }
    public string ValidAudience { get; set; }
    public string ValidIssuer { get; set; }
    public int ExpiresInSeconds { get; set; }
    
}