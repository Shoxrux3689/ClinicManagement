namespace Clinic.Domain.Dto_s;

public class OrganizationDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public required string OrganizationName { get; set; }
}