using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
{
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _claimRepository;
    private readonly IUserOperationClaimRepository _userClaimRepository;
    private readonly JwtHelper _jwtHelper;
    private readonly AuthBusinessRules _rules;

    public LoginCommandHandler(
        IUserRepository userRepository,
        IOperationClaimRepository claimRepository,
        IUserOperationClaimRepository userClaimRepository,
        JwtHelper jwtHelper,
        AuthBusinessRules rules)
    {
        _userRepository = userRepository;
        _claimRepository = claimRepository;
        _userClaimRepository = userClaimRepository;
        _jwtHelper = jwtHelper;
        _rules = rules;
    }

    public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetAsync(x => x.Email == request.LoginDto.Email);
        await _rules.UserMustExist(request.LoginDto.Email);
        _rules.PasswordMustMatch(request.LoginDto.Password, user!.PasswordHash, user.PasswordSalt);

        var userClaims = await _claimRepository.GetAllAsync(1, 100);
        var token = _jwtHelper.CreateAccessToken(user, userClaims.Items);

        return token;
    }
}
