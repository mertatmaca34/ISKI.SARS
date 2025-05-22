using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Constants;
using ISKI.SARS.Application.Features.Users.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandHandler(IUserRepository repository, UserBusinessRules rules) : IRequestHandler<ChangePasswordCommand, ChangedPasswordResponse>
{
    public async Task<ChangedPasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await rules.UserMustExist(request.UserId);

        var user = await repository.GetByIdAsync(request.UserId);
        if (!HashingHelper.VerifyPasswordHash(request.OldPassword, user!.PasswordHash, user.PasswordSalt))
            throw new BusinessException(UserMessages.OldPasswordWrong);

        HashingHelper.CreatePasswordHash(request.NewPassword, out var hash, out var salt);
        user.PasswordHash = hash;
        user.PasswordSalt = salt;

        await repository.UpdateAsync(user);

        return new ChangedPasswordResponse { Success = true };
    }
}