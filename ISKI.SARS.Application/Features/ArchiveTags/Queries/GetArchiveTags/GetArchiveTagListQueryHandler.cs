using AutoMapper;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTags;

public class GetArchiveTagListQueryHandler(
    IArchiveTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetArchiveTagListQuery, PaginatedList<GetArchiveTagDto>>
{
    public async Task<PaginatedList<GetArchiveTagDto>> Handle(GetArchiveTagListQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync(
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize,
            request.DynamicQuery ?? new DynamicQuery());

        var mapped = mapper.Map<List<GetArchiveTagDto>>(list.Items);

        return new PaginatedList<GetArchiveTagDto>
        {
            Items = mapped,
            Index = list.Index,
            Size = list.Size,
            Count = list.Count,
            Pages = list.Pages
        };
    }
}
