namespace Clinic.Domain.Entities;

public class Visit
{
    public int Id { get; set; }
    public required DateTime VisitDate { get; set; }
    public string Complains { get; set; }
    public string? Diagnosis { get; set; }
    public string? Prescription { get; set; }
    public int PatientId { get; set; }
    public virtual Patient? Patient { get; set; }
    public long Cost { get; set; }
    public virtual ICollection<VisitTreatment>? VisitsTreatments { get; set; }
}