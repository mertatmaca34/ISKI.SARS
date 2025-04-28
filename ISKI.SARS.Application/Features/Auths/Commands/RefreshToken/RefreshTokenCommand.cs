using ISKI.Core.Security.JWT;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<AccessToken>
{
    public string RefreshToken { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
}
