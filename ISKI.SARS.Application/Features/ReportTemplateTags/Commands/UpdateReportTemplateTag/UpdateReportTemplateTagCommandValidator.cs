using FluentValidation;
using ISKI.SARS.Application.Features.ReportTemplateTags.Constants;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.UpdateReportTemplateTag;

public class UpdateReportTemplateTagCommandValidator : AbstractValidator<UpdateReportTemplateTagCommand>
{
    public UpdateReportTemplateTagCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage(ReportTemplateTagMessages.InvalidReportTemplateId);

        RuleFor(x => x.TagName)
            .MinimumLength(3).WithMessage(ReportTemplateTagMessages.TagNameTooShort);

        RuleFor(x => x.TagNodeId)
            .NotEmpty().WithMessage(ReportTemplateTagMessages.TagNodeIdIsRequired);
    }
}
