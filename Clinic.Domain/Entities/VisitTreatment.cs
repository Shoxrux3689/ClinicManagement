namespace Clinic.Domain.Entities;

public class VisitTreatment
{
    public int Id { get; set; }
    public int VisitId { get; set; }
    public virtual Visit? Visit { get; set; }
    public int TreatmentId { get; set; }
    public virtual Treatment? Treatment { get; set; }
}