using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Commands.DeleteLog;

public class DeleteLogCommandHandler(ILogRepository repository, IMapper mapper)
    : IRequestHandler<DeleteLogCommand, LogDto>
{
    public async Task<LogDto> Handle(DeleteLogCommand request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            throw new BusinessException("Log not found");
        var deleted = await repository.DeleteAsync(entity);
        return mapper.Map<LogDto>(deleted);
    }
}
