using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class TagRepository(SarsDbContext context) : EfRepositoryBase<Tag, Guid, SarsDbContext>(context), ITagRepository
{
}