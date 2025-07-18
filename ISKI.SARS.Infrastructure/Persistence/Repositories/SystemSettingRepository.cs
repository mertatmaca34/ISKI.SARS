using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class SystemSettingRepository(SarsDbContext context)
    : EfRepositoryBase<SystemSetting, int, SarsDbContext>(context), ISystemSettingRepository
{
}
