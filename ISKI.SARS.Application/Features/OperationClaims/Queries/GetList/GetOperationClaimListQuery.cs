using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Queries.GetList;

public class GetOperationClaimListQuery : IRequest<PaginatedList<OperationClaimDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
