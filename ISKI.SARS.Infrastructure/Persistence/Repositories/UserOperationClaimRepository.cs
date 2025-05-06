using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

class UserOperationClaimRepository(SarsDbContext context) : EfRepositoryBase<UserOperationClaim, SarsDbContext>(context), IUserOperationClaimRepository
{
}
