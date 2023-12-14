namespace Clinic.ViewModel.Models;

public class VisitTreatmentModel
{
    public int Id { get; set; }
    public int VisitId { get; set; }
    public int TreatmentId { get; set; }
    public DateTime Date { get; set; }
    
}