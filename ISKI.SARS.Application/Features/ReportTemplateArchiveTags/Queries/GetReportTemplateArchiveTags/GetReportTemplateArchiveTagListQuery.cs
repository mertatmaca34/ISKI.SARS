using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTags;

public class GetReportTemplateArchiveTagListQuery : IRequest<PaginatedList<GetReportTemplateArchiveTagDto>>
{
    public PageRequest PageRequest { get; set; } = new();
    public DynamicQuery? DynamicQuery { get; set; }
}
