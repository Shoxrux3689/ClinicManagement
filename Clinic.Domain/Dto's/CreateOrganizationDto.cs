namespace Clinic.Domain.Dto_s;

public class CreateOrganizationDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string OrganizationName { get; set; }
}