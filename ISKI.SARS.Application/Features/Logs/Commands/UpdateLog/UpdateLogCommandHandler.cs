using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Application.Features.Logs.Constants;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Commands.UpdateLog;

public class UpdateLogCommandHandler(ILogRepository repository, IMapper mapper)
    : IRequestHandler<UpdateLogCommand, LogDto>
{
    public async Task<LogDto> Handle(UpdateLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            throw new BusinessException(LogMessages.LogNotFound);

        mapper.Map(request, entity);
        var updated = await repository.UpdateAsync(entity);
        return mapper.Map<LogDto>(updated);
    }
}
