using FluentValidation;
using ISKI.SARS.Application.Features.Users.Constants;

namespace ISKI.SARS.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(UserMessages.InvalidUserId);
    }
}
