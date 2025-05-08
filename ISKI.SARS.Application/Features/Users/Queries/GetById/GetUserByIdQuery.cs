using ISKI.SARS.Application.Features.Users.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Queries.GetById;

public class GetUserByIdQuery : IRequest<UserDto>
{
    public Guid Id { get; set; }
}