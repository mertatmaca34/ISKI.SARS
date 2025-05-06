using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AccessToken>
{
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _claimRepository;
    private readonly IUserOperationClaimRepository _userClaimRepository;
    private readonly IMapper _mapper;
    private readonly JwtHelper _jwtHelper;
    private readonly AuthBusinessRules _rules;

    public RegisterCommandHandler(
        IUserRepository userRepository,
        IOperationClaimRepository claimRepository,
        IUserOperationClaimRepository userClaimRepository,
        IMapper mapper,
        JwtHelper jwtHelper,
        AuthBusinessRules rules)
    {
        _userRepository = userRepository;
        _claimRepository = claimRepository;
        _userClaimRepository = userClaimRepository;
        _mapper = mapper;
        _jwtHelper = jwtHelper;
        _rules = rules;
    }

    public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        await _rules.EmailMustBeUnique(request.RegisterDto.Email);

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

        await _userRepository.AddAsync(user);

        var defaultClaims = await _claimRepository.GetAllAsync(1, 50);
        foreach (var claim in defaultClaims.Items)
        {
            await _userClaimRepository.AddAsync(new UserOperationClaim
            {
                UserId = user.Id, // burası artık int olacak
                OperationClaimId = claim.Id
            });
        }

        var token = _jwtHelper.CreateAccessToken(user, defaultClaims.Items);
        return token;
    }
}
