using ISKI.Core.Domain;

namespace ISKI.SARS.Domain.Entities;

public class SystemMetric : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
}
