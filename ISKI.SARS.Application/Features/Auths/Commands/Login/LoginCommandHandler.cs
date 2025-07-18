using AutoMapper;
using ISKI.Core.Security.Constants;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Constants;
using ISKI.SARS.Application.Features.Auths.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.Login;

public class LoginCommandHandler(
    IUserRepository userRepository,
    IOperationClaimRepository claimRepository,
    IUserOperationClaimRepository userClaimRepository,
    JwtHelper jwtHelper,
    AuthBusinessRules rules) : IRequestHandler<LoginCommand, AccessToken>
{
    public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetAsync(x => x.Email == request.LoginDto.Email);
        await rules.UserMustExist(request.LoginDto.Email);
        rules.PasswordMustMatch(request.LoginDto.Password, user!.PasswordHash, user.PasswordSalt);

        var userClaims = await userClaimRepository.GetAllAsync(x => x.UserId == user.Id);
        rules.UserMustHaveAtLeastOneRole(userClaims);

        var operationClaims = new List<OperationClaim>();

        foreach (var userClaim in userClaims)
        {
            var claim = await claimRepository.GetAsync(x => x.Id == userClaim.OperationClaimId);

            if (claim != null)
                operationClaims.Add(claim);
        }

        rules.CannotLoginWithPendingRole(operationClaims);

        var token = jwtHelper.CreateAccessToken(user, operationClaims);
        return token;
    }
}
