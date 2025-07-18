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

namespace ISKI.SARS.Application.Features.Auths.Commands.Register;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IOperationClaimRepository claimRepository,
    IUserOperationClaimRepository userClaimRepository,
    IMapper mapper,
    JwtHelper jwtHelper,
    AuthBusinessRules rules) : IRequestHandler<RegisterCommand, AccessToken>
{
    public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await rules.EmailMustBeUnique(request.RegisterDto.Email);

        HashingHelper.CreatePasswordHash(request.RegisterDto.Password, out var hash, out var salt);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.RegisterDto.FirstName,
            LastName = request.RegisterDto.LastName,
            Email = request.RegisterDto.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
            Status = true
        };

        await userRepository.AddAsync(user);

        var pendingRole = await claimRepository.GetAsync(x => x.Name == GeneralOperationClaims.PendingUser);
        rules.DefaultPendingRoleMustExist(pendingRole);

        await userClaimRepository.AddAsync(new UserOperationClaim
        {
            UserId = user.Id,
            OperationClaimId = pendingRole.Id
        });

        var token = jwtHelper.CreateAccessToken(user, new List<OperationClaim> { pendingRole });
        return token;
    }
}
