using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;

public class ChangeReportTemplateStatusCommandValidator : AbstractValidator<ChangeReportTemplateStatusCommand>
{
    public ChangeReportTemplateStatusCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage(ReportTemplateMessages.InvalidReportTemplateId);
    }
}
