using AutoMapper;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTags;

public class GetReportTemplateArchiveTagListQueryHandler(
    IReportTemplateArchiveTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetReportTemplateArchiveTagListQuery, PaginatedList<GetReportTemplateArchiveTagDto>>
{
    public async Task<PaginatedList<GetReportTemplateArchiveTagDto>> Handle(GetReportTemplateArchiveTagListQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync(
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize,
            request.DynamicQuery ?? new DynamicQuery());

        var mapped = mapper.Map<List<GetReportTemplateArchiveTagDto>>(list.Items);

        return new PaginatedList<GetReportTemplateArchiveTagDto>
        {
            Items = mapped,
            Index = list.Index,
            Size = list.Size,
            Count = list.Count,
            Pages = list.Pages
        };
    }
}
