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

        return pacient.Id;
    }

    public async Task DeletePacient(int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        if (pacient == null)
            throw new Exception("Pacient is not found!");

        await _pacientRepository.DeletePacient(pacient);
    }

    public async Task<PacientModel?> GetPacientById(int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);

        return pacient.Adapt<PacientModel>();
    }

    public async Task<List<PacientModel>?> GetPacientsByFilter(PacientFilter pacientFilter)
    {
        var pacients = await _pacientRepository.GetPacientsByFilter(pacientFilter);
        return pacients.Adapt<List<PacientModel>>();
    }

    public async Task UpdatePacient(UpdatePacientModel updatePacient, int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        if (pacient == null)
            throw new Exception("Pacient is not found!");

        pacient = updatePacient.Adapt<Pacient>();

        await _pacientRepository.UpdatePacient(pacient);
    }
}
