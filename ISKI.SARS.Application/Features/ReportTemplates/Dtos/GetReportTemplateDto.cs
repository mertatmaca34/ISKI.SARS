using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Application.Features.ReportTemplates.Dtos;

public class GetReportTemplateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsShared { get; set; }
}