namespace ISKI.SARS.Application.Features.SystemMetrics.Dtos;

public class SystemMetricDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Value { get; set; }
    public string Unit { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime LastUpdated { get; set; }
}
