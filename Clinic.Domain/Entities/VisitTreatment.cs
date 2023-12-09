namespace Clinic.Domain.Entities;

public class VisitTreatment
{
    public int  Id { get; set; }
    public int VisitId { get; set; }
    public Visit Visit { get; set; }
    public int TreatmentId { get; set; }
    public Treatment Treatment { get; set; }
}