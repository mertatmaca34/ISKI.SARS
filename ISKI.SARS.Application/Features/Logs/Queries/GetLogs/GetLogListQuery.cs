using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.Logs.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Queries.GetLogs;

public class GetLogListQuery : IRequest<PaginatedList<LogDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
