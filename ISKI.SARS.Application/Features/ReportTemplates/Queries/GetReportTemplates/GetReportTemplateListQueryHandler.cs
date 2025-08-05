using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;
using System.Linq;

namespace ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplates;

public class GetReportTemplateListQueryHandler(
    IReportTemplateRepository repository,
    IMapper mapper)
    : IRequestHandler<GetReportTemplateListQuery, PaginatedList<GetReportTemplateDto>>
{
    public async Task<PaginatedList<GetReportTemplateDto>> Handle(GetReportTemplateListQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetByUserAsync(
            request.UserId,
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize);

        var mapped = mapper.Map<List<GetReportTemplateDto>>(list.Items);

        for (var i = 0; i < mapped.Count; i++)
            mapped[i].IsShared = list.Items[i].CreatedByUserId != request.UserId;

        return new PaginatedList<GetReportTemplateDto>
        {
            Items = mapped,
            Index = list.Index,
            Size = list.Size,
            Count = list.Count,
            Pages = list.Pages
        };
    }
}
