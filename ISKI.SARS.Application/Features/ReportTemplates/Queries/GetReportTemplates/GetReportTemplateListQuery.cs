using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;
using System;

namespace ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplates;

public class GetReportTemplateListQuery : IRequest<PaginatedList<GetReportTemplateDto>>
{
    public PageRequest PageRequest { get; set; } = default!;
    public DynamicQuery? DynamicQuery { get; set; }
    public Guid UserId { get; set; }
}

