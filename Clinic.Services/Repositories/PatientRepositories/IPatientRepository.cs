using Clinic.Domain.Dto_s;
using Clinic.Services.Filters;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.PatientRepositories;

public interface IPatientRepository
{
    ValueTask<PatientModel> AddPatient(int organizationId,PatientDto patientDto);
    ValueTask<IEnumerable<PatientModel>> GetPatients(PatientFilter filter);
    ValueTask<PatientModel> GetPatientById(int organizationId,int patientId);
    void DeletePatient(int organizationId, int patientId);

}