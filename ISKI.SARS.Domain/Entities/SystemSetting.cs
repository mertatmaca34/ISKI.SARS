using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class SystemSetting : BaseEntity<int>
{
    public string OpcServerUrl { get; set; } = string.Empty;
    public int SessionTimeout { get; set; }
    public LogLevel LogLevel { get; set; }
}
