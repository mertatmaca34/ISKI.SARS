using ISKI.SARS.Application.Features.Dashboard.Dtos;
using ISKI.SARS.Application.Features.Dashboard.Queries.GetDashboardStats;
using ISKI.SARS.Application.Features.SystemMetrics.Dtos;
using ISKI.SARS.Application.Features.SystemMetrics.Queries.GetSystemMetrics;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DashboardController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin,Operator")]
    [HttpGet]
    public async Task<ActionResult<DashboardStatsDto>> GetStats()
    {
        var query = new GetDashboardStatsQuery();
        DashboardStatsDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("metrics")]
    public async Task<ActionResult<List<SystemMetricDto>>> GetMetrics()
    {
        var query = new GetSystemMetricsQuery();
        List<SystemMetricDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
