using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class InstantValueRepository(SarsDbContext context) : EfRepositoryBase<InstantValue, DateTime, SarsDbContext>(context), IInstantValueRepository
{
}