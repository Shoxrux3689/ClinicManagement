
namespace ClinicManagement.Entities;

public class Treatment
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public Organization Organization { get; set; }
    public int OrganizationId { get; set; }
    public ICollection<VisitTreatment>? VisitsTreatments { get; set; }
}
