using AutoMapper;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.Core.Persistence.Paging;
using ISKI.Core.Security.Repositories;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Queries.GetList;

public class GetUserListQueryHandler(IUserRepository repository, IMapper mapper) : IRequestHandler<GetUserListQuery, PaginatedList<UserDto>>
{
    public async Task<PaginatedList<UserDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        var result = await repository.GetAllAsync(request.PageNumber, request.PageSize);
        return mapper.Map<PaginatedList<UserDto>>(result);
    }
}
