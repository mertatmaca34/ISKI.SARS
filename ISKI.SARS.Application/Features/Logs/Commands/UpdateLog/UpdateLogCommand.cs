using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Domain.Enums;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Commands.UpdateLog;

public class UpdateLogCommand : IRequest<LogDto>
{
    public int Id { get; set; }
    public LogLevel Level { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? Detail { get; set; }
}
