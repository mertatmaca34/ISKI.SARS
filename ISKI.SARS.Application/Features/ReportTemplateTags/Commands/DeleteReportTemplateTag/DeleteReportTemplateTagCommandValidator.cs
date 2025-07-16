using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.DeleteReportTemplateTag;

public class DeleteReportTemplateTagCommandValidator : AbstractValidator<DeleteReportTemplateTagCommand>
{
    public DeleteReportTemplateTagCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ReportTemplateTagMessages.InvalidReportTemplateId);
    }
}
