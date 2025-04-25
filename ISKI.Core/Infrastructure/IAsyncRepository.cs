using ISKI.SARS.Core.Domain;

namespace ISKI.Core.Infrastructure;
public interface IAsyncRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity>? DeleteAsync(Guid id);
}
