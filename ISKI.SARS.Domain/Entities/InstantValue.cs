using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class InstantValue : BaseEntity<DateTime>
{
    public int ArchiveTagId { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool Status { get; set; }
    public ArchiveTag? ArchiveTag { get; set; }
}
