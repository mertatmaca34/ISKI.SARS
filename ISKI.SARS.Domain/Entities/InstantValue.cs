using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class InstantValue : BaseEntity<DateTime>
{
    public int ReportTemplateTagId { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool Status { get; set; }
    public ReportTemplateTag? ReportTemplateTag { get; set; }
}
