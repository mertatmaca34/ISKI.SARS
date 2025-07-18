using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class LogEntry : BaseEntity<int>
{
    public LogLevel Level { get; set; }
    public string Message { get; set; } = string.Empty;
}
