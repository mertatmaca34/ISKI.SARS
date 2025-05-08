using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.Update;

public class UpdateUserCommand : IRequest<UpdatedUserResponse>
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
