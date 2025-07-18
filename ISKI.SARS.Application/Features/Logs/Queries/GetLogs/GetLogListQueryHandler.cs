using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Queries.GetLogs;

public class GetLogListQueryHandler(ILogRepository repository, IMapper mapper)
    : IRequestHandler<GetLogListQuery, PaginatedList<LogDto>>
{
    public async Task<PaginatedList<LogDto>> Handle(GetLogListQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync(request.PageNumber, request.PageSize);
        var mapped = mapper.Map<List<LogDto>>(list.Items);
        return new PaginatedList<LogDto>
        {
            Items = mapped,
            Index = list.Index,
            Size = list.Size,
            Count = list.Count,
            Pages = list.Pages
        };
    }
}
