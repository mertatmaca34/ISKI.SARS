using AutoMapper;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using ISKI.Core.Persistence.Paging;
using MediatR;
using ISKI.Core.Security.Repositories;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetList;

public class GetUserOperationClaimListQueryHandler(IUserOperationClaimRepository repository, IMapper mapper) : IRequestHandler<GetUserOperationClaimListQuery, PaginatedList<UserOperationClaimDto>>
{
    public async Task<PaginatedList<UserOperationClaimDto>> Handle(GetUserOperationClaimListQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(request.PageNumber, request.PageSize);
        return mapper.Map<PaginatedList<UserOperationClaimDto>>(result);
    }
}
