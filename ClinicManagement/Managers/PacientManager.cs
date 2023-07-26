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

    public async ValueTask<PacientModel?> GetPacientByPhone(string phoneNumber)
    {
        var pacient = await _pacientRepository.GetPacientByPhoneNumber(phoneNumber);
        var pacientModel = pacient?.Adapt<PacientModel>();
        return pacientModel;
    }

    public async ValueTask<PacientModel?> GetPacientById(int id)
    {
        var pacient = await _pacientRepository.GetPacientById(id);
        var pacientModel = pacient?.Adapt<PacientModel>();
        return pacientModel;
    }

    public async ValueTask<List<PacientModel>?> GetPacients()
    {
        var pacients = await _pacientRepository.GetPacients();
        var pacientModels = pacients?.Adapt<List<PacientModel>>();
        return pacientModels;
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
