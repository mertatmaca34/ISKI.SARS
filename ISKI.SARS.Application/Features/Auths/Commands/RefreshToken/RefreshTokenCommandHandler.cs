using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Commands.RefreshToken;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.RefreshToken;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, AccessToken>
{
    private readonly IUserRepository _userRepository;
    private readonly IOperationClaimRepository _claimRepository;
    private readonly JwtHelper _jwtHelper;

    public RefreshTokenCommandHandler(
        IUserRepository userRepository,
        IOperationClaimRepository claimRepository,
        JwtHelper jwtHelper)
    {
        _userRepository = userRepository;
        _claimRepository = claimRepository;
        _jwtHelper = jwtHelper;
    }

    public async Task<AccessToken> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Örnek: RefreshToken DB'de şifrelenmiş halde saklandıysa burada çözülüp kontrol edilmelidir.
        // Bu örnekte dummy data ile kullanıcıyı çekiyoruz.

        var user = await _userRepository.GetAsync(x => true); // Gerçek implementasyonda token'dan userId çözülmeli

        if (user == null)
            throw new BusinessException("Kullanıcı bulunamadı");

        var claims = await _claimRepository.GetAllAsync(1, 100);
        var token = _jwtHelper.CreateAccessToken(user, claims.Items);
        return token;
    }
}
