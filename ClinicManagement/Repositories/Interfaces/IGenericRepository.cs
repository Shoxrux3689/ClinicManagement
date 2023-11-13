namespace ClinicManagement.Repositories.Interfaces;

public interface IGenericRepository<TEntity, TId>
{
    Task<TId> AddEntityAsync(TEntity entity);
    Task<TEntity> GetByIdAsync();
    Task<List<TEntity>> GetAllAsync();
    Task DeleteEntityAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
}
