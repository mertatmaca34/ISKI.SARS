using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.Tags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Queries.GetTags;

public class GetTagsQuery : IRequest<PaginatedList<GetTagDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery? DynamicQuery { get; set; }
}
