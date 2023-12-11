using Clinic.Domain.Enums;

namespace Clinic.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int OrganizationId { get; set; }
    public virtual Organization? Organization { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public virtual ICollection<Visit>? Visits { get; set; }
    
}
