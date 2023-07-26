using ClinicManagement.Entities;
using ClinicManagement.Models;

namespace ClinicManagement.Managers.Interfaces;

public interface IPacientManager
{
    public ValueTask<Pacient?> GetPacientByPhone(string phoneNumber);
    public ValueTask<Pacient?> GetPacientById(int id);
    public ValueTask<List<Pacient>?> GetPacients();
    public ValueTask<bool> UpdatePacient(UpdatePacientModel updatePacient, int id);
    public ValueTask<bool> DeletePacient(int id);
    public ValueTask<bool> CreatePacient(CreatePacientModel createPacient);
}
