using ISKI.Core.Security.Dtos;
using ISKI.Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<AccessToken>
{
    public RegisterDto RegisterDto { get; set; }
    public string IpAddress { get; set; } = string.Empty;
}