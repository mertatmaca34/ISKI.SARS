using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISKI.SARS.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommand : IRequest<ChangedPasswordResponse>
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}