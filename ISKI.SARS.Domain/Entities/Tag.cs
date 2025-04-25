using ISKI.SARS.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class Tag : BaseEntity<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
