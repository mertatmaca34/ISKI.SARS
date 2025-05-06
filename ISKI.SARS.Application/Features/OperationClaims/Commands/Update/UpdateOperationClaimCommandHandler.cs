using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Constants;
using ISKI.SARS.Application.Features.OperationClaims.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _operationClaimRepository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _businessRules;

    public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules businessRules)
    {
        _operationClaimRepository = operationClaimRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public async Task<UpdatedOperationClaimResponse> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var entity = await _operationClaimRepository.GetAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);

        await _businessRules.OperationClaimNameMustBeUnique(request.Name);

        _mapper.Map(request, entity);
        var updated = await _operationClaimRepository.UpdateAsync(entity);

        return _mapper.Map<UpdatedOperationClaimResponse>(updated);
    }
}