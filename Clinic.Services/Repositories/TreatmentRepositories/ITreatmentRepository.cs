using Clinic.Domain.Dto_s;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.TreatmentRepositories;

public interface ITreatmentRepository
{
    Task<TreatmentModel> AddTreatmentAsync(TreatmentDto treatmentDto);
    Task<TreatmentModel> GetTreatmentByIdAsync(int id);
    Task<IEnumerable<TreatmentModel>> GetTreatmentsAsync();
    Task<TreatmentModel> UpdateTreatmentAsync(TreatmentDto treatmentDto);
    Task DeleteTreatmentAsync(int id);
}