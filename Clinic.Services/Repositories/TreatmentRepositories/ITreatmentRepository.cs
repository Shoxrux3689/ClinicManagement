using Clinic.Domain.Dto_s;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.TreatmentRepositories;

public interface ITreatmentRepository
{
    ValueTask<TreatmentModel> AddTreatment(TreatmentDto treatmentDto);
    ValueTask<IEnumerable<TreatmentModel>> GetTreatments();
    ValueTask<TreatmentModel> GetTreatmentById(int organizationId,int treatmentId);
    ValueTask DeleteTreatment(int organizationId, int treatmentId);
    
}