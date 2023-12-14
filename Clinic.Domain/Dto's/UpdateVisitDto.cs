namespace Clinic.Domain.Dto_s;

public class UpdateVisitDto
{
    public int VisitId { get; set; }
    public int PatientId { get; set; }
    public string? Complains { get; set; }
    public string? Diagnosis { get; set; }
    public string? Prescription { get; set; }
    public int? TreatmentId { get; set; }
    public decimal? Cost { get; set; }
}