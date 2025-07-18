using ISKI.Core.Security.Dtos;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.JWT;

namespace ISKI.SARS.Application.Services.AuthService;

public interface IAuthService
{
    Task<AccessToken> RegisterAsync(RegisterDto dto, string ipAddress);
    Task<AccessToken> LoginAsync(LoginDto dto, string ipAddress);
    Task<AccessToken> RefreshTokenAsync(string refreshToken, string ipAddress);
}
