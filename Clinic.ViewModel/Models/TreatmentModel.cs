namespace Clinic.ViewModel.Models;

public class TreatmentModel
{
    public int Id { get; set; }
    public required string TreatmentName { get; set; }
    public int OrganizationId { get; set; }
}