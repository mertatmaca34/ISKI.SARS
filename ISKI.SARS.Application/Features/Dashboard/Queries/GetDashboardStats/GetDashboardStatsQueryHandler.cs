using ISKI.SARS.Application.Features.Dashboard.Dtos;
using ISKI.SARS.Domain.Services;
using ISKI.Core.Security.Repositories;
using MediatR;

namespace ISKI.SARS.Application.Features.Dashboard.Queries.GetDashboardStats;

public class GetDashboardStatsQueryHandler(
    IReportTemplateRepository reportTemplateRepository,
    IReportTemplateTagRepository reportTemplateTagRepository,
    IInstantValueRepository instantValueRepository,
    IUserRepository userRepository)
    : IRequestHandler<GetDashboardStatsQuery, DashboardStatsDto>
{
    public async Task<DashboardStatsDto> Handle(GetDashboardStatsQuery request, CancellationToken cancellationToken)
    {
        var totalTemplates = (await reportTemplateRepository.GetAllAsync(x => true)).Count;
        var activeTags = (await reportTemplateTagRepository.GetAllAsync(x => true)).Count;
        var since = DateTime.Now.AddHours(-24);
        var dataPoints24h = (await instantValueRepository.GetAllAsync(x => x.Id >= since)).Count;
        var activeUsers = (await userRepository.GetAllAsync(x => x.Status)).Count;
        // System health and uptime placeholders
        string systemHealth = "OK";
        string uptime = "Online";
        int alerts24h = 0;

        return new DashboardStatsDto
        {
            TotalTemplates = totalTemplates,
            ActiveTags = activeTags,
            DataPoints24h = dataPoints24h,
            SystemHealth = systemHealth,
            ActiveUsers = activeUsers,
            Alerts24h = alerts24h,
            Uptime = uptime
        };
    }
}
