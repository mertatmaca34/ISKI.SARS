using AutoMapper;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.Application.Features.InstantValues.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Commands.CreateInstantValue;

public class CreateInstantValueCommandHandler(
    IInstantValueRepository instantValueRepository,
    IMapper mapper,
    InstantValueBusinessRules businessRules)
    : IRequestHandler<CreateInstantValueCommand, GetInstantValueDto>
{
    private readonly IInstantValueRepository _instantValueRepository = instantValueRepository;
    private readonly IMapper _mapper = mapper;
    private readonly InstantValueBusinessRules _businessRules = businessRules;

    public async Task<GetInstantValueDto> Handle(CreateInstantValueCommand request, CancellationToken cancellationToken)
    {
        // Opsiyonel: aynı tag için aynı timestamp varsa ekleme
        await _businessRules.TimestampMustBeUnique(request.ReportTemplateTagId, request.Timestamp);

        var instantValue = _mapper.Map<InstantValue>(request);
        instantValue.Id = request.Timestamp;
        instantValue.CreatedAt = DateTime.UtcNow;

        var created = await _instantValueRepository.AddAsync(instantValue);
        return _mapper.Map<GetInstantValueDto>(created);
    }
}
