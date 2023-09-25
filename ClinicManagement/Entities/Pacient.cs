namespace ClinicManagement.Entities;

public class Pacient
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Shikoyat { get; set; }
    public string? Tashxis { get; set; }
    public long BerilganSumma { get; set; }
    public string? Description { get; set; }
    public string? PhotoPath{ get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public List<Visit>? Visits{ get; set; }
}
