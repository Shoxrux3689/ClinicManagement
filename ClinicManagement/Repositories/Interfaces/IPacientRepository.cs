using ClinicManagement.Entities;
using ClinicManagement.Filters;

namespace ClinicManagement.Repositories.Interfaces;

public interface IPacientRepository<TEntity, TId> : IGenericRepository<TEntity, TId>
{
    public Task<List<Pacient>?> GetPacientsByFilter(PacientFilter pacientFilter);
}
