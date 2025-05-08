using FluentValidation;
using ISKI.SARS.Application.Features.Users.Constants;

namespace ISKI.SARS.Application.Features.Users.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserMessages.InvalidEmail)
            .EmailAddress().WithMessage(UserMessages.InvalidEmail);

        RuleFor(x => x.Password)
            .MinimumLength(6).WithMessage(UserMessages.PasswordTooShort);
    }
}