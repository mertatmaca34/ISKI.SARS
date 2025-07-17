using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class SystemSettingsRepository : EfRepositoryBase<SystemSettings, SarsDbContext>, ISystemSettingsRepository
{
    public SystemSettingsRepository(SarsDbContext context) : base(context)
    {
    }
}
