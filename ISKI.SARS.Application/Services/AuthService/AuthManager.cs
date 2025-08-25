using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Dtos;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Auths.Rules;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Application.Services.AuthService;

public class AuthManager(
    IUserRepository userRepository,
    IUserOperationClaimRepository userOperationClaimRepository,
    IOperationClaimRepository operationClaimRepository,
    IRefreshTokenRepository refreshTokenRepository,
    JwtHelper jwtHelper,
    AuthBusinessRules rules
) : IAuthService
{
    public async Task<AccessToken> RegisterAsync(RegisterDto dto, string ipAddress)
    {
        await rules.EmailMustBeUnique(dto.Email);
        HashingHelper.CreatePasswordHash(dto.Password, out var hash, out var salt);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
            Status = true
        };

        await userRepository.AddAsync(user);

        var defaultClaims = await operationClaimRepository.GetAllAsync(1, 50);
        foreach (var claim in defaultClaims.Items)
        {
            await userOperationClaimRepository.AddAsync(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = claim.Id
            });
        }

        var token = jwtHelper.CreateAccessToken(user, defaultClaims.Items);
        return token;
    }

    public async Task<AccessToken> LoginAsync(LoginDto dto, string ipAddress)
    {
        var user = await userRepository.GetAsync(u => u.Email == dto.Email);
        await rules.UserMustExist(dto.Email);
        rules.PasswordMustMatch(dto.Password, user!.PasswordHash, user.PasswordSalt);

        var userClaims = await userOperationClaimRepository
            .GetAllAsync(x => x.UserId == user.Id, include: q => q.Include(x => x.OperationClaim));
        var claims = userClaims.Select(x => x.OperationClaim).ToList();

        return jwtHelper.CreateAccessToken(user, claims);
    }

    public async Task<AccessToken> RefreshTokenAsync(string refreshToken, string ipAddress)
    {
        var storedToken = await refreshTokenRepository.GetAsync(x => x.Token == refreshToken);
        if (storedToken == null || storedToken.Expires < DateTime.Now)
            throw new BusinessException("Refresh token geçersiz.");

        var user = await userRepository.GetAsync(x => x.Id == storedToken.UserId);
        if (user == null)
            throw new BusinessException("Kullanıcı bulunamadı.");

        var userClaims = await userOperationClaimRepository
            .GetAllAsync(x => x.UserId == user.Id, include: q => q.Include(x => x.OperationClaim));
        var claims = userClaims.Select(x => x.OperationClaim).ToList();

        return jwtHelper.CreateAccessToken(user, claims);
    }
}
