using ISKI.Core.Infrastructure;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class UserRepository(SarsDbContext context) : EfRepositoryBase<User, SarsDbContext>(context), IUserRepository
{
}   