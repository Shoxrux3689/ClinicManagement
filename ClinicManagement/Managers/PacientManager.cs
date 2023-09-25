using ClinicManagement.Entities;
using ClinicManagement.Managers.Interfaces;
using ClinicManagement.Models;
using ClinicManagement.Repositories.Interfaces;
using Mapster;

namespace ClinicManagement.Managers;

public class PacientManager : IPacientManager
{
    private readonly IPacientRepository _pacientRepository;

    public PacientManager(IPacientRepository pacientRepository)
    {
        _pacientRepository = pacientRepository;
    }

    public async Task<int> CreatePacient(CreatePacientModel createPacient)
    {
        var pacient = createPacient.Adapt<Pacient>();

        await _pacientRepository.CreatePacient(pacient);


    }

    public Task DeletePacient(int id)
    {
        throw new NotImplementedException();
    }

    public Task<PacientModel?> GetPacientById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<PacientModel>?> GetPacientsByFilter(PacientFilter pacientFilter)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePacient(UpdatePacientModel updatePacient, int id)
    {
        throw new NotImplementedException();
    }
}
