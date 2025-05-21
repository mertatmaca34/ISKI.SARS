using AutoMapper;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValues;

public class GetInstantValuesQueryHandler : IRequestHandler<GetInstantValuesQuery, PaginatedList<GetInstantValueDto>>
{
    private readonly IInstantValueRepository _instantValueRepository;
    private readonly IMapper _mapper;

    public GetInstantValuesQueryHandler(IInstantValueRepository instantValueRepository, IMapper mapper)
    {
        _instantValueRepository = instantValueRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<GetInstantValueDto>> Handle(GetInstantValuesQuery request, CancellationToken cancellationToken)
    {
        var values = await _instantValueRepository.GetAllAsync(
            request.PageRequest.PageNumber,
            request.PageRequest.PageSize,
            request.DynamicQuery ?? new DynamicQuery()
        );

        var mapped = _mapper.Map<List<GetInstantValueDto>>(values.Items);

        return new PaginatedList<GetInstantValueDto>
        {
            Items = mapped,
            Index = values.Index,
            Size = values.Size,
            Count = values.Count,
            Pages = values.Pages
        };
    }
}
