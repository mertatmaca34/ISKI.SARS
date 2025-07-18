using FluentValidation;
using ISKI.SARS.Application.Features.OperationClaims.Constants;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
{
    public UpdateOperationClaimCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(OperationClaimMessages.OperationClaimNameCannotBeEmpty)
            .MinimumLength(3).WithMessage(string.Format(OperationClaimMessages.OperationClaimNameTooShort, 3));
    }
}
