using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Application.Features.SystemSettings.Dtos;

public class SystemSettingsDto
{
    public string OpcServerUrl { get; set; } = string.Empty;
    public string DatabaseConnection { get; set; } = string.Empty;
    public int RetentionDays { get; set; }
    public bool EmailNotifications { get; set; }
    public bool SmsNotifications { get; set; }
    public int AlertThreshold { get; set; }
    public int SessionTimeout { get; set; }
    public LogLevel LogLevel { get; set; }
    public bool BackupEnabled { get; set; }
    public int BackupIntervalHours { get; set; }
}
