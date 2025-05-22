using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplateTags.Commands;
using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.CreateReportTemplateTag;

public class CreateReportTemplateTagCommandValidator : AbstractValidator<CreateReportTemplateTagCommand>
{
    public CreateReportTemplateTagCommandValidator()
    {
        RuleFor(x => x.ReportTemplateId)
            .GreaterThan(0)
            .WithMessage(ReportTemplateTagMessages.InvalidReportTemplateId);

        RuleFor(x => x.TagName)
            .NotEmpty()
            .MinimumLength(3)
            .WithMessage(ReportTemplateTagMessages.TagNameTooShort);

        RuleFor(x => x.TagNodeId)
            .NotEmpty()
            .WithMessage(ReportTemplateTagMessages.TagNodeIdIsRequired);
    }
}