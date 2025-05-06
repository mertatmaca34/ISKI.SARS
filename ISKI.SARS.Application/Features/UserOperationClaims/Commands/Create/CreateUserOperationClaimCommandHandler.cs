using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommandHandler(IUserOperationClaimRepository repository, IMapper mapper) : IRequestHandler<CreateUserOperationClaimCommand, CreatedUserOperationClaimResponse>
{

    public async Task<CreatedUserOperationClaimResponse> Handle(CreateUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<UserOperationClaim>(request);
        var created = await repository.AddAsync(entity);
        return mapper.Map<CreatedUserOperationClaimResponse>(created);
    }
}