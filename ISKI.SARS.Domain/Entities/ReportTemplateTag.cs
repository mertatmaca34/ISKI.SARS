using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplateTag : BaseEntity<int>
{
    public int ReportTemplateId { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public ReportTemplate? ReportTemplate { get; set; }

}
