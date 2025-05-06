using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplateTags : BaseEntity<Guid>
{
    public Guid ReportTemplateId { get; set; } 
    public Guid TagId { get; set; }
    public string DisplayName { get; set; } = string.Empty;
}