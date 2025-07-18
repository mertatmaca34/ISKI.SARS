using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class ReportTemplateRepository(SarsDbContext context)
    : EfRepositoryBase<ReportTemplate, int, SarsDbContext>(context), IReportTemplateRepository
{
}
