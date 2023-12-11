namespace Clinic.Services.Exceptions;

public class VisitNotFoundException : Exception
{
    public VisitNotFoundException(int visitId) : base($"Visit with id {visitId} is not found")
    {
    }
}