using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Commands;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Validators;

public class CreateReportTemplateCommandValidator : AbstractValidator<CreateReportTemplateCommand>
{
    public CreateReportTemplateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ReportTemplateMessages.NameIsRequired);

        RuleFor(x => x.OpcEndpoint)
            .NotEmpty()
            .WithMessage(ReportTemplateMessages.OpcEndpointIsRequired);

        RuleFor(x => x.PullInterval)
            .GreaterThanOrEqualTo(1000)
            .WithMessage(ReportTemplateMessages.PullIntervalTooLow);
    }
}
