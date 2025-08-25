using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTags;

public class GetArchiveTagListQuery : IRequest<PaginatedList<GetArchiveTagDto>>
{
    public PageRequest PageRequest { get; set; } = new();
    public DynamicQuery? DynamicQuery { get; set; }
}
