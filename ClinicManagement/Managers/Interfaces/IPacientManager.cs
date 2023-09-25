using ClinicManagement.Entities;
using ClinicManagement.Models;

namespace ClinicManagement.Managers.Interfaces;

public interface IPacientManager
{
    Task<PacientModel?> GetPacientById(int id);
    Task<List<PacientModel>?> GetPacientsByFilter(PacientFilter pacientFilter);
    Task UpdatePacient(UpdatePacientModel updatePacient, int id);
    Task DeletePacient(int id);
    Task<int> CreatePacient(CreatePacientModel createPacient);
}
