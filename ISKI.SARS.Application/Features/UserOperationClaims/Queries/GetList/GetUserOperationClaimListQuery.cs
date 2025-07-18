using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using MediatR;
using ISKI.Core.Persistence.Paging;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetList;

public class GetUserOperationClaimListQuery : IRequest<PaginatedList<UserOperationClaimDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}