namespace ClinicManagement.Entities;

public class User
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string PasswordHash { get; set; }
    public string? PhoneNumber { get; set; }
    public required string OrganizationName { get; set; }
    public List<Procedure>? Procedures { get; set; }
    public List<Pacient>? Pacients { get; set; }
}
