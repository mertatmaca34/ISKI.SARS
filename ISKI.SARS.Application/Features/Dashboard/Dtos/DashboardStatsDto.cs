namespace ISKI.SARS.Application.Features.Dashboard.Dtos;

public class DashboardStatsDto
{
    public int TotalTemplates { get; set; }
    public int ActiveTags { get; set; }
    public int DataPoints24h { get; set; }
    public string SystemHealth { get; set; } = string.Empty;
    public int ActiveUsers { get; set; }
    public int Alerts24h { get; set; }
    public string Uptime { get; set; } = string.Empty;
}
