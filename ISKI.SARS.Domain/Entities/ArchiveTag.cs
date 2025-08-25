using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class ArchiveTag : BaseEntity<int>
{
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public int PullInterval { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
}
