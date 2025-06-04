using ISKI.Core.Domain;
using ISKI.SARS.Domain.Enums;

namespace ISKI.SARS.Domain.Entities;

public class ReportTemplate : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string OpcEndpoint { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
