using ISKI.Core.Infrastructure.Paging;
using ISKI.SARS.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace ISKI.Core.Infrastructure;

public class EfRepositoryBase<TEntity, TContext>(TContext context) : IAsyncRepository<TEntity>
    where TEntity : BaseEntity<Guid>
    where TContext : DbContext
{
    protected readonly TContext _context = context;

    public virtual async Task<PaginatedList<TEntity>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Set<TEntity>().Where(x => x.DeletedAt == null);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<TEntity>
        {
            Items = data,
            Index = pageNumber,
            Size = pageSize,
            Count = totalCount,
            Pages = totalPages
        };
    }


    public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        => await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        entity.UpdatedAt = DateTime.UtcNow;
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> DeleteAsync(Guid id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null)
            return null;

        entity.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return entity;
    }
}