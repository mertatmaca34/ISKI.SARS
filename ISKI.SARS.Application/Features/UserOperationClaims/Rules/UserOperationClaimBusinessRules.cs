using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Rules;

public class UserOperationClaimBusinessRules
{
    private readonly IUserOperationClaimRepository _repository;

    public UserOperationClaimBusinessRules(IUserOperationClaimRepository repository)
    {
        _repository = repository;
    }

    public async Task UserOperationClaimCannotBeDuplicated(Guid userId, int claimId)
    {
        var exists = await _repository.GetAsync(x => x.UserId == userId && x.OperationClaimId == claimId);
        if (exists != null)
            throw new BusinessException(UserOperationClaimMessages.DuplicateClaimNotAllowed);
    }
}