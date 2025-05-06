using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Constants;

namespace ISKI.SARS.Application.Features.OperationClaims.Rules;

public class OperationClaimBusinessRules
{
    private readonly IOperationClaimRepository _operationClaimRepository;

    public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
    {
        _operationClaimRepository = operationClaimRepository;
    }

    public async Task OperationClaimNameMustBeUnique(string name)
    {
        var existingClaim = await _operationClaimRepository.GetAsync(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        if (existingClaim != null)
            throw new BusinessException(OperationClaimMessages.OperationClaimNameAlreadyExists);
    }
}
