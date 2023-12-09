using Clinic.Domain.Entities;
using Clinic.Domain.Enums;

namespace Clinic.Domain.Dto_s;

public class PatientDto
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public Gender Gender { get; set; }
}