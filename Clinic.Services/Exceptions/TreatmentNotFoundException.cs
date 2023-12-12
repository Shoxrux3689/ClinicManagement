namespace Clinic.Services.Repositories.TreatmentRepositories;

public class TreatmentNotFoundException : Exception
{
    public TreatmentNotFoundException(int id) : base("Treatment with id: " + id + " not found")
    {
    }
}