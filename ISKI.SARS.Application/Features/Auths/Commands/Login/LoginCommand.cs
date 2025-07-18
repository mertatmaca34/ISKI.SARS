using ISKI.Core.Security.Dtos;
using ISKI.Core.Security.JWT;
using MediatR;

namespace ISKI.SARS.Application.Features.Auths.Commands.Login;

public class LoginCommand : IRequest<AccessToken>
{
    public LoginDto LoginDto { get; set; }
    public string IpAddress { get; set; } = string.Empty;
}
