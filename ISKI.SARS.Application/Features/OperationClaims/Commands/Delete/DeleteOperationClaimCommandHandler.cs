using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Constants;
using ISKI.SARS.Application.Features.OperationClaims.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimResponse>
{
    private readonly IOperationClaimRepository _repository;
    private readonly IMapper _mapper;
    private readonly OperationClaimBusinessRules _rules;

    public DeleteOperationClaimCommandHandler(IOperationClaimRepository repository, IMapper mapper, OperationClaimBusinessRules rules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<DeletedOperationClaimResponse> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new BusinessException(OperationClaimMessages.OperationClaimNotFound);

        var deleted = await _repository.DeleteAsync(entity);
        return _mapper.Map<DeletedOperationClaimResponse>(deleted);
    }
}