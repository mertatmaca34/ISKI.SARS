using FluentValidation;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommandValidator : AbstractValidator<CreateUserOperationClaimCommand>
{
    public CreateUserOperationClaimCommandValidator()
    {
        RuleFor(x => x.OperationClaimId)
            .GreaterThan(0).WithMessage(UserOperationClaimMessages.OperationClaimIdInvalid);
    }
}
