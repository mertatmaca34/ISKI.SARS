using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class SystemMetricRepository(SarsDbContext context)
    : EfRepositoryBase<SystemMetric, int, SarsDbContext>(context), ISystemMetricRepository
{
}
