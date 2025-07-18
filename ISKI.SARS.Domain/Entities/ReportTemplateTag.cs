using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplateTag : BaseEntity<int>
{
    public int ReportTemplateId { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public TagTypes Type { get; set; }
    public ReportTemplate? ReportTemplate { get; set; }
}
