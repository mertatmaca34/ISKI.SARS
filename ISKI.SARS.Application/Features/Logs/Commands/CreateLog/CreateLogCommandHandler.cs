using AutoMapper;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Commands.CreateLog;

public class CreateLogCommandHandler(ILogRepository repository, IMapper mapper)
    : IRequestHandler<CreateLogCommand, LogDto>
{
    public async Task<LogDto> Handle(CreateLogCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<LogEntry>(request);
        entity.CreatedAt = DateTime.Now;
        var created = await repository.AddAsync(entity);
        return mapper.Map<LogDto>(created);
    }
}