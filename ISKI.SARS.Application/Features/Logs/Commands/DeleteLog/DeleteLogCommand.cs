using ISKI.SARS.Application.Features.Logs.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Commands.DeleteLog;

public class DeleteLogCommand : IRequest<LogDto>
{
    public int Id { get; set; }
}
