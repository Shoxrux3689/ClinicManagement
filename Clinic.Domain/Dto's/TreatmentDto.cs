namespace Clinic.Domain.Dto_s;

public class TreatmentDto
{
    public required string TreatmentName { get; set; }
    public int OrganizationId { get; set; }
    public int PatientId { get; set; }
    public int VisitId { get; set; }
}