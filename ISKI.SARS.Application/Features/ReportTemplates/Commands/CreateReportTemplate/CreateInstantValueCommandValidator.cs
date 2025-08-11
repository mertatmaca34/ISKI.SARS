using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Commands;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

public class CreateReportTemplateCommandValidator : AbstractValidator<CreateReportTemplateCommand>
{
    public CreateReportTemplateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ReportTemplateMessages.NameIsRequired);
        RuleFor(x => x.CreatedByUserId)
            .NotEmpty();
    }
}
