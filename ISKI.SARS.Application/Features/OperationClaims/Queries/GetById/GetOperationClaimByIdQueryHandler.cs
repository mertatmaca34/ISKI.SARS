using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Constants;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.Application.Features.OperationClaims.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Queries.GetById;

public class GetOperationClaimByIdQueryHandler : IRequestHandler<GetOperationClaimByIdQuery, OperationClaimDto>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _businessRules;

    public GetOperationClaimByIdQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules businessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<OperationClaimDto> Handle(GetOperationClaimByIdQuery request, CancellationToken cancellationToken)
    {
        OperationClaim? entity = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
        return entity == null
            ? throw new BusinessException(OperationClaimMessages.OperationClaimNotFound)
            : _mapper.Map<OperationClaimDto>(entity);
    }
}