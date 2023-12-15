using Clinic.Domain.Dto_s;
using Clinic.Domain.Entities;
using Clinic.ViewModel.Models;

namespace Clinic.Services.Repositories.VisitRepositories;

public interface IVisitRepository
{
    ValueTask<VisitModel> AddVisit(VisitDto visitDto);
    ValueTask<VisitModel> UpdateVisit(UpdateVisitDto visitDto);
    ValueTask<IEnumerable<VisitModel>> GetVisitsByPatientId(int patientId);
    ValueTask<IEnumerable<VisitModel>> GetVisits();
    ValueTask<VisitModel> GetVisitById(int visitId);
    ValueTask DeleteVisit( int visitId);
}