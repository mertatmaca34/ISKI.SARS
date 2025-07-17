using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Domain.Enums;
using MediatR;

namespace ISKI.SARS.Application.Features.SystemSettings.Commands.WriteSystemSetting;

public class WriteSystemSettingCommand : IRequest<SystemSettingDto>
{
    public string OpcServerUrl { get; set; } = string.Empty;
    public int SessionTimeout { get; set; }
    public LogLevel LogLevel { get; set; }
}
