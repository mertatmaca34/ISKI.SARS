using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;
using ISKI.SARS.Application.Features.UserOperationClaims.Rules;
using MediatR;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Update;

public class UpdateUserOperationClaimCommandHandler : IRequestHandler<UpdateUserOperationClaimCommand, UpdatedUserOperationClaimResponse>
{
    private readonly IUserOperationClaimRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _rules;

    public UpdateUserOperationClaimCommandHandler(IUserOperationClaimRepository repository, IMapper mapper, UserOperationClaimBusinessRules rules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<UpdatedUserOperationClaimResponse> Handle(UpdateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new BusinessException(UserOperationClaimMessages.NotFound);

        await _rules.UserOperationClaimCannotBeDuplicated(request.UserId, request.OperationClaimId);

        _mapper.Map(request, entity);
        var updated = await _repository.UpdateAsync(entity);

        return _mapper.Map<UpdatedUserOperationClaimResponse>(updated);
    }
}
