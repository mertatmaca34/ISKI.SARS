using FluentValidation;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.OperationClaims.Constants;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommandValidator : AbstractValidator<DeleteOperationClaimCommand>
{
    public DeleteOperationClaimCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(OperationClaimMessages.OperationClaimIdCannotBeEmpty)
            .GreaterThan(0).WithMessage(OperationClaimMessages.OperationClaimIdMustBePositive);
    }
}