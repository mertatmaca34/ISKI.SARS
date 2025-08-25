using ISKI.Core.Infrastructure;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Domain.Entities;
using System;

namespace ISKI.SARS.Domain.Services;

public interface IReportTemplateRepository : IAsyncRepository<ReportTemplate, int>
{
    Task<PaginatedList<ReportTemplate>> GetByUserAsync(Guid userId, int pageNumber, int pageSize);
    Task<ReportTemplate?> GetByIdForUserAsync(int id, Guid userId);
}
