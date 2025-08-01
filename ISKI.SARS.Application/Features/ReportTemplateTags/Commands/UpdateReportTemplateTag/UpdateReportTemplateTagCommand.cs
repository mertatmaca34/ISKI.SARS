using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Commands.UpdateReportTemplateTag;

public class UpdateReportTemplateTagCommand : IRequest<GetReportTemplateTagDto>
{
    public int Id { get; set; }
    public int ReportTemplateId { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TagTypes Type { get; set; }
}
