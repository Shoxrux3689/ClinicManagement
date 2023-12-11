namespace Clinic.ViewModel.Models;

public class OrganizationModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string? PhoneNumber { get; set; }
    public string OrganizationName { get; set; }
    public virtual ICollection<PatientModel>? Patients { get; set; }
    public virtual ICollection<TreatmentModel>? Treatments { get; set; }
}