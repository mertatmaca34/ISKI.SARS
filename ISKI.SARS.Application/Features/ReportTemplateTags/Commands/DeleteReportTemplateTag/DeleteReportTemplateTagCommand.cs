using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.DeleteReportTemplateTag;

public class DeleteReportTemplateTagCommand : IRequest<GetReportTemplateTagDto>
{
    public int Id { get; set; }
}
