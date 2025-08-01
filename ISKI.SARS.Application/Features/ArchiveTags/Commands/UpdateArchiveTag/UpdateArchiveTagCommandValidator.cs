using FluentValidation;
using ISKI.SARS.Application.Features.ArchiveTags.Constants;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.UpdateArchiveTag;

public class UpdateArchiveTagCommandValidator : AbstractValidator<UpdateArchiveTagCommand>
{
    public UpdateArchiveTagCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ArchiveTagMessages.InvalidId);
        RuleFor(x => x.TagName).MinimumLength(3).WithMessage(ArchiveTagMessages.TagNameTooShort);
        RuleFor(x => x.TagNodeId).NotEmpty().WithMessage(ArchiveTagMessages.TagNodeIdIsRequired);
    }
}
