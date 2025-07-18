using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Create;

public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _businessRules;

    public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules businessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<CreatedOperationClaimResponse> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _businessRules.OperationClaimNameMustBeUnique(request.Name);

        OperationClaim operationClaim = _mapper.Map<OperationClaim>(request);
        OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(operationClaim);

        CreatedOperationClaimResponse response = _mapper.Map<CreatedOperationClaimResponse>(createdOperationClaim);
        return response;
    }
}