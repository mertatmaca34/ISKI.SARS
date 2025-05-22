using FluentValidation;
using ISKI.SARS.Application.Features.Users.Constants;

namespace ISKI.SARS.Application.Features.Users.Commands.ChangePassword;

public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(UserMessages.InvalidUserId);

        RuleFor(x => x.OldPassword)
            .NotEmpty().WithMessage(UserMessages.OldPasswordCannotBeEmpty)
            .MinimumLength(6).WithMessage(UserMessages.OldPasswordMinLength);

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage(UserMessages.NewPasswordCannotBeEmpty)
            .MinimumLength(6).WithMessage(UserMessages.NewPasswordMinLength)
            .NotEqual(x => x.OldPassword).WithMessage(UserMessages.NewPasswordCannotBeSame);
    }
}