namespace ClinicManagement.Entities;

public class VisitProcedure
{
    public int Id { get; set; }
    public Visit? Visit { get; set; }
    public int VisitId { get; set; }
    public Procedure? Procedure { get; set; }
    public short ProcedureId { get; set; }
}
