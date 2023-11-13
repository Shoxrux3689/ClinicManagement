using ClinicManagement.Entities;
using ClinicManagement.Filters;

namespace ClinicManagement.Repositories.Interfaces;

public interface IPacientRepository
{
    public Task<List<Pacient>?> GetPacientsByFilter(PacientFilter pacientFilter);
    public Task<Pacient?> GetPacientById(int pacientId);
    public Task<int> CreatePacient(Pacient pacient);
    public Task UpdatePacient(Pacient pacient);
    public Task DeletePacient(Pacient pacient);
}
