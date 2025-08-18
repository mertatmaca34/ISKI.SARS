using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;

public class UpdateReportTemplateCommandValidator : AbstractValidator<UpdateReportTemplateCommand>
{
    public UpdateReportTemplateCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ReportTemplateMessages.InvalidReportTemplateId);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ReportTemplateMessages.NameIsRequired);
    }
}
