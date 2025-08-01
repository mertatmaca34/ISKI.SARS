using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class ArchiveTag : BaseEntity<int>
{
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TagTypes Type { get; set; }
    public bool IsActive { get; set; } = true;
}
