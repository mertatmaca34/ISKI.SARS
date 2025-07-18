using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Application.Features.Logs.Constants;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Queries.GetLogById;

public class GetLogByIdQueryHandler(ILogRepository repository, IMapper mapper)
    : IRequestHandler<GetLogByIdQuery, LogDto>
{
    public async Task<LogDto> Handle(GetLogByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            throw new BusinessException(LogMessages.LogNotFound);
        return mapper.Map<LogDto>(entity);
    }
}
