using ClinicManagement.Entities;
using ClinicManagement.Models;

namespace ClinicManagement.Managers.Interfaces;

public interface IPacientManager
{
    public ValueTask<PacientModel?> GetPacientByPhone(string phoneNumber);
    public ValueTask<PacientModel?> GetPacientById(int id);
    public ValueTask<List<PacientModel>?> GetPacients();
    public ValueTask<bool> UpdatePacient(UpdatePacientModel updatePacient, int id);
    public ValueTask<bool> DeletePacient(int id);
    public ValueTask<bool> CreatePacient(CreatePacientModel createPacient);
}
