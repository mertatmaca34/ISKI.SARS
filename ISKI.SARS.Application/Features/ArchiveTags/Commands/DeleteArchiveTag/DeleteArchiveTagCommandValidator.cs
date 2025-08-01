using FluentValidation;
using ISKI.SARS.Application.Features.ArchiveTags.Constants;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.DeleteArchiveTag;

public class DeleteArchiveTagCommandValidator : AbstractValidator<DeleteArchiveTagCommand>
{
    public DeleteArchiveTagCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ArchiveTagMessages.InvalidId);
    }
}
