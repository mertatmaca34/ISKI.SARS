using AutoMapper;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.Core.Persistence.Paging;
using ISKI.Core.Security.Repositories;
using MediatR;
using System.Linq;

namespace ISKI.SARS.Application.Features.Users.Queries.GetList;

public class GetUserListQueryHandler(
    IUserRepository repository,
    IUserOperationClaimRepository userOperationClaimRepository,
    IMapper mapper) : IRequestHandler<GetUserListQuery, PaginatedList<UserDto>>
{
    public async Task<PaginatedList<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var users = await repository.GetAllAsync(request.PageNumber, request.PageSize);
        var dtos = mapper.Map<PaginatedList<UserDto>>(users);

        for (int i = 0; i < dtos.Items.Count; i++)
        {
            var userEntity = users.Items[i];
            var dto = dtos.Items[i];
            var claims = await userOperationClaimRepository.GetClaims(userEntity);
            var firstClaim = claims.FirstOrDefault();
            if (firstClaim != null)
            {
                dto.OperationClaimId = firstClaim.Id;
                dto.OperationClaimName = firstClaim.Name;
            }
        }

        return dtos;
    }
}
