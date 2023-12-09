namespace Clinic.Domain.Dto_s;

public class TreatmentDto
{
    public int Id { get; set; }
    public required string TreatmentName { get; set; }
    public int OrganizationId { get; set; }
}