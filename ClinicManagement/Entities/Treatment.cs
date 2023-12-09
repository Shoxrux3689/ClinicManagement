
namespace ClinicManagement.Entities;

public class Treatment
{
    public int Id { get; set; }
    public required DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public decimal Cost { get; set; }
    public required string Description { get; set; }
    public int VisitId { get; set; }
    public Visit Visit { get; set; }
}
