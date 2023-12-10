namespace Clinic.Services.Exceptions;

public class PatientNotFoundException : Exception
{
    public PatientNotFoundException(int patientId) : base($"Patient with id {patientId} is not found")
    {
    }
}