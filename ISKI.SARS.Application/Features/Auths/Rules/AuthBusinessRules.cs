using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Constants;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Constants;

namespace ISKI.SARS.Application.Features.Auths.Rules;

public class AuthBusinessRules(IUserRepository userRepository)
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task EmailMustBeUnique(string email)
    {
        var existingUser = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
        if (existingUser != null)
            throw new BusinessException(AuthMessages.EmailAlreadyExists);
    }

    public async Task UserMustExist(string email)
    {
        var user = await _userRepository.GetAsync(u => u.Email.ToLower() == email.ToLower());
        if (user == null)
            throw new BusinessException(AuthMessages.UserNotFound);
    }

    public void PasswordMustMatch(string plainPassword, byte[] storedHash, byte[] storedSalt)
    {
        bool isMatch = HashingHelper.VerifyPasswordHash(plainPassword, storedHash, storedSalt);
        if (!isMatch)
            throw new BusinessException(AuthMessages.InvalidPassword);
    }

    public void UserMustHaveAtLeastOneRole(IEnumerable<UserOperationClaim>? userClaims)
    {
        if (userClaims == null || !userClaims.Any())
            throw new BusinessException(AuthMessages.UserHasNoRole);
    }

    public void CannotLoginWithPendingRole(IEnumerable<OperationClaim> claims)
    {
        if (claims.Any(c => c.Name == GeneralOperationClaims.PendingUser))
            throw new BusinessException(AuthMessages.PendingUserLoginBlocked);
    }

    public void DefaultPendingRoleMustExist(OperationClaim? pendingRole)
    {
        if (pendingRole == null)
            throw new BusinessException(AuthMessages.DefaultPendingRoleNotFound);
    }
}
