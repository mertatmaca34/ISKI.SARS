using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class UserRepository(SarsDbContext context) : EfRepositoryBase<User, Guid, SarsDbContext>(context), IUserRepository
{
    public override async Task<User?> DeleteAsync(User entity)
    {
        var existingEntity = await _context.Set<User>().FindAsync(entity.Id);
        if (existingEntity == null)
            return null;

        existingEntity.DeletedAt = DateTime.UtcNow;
        existingEntity.Status = false;
        await _context.SaveChangesAsync();
        return existingEntity;
    }

    public override async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(x => x.Id.Equals(id) && x.DeletedAt == null && x.Status);
    }

    public override async Task<PaginatedList<User>> GetAllAsync(int pageNumber, int pageSize)
    {
        var query = _context.Set<User>().Where(x => x.DeletedAt == null && x.Status);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<User>
        {
            Items = data,
            Index = pageNumber,
            Size = pageSize,
            Count = totalCount,
            Pages = totalPages
        };
    }

    public override async Task<PaginatedList<User>> GetAllAsync(int pageNumber, int pageSize, DynamicQuery dynamicQuery)
    {
        var query = _context.Set<User>().Where(x => x.DeletedAt == null && x.Status);
        query = query.ApplyDynamicQuery(dynamicQuery);

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<User>
        {
            Items = data,
            Index = pageNumber,
            Size = pageSize,
            Count = totalCount,
            Pages = totalPages
        };
    }

    public override async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IQueryable<User>>? include = null)
    {
        IQueryable<User> query = _context.Set<User>().Where(x => x.DeletedAt == null && x.Status);

        if (include is not null)
            query = include(query);

        return await query.Where(predicate).ToListAsync();
    }
}
