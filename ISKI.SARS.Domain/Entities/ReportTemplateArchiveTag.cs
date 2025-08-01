using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplateArchiveTag : BaseEntity<int>
{
    public int ReportTemplateId { get; set; }
    public int ArchiveTagId { get; set; }
}
