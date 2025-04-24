using ISKI.SARS.Core.Domain;

namespace ISKI.Core.Infrastructure;
public interface IAsyncRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}
