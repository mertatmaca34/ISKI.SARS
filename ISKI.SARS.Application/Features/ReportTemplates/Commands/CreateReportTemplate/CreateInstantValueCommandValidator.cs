using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplates.Commands;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;
using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

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

        RuleFor(x => x.CreatedByUserId)
            .NotEmpty();

        RuleFor(x => x.Tags)
            .NotEmpty()
            .WithMessage(ReportTemplateMessages.TagListIsRequired);

        RuleForEach(x => x.Tags).ChildRules(tag =>
        {
            tag.RuleFor(t => t.TagName)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage(ReportTemplateTagMessages.TagNameTooShort);

            tag.RuleFor(t => t.TagNodeId)
                .NotEmpty()
                .WithMessage(ReportTemplateTagMessages.TagNodeIdIsRequired);
        });
    }
}
