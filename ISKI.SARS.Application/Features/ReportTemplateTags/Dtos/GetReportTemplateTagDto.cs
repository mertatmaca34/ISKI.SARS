namespace ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;

public class GetReportTemplateTagDto
{
    public int Id { get; set; }
    public int ReportTemplateId { get; set; }
    public string TagName { get; set; }
    public string TagNodeId { get; set; }
    public string? Description { get; set; }
}