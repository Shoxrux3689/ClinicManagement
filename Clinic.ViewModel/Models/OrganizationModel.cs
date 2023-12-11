
namespace Clinic.ViewModel.Models;

public class OrganizationModel
{
    public int Id { get; set; }
    public  string Login { get; set; }
    public string? PhoneNumber { get; set; }
    public  string OrganizationName { get; set; }
    public ICollection<PatientModel>? Patients { get; set; }
    public ICollection<TreatmentModel>? Treatments { get; set; }
}