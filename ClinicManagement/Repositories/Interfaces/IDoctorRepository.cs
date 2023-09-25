using ClinicManagement.Entities;

namespace ClinicManagement.Repositories.Interfaces;

public interface IDoctorRepository
{
    Task<int> CreateDoctor(Doctor doctor);
    Task UpdateDoctor(Doctor doctor);
    Task<Doctor?> GetDoctorById(int doctorId);
}
