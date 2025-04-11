using ISKI.SARS.Domain.Common;

namespace ISKI.SARS.Domain.Entities;

public class Tags : BaseEntity<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
