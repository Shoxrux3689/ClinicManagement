using ClinicManagement.Models.DoctorModels;

namespace ClinicManagement.Managers.Interfaces;

public interface IDoctorManager
{
    Task<int> CreateDoctor(CreateDoctorModel createDoctorModel);
    Task UpdateDoctor(UpdateDoctorModel updateDoctorModel);
    Task GetDoctorById (int doctorId);
}
