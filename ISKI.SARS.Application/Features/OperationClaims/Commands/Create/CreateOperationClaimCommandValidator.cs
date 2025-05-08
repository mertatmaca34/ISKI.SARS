using FluentValidation;
using ISKI.SARS.Application.Features.OperationClaims.Constants;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Create;

public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
{
    public CreateOperationClaimCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(OperationClaimMessages.OperationClaimNameCannotBeEmpty)
            .MinimumLength(3).WithMessage(string.Format(OperationClaimMessages.OperationClaimNameTooShort, 3));
    }
}
