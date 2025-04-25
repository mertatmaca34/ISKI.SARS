using ISKI.Core.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.Core.Infrastructure.Paging;

public class PaginatedList<T> : BasePageableModel
{
    public List<T> Items { get; set; } = new();
}
