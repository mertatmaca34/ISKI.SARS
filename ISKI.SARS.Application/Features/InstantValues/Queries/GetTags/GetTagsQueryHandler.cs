using AutoMapper;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Queries.GetTags;

public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, PaginatedList<GetTagDto>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public GetTagsQueryHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetTagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _tagRepository.GetAllAsync(
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize,
            request.DynamicQuery ?? new DynamicQuery()
        );

        var mappedTags = _mapper.Map<List<GetTagDto>>(tags.Items);

        return new PaginatedList<GetTagDto>
        {
            Items = mappedTags,
            Index = tags.Index,
            Size = tags.Size,
            Count = tags.Count,
            Pages = tags.Pages
        };
    }
}
