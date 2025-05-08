using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class UserOperationClaimRepository(SarsDbContext context)
    : EfRepositoryBase<UserOperationClaim, int, SarsDbContext>(context), IUserOperationClaimRepository
{
    public async Task<List<OperationClaim>> GetClaims(User user)
    {
        return await _context.UserOperationClaims
            .Where(uoc => uoc.UserId == user.Id)
            .Include(uoc => uoc.OperationClaim)
            .Select(uoc => uoc.OperationClaim!)
            .ToListAsync();
    }
}
