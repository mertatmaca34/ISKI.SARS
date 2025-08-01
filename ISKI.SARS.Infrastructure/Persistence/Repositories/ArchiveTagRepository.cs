using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class ArchiveTagRepository(SarsDbContext context)
    : EfRepositoryBase<ArchiveTag, int, SarsDbContext>(context), IArchiveTagRepository
{
}
