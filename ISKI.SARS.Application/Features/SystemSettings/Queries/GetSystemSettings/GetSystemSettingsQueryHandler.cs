using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace ISKI.SARS.Application.Features.SystemSettings.Queries.GetSystemSettings;

public class GetSystemSettingsQueryHandler(
    ISystemSettingRepository repository,
    IConfiguration configuration)
    : IRequestHandler<GetSystemSettingsQuery, SystemSettingDto>
{
    public async Task<SystemSettingDto> Handle(GetSystemSettingsQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetAsync(x => true);

        return new SystemSettingDto
        {
            OpcServerUrl = entity?.OpcServerUrl ?? string.Empty,
            DatabaseConnection = configuration.GetConnectionString("DefaultConnection") ?? string.Empty,
            RetentionDays = 90,
            EmailNotifications = true,
            SmsNotifications = false,
            AlertThreshold = 85,
            SessionTimeout = entity?.SessionTimeout ?? 0,
            LogLevel = entity?.LogLevel ?? default,
            BackupEnabled = true,
            BackupIntervalHours = 24
        };
    }
}
