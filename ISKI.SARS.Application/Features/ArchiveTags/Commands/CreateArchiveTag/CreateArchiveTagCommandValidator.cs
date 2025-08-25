using FluentValidation;
using ISKI.SARS.Application.Features.ArchiveTags.Constants;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.CreateArchiveTag;

public class CreateArchiveTagCommandValidator : AbstractValidator<CreateArchiveTagCommand>
{
    public CreateArchiveTagCommandValidator()
    {
        RuleFor(x => x.TagName)
            .MinimumLength(3)
            .WithMessage(ArchiveTagMessages.TagNameTooShort);

        RuleFor(x => x.TagNodeId)
            .NotEmpty()
            .WithMessage(ArchiveTagMessages.TagNodeIdIsRequired);
    }
}
