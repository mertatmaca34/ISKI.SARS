using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.SARS.Application.Features.InstantValues.Constants;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.Application.Features.InstantValues.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValueById;

public class GetInstantValueByIdQueryHandler : IRequestHandler<GetInstantValueByIdQuery, GetInstantValueDto>
{
    private readonly IInstantValueRepository _instantValueRepository;
    private readonly IMapper _mapper;
    private readonly InstantValueBusinessRules _businessRules;

    public GetInstantValueByIdQueryHandler(
        IInstantValueRepository instantValueRepository,
        IMapper mapper,
        InstantValueBusinessRules businessRules)
    {
        _instantValueRepository = instantValueRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<GetInstantValueDto> Handle(GetInstantValueByIdQuery request, CancellationToken cancellationToken)
    {
        await _businessRules.MustExist(request.Timestamp);

        var entity = await _instantValueRepository.GetByIdAsync(request.Timestamp);
        return _mapper.Map<GetInstantValueDto>(entity);
    }
}