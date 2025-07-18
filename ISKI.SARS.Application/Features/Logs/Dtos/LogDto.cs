using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Application.Features.Logs.Dtos;

public class LogDto
{
    public int Id { get; set; }
    public LogLevel Level { get; set; }
    public string Message { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
