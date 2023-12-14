using Clinic.Domain.Enums;

namespace Clinic.Domain.Dto_s;

public class UpdatePatientInfoDto
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender? Gender { get; set; }
}