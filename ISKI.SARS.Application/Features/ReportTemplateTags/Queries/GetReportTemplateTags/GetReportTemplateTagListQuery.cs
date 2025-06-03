using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTags;

public class GetReportTemplateTagListQuery : IRequest<PaginatedList<GetReportTemplateTagDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery? DynamicQuery { get; set; }
}