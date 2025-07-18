using FluentValidation;
using ISKI.SARS.Application.Features.InstantValues.Constants;

namespace ISKI.SARS.Application.Features.InstantValues.Commands.CreateInstantValue;

public class CreateInstantValueCommandValidator : AbstractValidator<CreateInstantValueCommand>
{
    public CreateInstantValueCommandValidator()
    {
        RuleFor(x => x.ReportTemplateTagId)
            .GreaterThan(0)
            .WithMessage(InstantValueMessages.InvalidTagId);

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage(InstantValueMessages.ValueCannotBeEmpty);

        RuleFor(x => x.Timestamp)
            .LessThanOrEqualTo(DateTime.Now.AddMinutes(1)) // çok ileri zaman olmasın
            .WithMessage("Zaman bilgisi geçerli bir tarih olmalıdır.");
    }
}
