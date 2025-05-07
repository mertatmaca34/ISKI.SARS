using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.UserOperationClaims.Rules;
using MediatR;
using ISKI.Core.Security.Repositories;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommandHandler : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimResponse>
{
    private readonly IUserOperationClaimRepository _repository;
    private readonly IMapper _mapper;
    private readonly UserOperationClaimBusinessRules _rules;

    public CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository repository, IMapper mapper, UserOperationClaimBusinessRules rules)
    {
        _repository = repository;
        _mapper = mapper;
        _rules = rules;
    }

    public async Task<CreatedUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        await _rules.UserOperationClaimCannotBeDuplicated(request.UserId, request.OperationClaimId);

        var entity = _mapper.Map<UserOperationClaim>(request);
        var created = await _repository.AddAsync(entity);

        return _mapper.Map<CreatedUserOperationClaimResponse>(created);
    }
}