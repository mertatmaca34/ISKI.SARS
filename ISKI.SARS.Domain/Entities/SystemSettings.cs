using ISKI.SARS.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class SystemSettings : BaseEntity<Guid>
{
    public string OpcServerUrl { get; set; } = string.Empty;
    public int SessionTimeout { get; set; }
    public LogLevel LogLevel { get; set; }
}
