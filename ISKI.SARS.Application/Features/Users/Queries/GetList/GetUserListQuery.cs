using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.Core.Persistence.Paging;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Queries.GetList;

public class GetUserListQuery : IRequest<PaginatedList<UserDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}