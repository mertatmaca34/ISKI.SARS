using ISKI.Core.Infrastructure;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class ReportTemplateRepository(SarsDbContext context)
    : EfRepositoryBase<ReportTemplate, int, SarsDbContext>(context), IReportTemplateRepository
{
    public async Task<PaginatedList<ReportTemplate>> GetByUserAsync(Guid userId, int pageNumber, int pageSize)
    {
        var query = _context.ReportTemplates
            .Include(x => x.ReportTemplateUsers)
            .Where(x => x.CreatedByUserId == userId || x.ReportTemplateUsers.Any(u => u.UserId == userId));

        var totalCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

        var data = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedList<ReportTemplate>
        {
            Items = data,
            Index = pageNumber,
            Size = pageSize,
            Count = totalCount,
            Pages = totalPages
        };
    }

    public async Task<ReportTemplate?> GetByIdForUserAsync(int id, Guid userId)
    {
        return await _context.ReportTemplates
            .Include(x => x.ReportTemplateUsers)
            .FirstOrDefaultAsync(x => x.Id == id && (x.CreatedByUserId == userId || x.ReportTemplateUsers.Any(u => u.UserId == userId)));
    }
}
