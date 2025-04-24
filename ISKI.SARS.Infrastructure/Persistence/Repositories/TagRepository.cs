using ISKI.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Infrastructure.Persistence.Repositories;

public class TagRepository : EfRepositoryBase<Tags, SarsDbContext>, ITagRepository
{
    public TagRepository(SarsDbContext context) : base(context)
    {
    }

}