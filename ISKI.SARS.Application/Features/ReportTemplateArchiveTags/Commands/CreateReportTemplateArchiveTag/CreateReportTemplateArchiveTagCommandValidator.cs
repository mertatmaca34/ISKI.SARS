using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.CreateReportTemplateArchiveTag;

public class CreateReportTemplateArchiveTagCommandValidator : AbstractValidator<CreateReportTemplateArchiveTagCommand>
{
    public CreateReportTemplateArchiveTagCommandValidator()
    {
        RuleFor(x => x.ReportTemplateId).GreaterThan(0).WithMessage(ReportTemplateArchiveTagMessages.InvalidId);
        RuleFor(x => x.ArchiveTagId).GreaterThan(0).WithMessage(ReportTemplateArchiveTagMessages.InvalidId);
    }
}
