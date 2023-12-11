namespace Clinic.ViewModel.Models;

public class VisitModel
{
    public int Id { get; set; }
    public DateTime? VisitDate { get; set; }
    public string Diagnosis { get; set; }
    public string Prescription { get; set; }
    public int PatientId { get; set; }
    public decimal Cost { get; set; }
}