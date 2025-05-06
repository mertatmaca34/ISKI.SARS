using FluentValidation;

namespace ISKI.SARS.Application.Features.Tags.Commands.CreateTag;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(x => x.DisplayName).NotEmpty().MinimumLength(3);
        RuleFor(x => x.OpcPath).NotEmpty();
        RuleFor(x => x.PullInterval).GreaterThan(60000);
    }
}
