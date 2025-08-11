using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;

public class CreateReportTemplateTagDto
{
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TagTypes Type { get; set; }
}

