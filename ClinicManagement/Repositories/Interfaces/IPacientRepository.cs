namespace ClinicManagement.Repositories.Interfaces;

public interface IPacientRepository
{
    public ValueTask GetPacients();
    public ValueTask GetPacient();
}
