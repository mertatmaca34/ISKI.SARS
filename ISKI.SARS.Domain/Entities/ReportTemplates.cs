using ISKI.SARS.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplates : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}