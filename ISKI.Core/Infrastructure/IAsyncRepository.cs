using ISKI.Core.Infrastructure.Paging;
using ISKI.SARS.Core.Domain;

public interface IAsyncRepository<TEntity> where TEntity : BaseEntity<Guid>
{
    Task<PaginatedList<TEntity>> GetAllAsync(int pageNumber, int pageSize);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);  
    Task<TEntity?> DeleteAsync(Guid id);
}
