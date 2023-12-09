namespace ClinicManagement.Entities;

public class Visit
{
    public int Id { get; set; }
    public required DateTime VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public decimal Cost { get; set; }
    public ICollection<VisitTreatment>? VisitsTreatments { get; set; }
}
