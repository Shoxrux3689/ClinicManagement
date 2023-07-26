using ClinicManagement.Entities;

namespace ClinicManagement.Repositories.Interfaces;

public interface IPacientRepository
{
    public ValueTask<List<Pacient>> GetPacients();
    public ValueTask<Pacient?> GetPacientById(int Id);
    public ValueTask<Pacient?> GetPacientByPhoneNumber(string phoneNumber);
    public ValueTask<Pacient?> GetPacientByName(string name);
    public ValueTask<bool> CreatePacient(Pacient pacient);
    public ValueTask<bool> UpdatePacient(Pacient pacient);
    public ValueTask<bool> DeletePacient(Pacient pacient);
}
