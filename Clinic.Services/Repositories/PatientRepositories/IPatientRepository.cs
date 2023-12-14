using Clinic.Domain.Dto_s;
using Clinic.Services.Filters;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.PatientRepositories;

public interface IPatientRepository
{
    ValueTask<PatientModel> AddPatient(PatientDto patientDto);
    ValueTask<PatientModel> UpdatePatient(UpdatePatientInfoDto patientDto);
    ValueTask<IEnumerable<PatientModel>?> GetPatients(PatientFilter filter);
    ValueTask<PatientModel?> GetPatientById(int organizationId, int patientId);
    ValueTask DeletePatient(int organizationId, int patientId);
}