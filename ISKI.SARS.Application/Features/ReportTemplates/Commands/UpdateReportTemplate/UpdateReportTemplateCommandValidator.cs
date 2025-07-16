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

        RuleFor(x => x.OpcEndpoint)
            .NotEmpty()
            .WithMessage(ReportTemplateMessages.OpcEndpointIsRequired);

        RuleFor(x => x.PullInterval)
            .GreaterThanOrEqualTo(1000)
            .WithMessage(ReportTemplateMessages.PullIntervalTooLow);
    }
}
