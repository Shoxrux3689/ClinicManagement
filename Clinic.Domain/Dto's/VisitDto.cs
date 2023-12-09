namespace Clinic.Domain.Dto_s;

public class VisitDto
{
    public int Id { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public int PatientId { get; set; }
    public decimal Cost { get; set; }
}