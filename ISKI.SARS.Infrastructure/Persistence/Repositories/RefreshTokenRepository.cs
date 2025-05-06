using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class RefreshTokenRepository(SarsDbContext context) : EfRepositoryBase<RefreshToken, Guid, SarsDbContext>(context), IRefreshTokenRepository
{
}
