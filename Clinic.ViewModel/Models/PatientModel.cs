using Clinic.Domain.Enums;

namespace Clinic.ViewModel.Models;

public class PatientModel
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public int OrganizationId { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual ICollection<VisitModel>? Visits { get; set; }
}