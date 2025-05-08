using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class OperationClaimRepository(SarsDbContext context) : EfRepositoryBase<OperationClaim, int, SarsDbContext>(context), IOperationClaimRepository
{
}
