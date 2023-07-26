namespace ClinicManagement.Models;
public class CreatePacientModel
{
    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Shikoyat { get; set; }
    public string? Tashxis { get; set; }
    public string? Muolaja { get; set; }
    public long MuolajaPrice { get; set; }
    public long BerilganSumma { get; set; }
    public DateOnly ComeDate { get; set; }
}
