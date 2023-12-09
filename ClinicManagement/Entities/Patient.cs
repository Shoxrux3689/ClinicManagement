using ClinicManagement.Enums;

namespace ClinicManagement.Entities;

public class Patient
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public ICollection<Visit>? Visits { get; set; }
    
}
