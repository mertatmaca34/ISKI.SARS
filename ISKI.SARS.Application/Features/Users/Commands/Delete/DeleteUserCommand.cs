using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.Delete;

public class DeleteUserCommand : IRequest<DeletedUserResponse>
{
    public Guid Id { get; set; }
}
