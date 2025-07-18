using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using ISKI.SARS.Application.Features.SystemSettings.Constants;

namespace ISKI.SARS.Application.Features.SystemSettings.Commands.WriteSystemSetting;

public class WriteSystemSettingCommandHandler(
    ISystemSettingRepository repository,
    IConfiguration configuration)
    : IRequestHandler<WriteSystemSettingCommand, SystemSettingDto>
{
    public async Task<SystemSettingDto> Handle(WriteSystemSettingCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetAsync(x => true);

        if (entity is null)
        {
            entity = new SystemSetting
            {
                OpcServerUrl = request.OpcServerUrl,
                SessionTimeout = request.SessionTimeout,
                LogLevel = request.LogLevel,
                CreatedAt = DateTime.Now
            };
            await repository.AddAsync(entity);
        }
        else
        {
            entity.OpcServerUrl = request.OpcServerUrl;
            entity.SessionTimeout = request.SessionTimeout;
            entity.LogLevel = request.LogLevel;
            entity.UpdatedAt = DateTime.Now;

            await repository.UpdateAsync(entity);
        }

        return new SystemSettingDto
        {
            OpcServerUrl = entity.OpcServerUrl,
            DatabaseConnection = configuration.GetConnectionString(SystemSettingConstants.DefaultConnection) ?? string.Empty,
            RetentionDays = 90,
            EmailNotifications = true,
            SmsNotifications = false,
            AlertThreshold = 85,
            SessionTimeout = entity.SessionTimeout,
            LogLevel = entity.LogLevel,
            BackupEnabled = true,
            BackupIntervalHours = 24
        };
    }
}
