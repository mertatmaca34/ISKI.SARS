using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.DeleteReportTemplateArchiveTag;

public class DeleteReportTemplateArchiveTagCommandValidator : AbstractValidator<DeleteReportTemplateArchiveTagCommand>
{
    public DeleteReportTemplateArchiveTagCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage(ReportTemplateArchiveTagMessages.InvalidId);
    }
}
