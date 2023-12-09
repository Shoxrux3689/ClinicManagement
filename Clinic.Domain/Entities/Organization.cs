namespace Clinic.Domain.Entities;

public class Organization   
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public required string OrganizationName { get; set; }
    public ICollection<Patient>? Patients { get; set; }
    public ICollection<Treatment> Treatments { get; set; }
}
