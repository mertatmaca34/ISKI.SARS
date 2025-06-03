using AutoMapper;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTags;

public class GetReportTemplateTagListQueryHandler(
    IReportTemplateTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetReportTemplateTagListQuery, PaginatedList<GetReportTemplateTagDto>>
{
    public async Task<PaginatedList<GetReportTemplateTagDto>> Handle(GetReportTemplateTagListQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync(
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize,
            request.DynamicQuery ?? new DynamicQuery()
        );

        var mapped = mapper.Map<List<GetReportTemplateTagDto>>(list.Items);

        return new PaginatedList<GetReportTemplateTagDto>
        {
            Items = mapped,
            Index = list.Index,
            Size = list.Size,
            Count = list.Count,
            Pages = list.Pages
        };
    }
}