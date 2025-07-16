using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.DeleteReportTemplate;

public class DeleteReportTemplateCommandValidator : AbstractValidator<DeleteReportTemplateCommand>
{
    public DeleteReportTemplateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ReportTemplateMessages.InvalidReportTemplateId);
    }
}
