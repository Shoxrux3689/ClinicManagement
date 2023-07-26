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

    public async ValueTask<bool> CreatePacient(CreatePacientModel createPacient)
    {
        var pacient = createPacient.Adapt<Pacient>();
        await _pacientRepository.CreatePacient(pacient);
        return true;
    }

    public async ValueTask<bool> DeletePacient(int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        if (pacient == null)
            return false;
        
        var result = await _pacientRepository.DeletePacient(pacient);
        return result;
    }

    public async ValueTask<Pacient?> GetPacientByPhone(string phoneNumber)
    {
        var pacient = await _pacientRepository.GetPacientByPhoneNumber(phoneNumber);
        return pacient;
    }

    public async ValueTask<Pacient?> GetPacientById(int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        return pacient;
    }

    public async ValueTask<List<Pacient>?> GetPacients()
    {
        var pacients = await _pacientRepository.GetPacients();
        return pacients;
    }

    public async ValueTask<bool> UpdatePacient(UpdatePacientModel updatePacient, int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        if (pacient == null)
            return false;

        pacient = updatePacient.Adapt<Pacient>();

        var result = await _pacientRepository.UpdatePacient(pacient);
        return result;
    }
}
