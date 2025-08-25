using ISKI.SARS.Application.Features.SystemMetrics.Dtos;
using ISKI.SARS.Application.Features.SystemMetrics.Constants;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.OpcUa.Client.Interfaces;
using MediatR;
using System.Diagnostics;

namespace ISKI.SARS.Application.Features.SystemMetrics.Queries.GetSystemMetrics;

public class GetSystemMetricsQueryHandler(
    IConnectionService connectionService,
    SarsDbContext dbContext)
    : IRequestHandler<GetSystemMetricsQuery, List<SystemMetricDto>>
{
    public async Task<List<SystemMetricDto>> Handle(GetSystemMetricsQuery request, CancellationToken cancellationToken)
    {
        var watch = Stopwatch.StartNew();

        bool opcConnected = connectionService.Session is not null && connectionService.Session.Connected;

        bool dbConnected;
        try
        {
            dbConnected = await dbContext.Database.CanConnectAsync(cancellationToken);
        }
        catch
        {
            dbConnected = false;
        }

        watch.Stop();

        DateTime now = DateTime.Now;

        var metrics = new List<SystemMetricDto>
        {
            new()
            {
                Name = SystemMetricConstants.OpcUaConnection,
                Value = opcConnected ? 1 : 0,
                Unit = string.Empty,
                Status = opcConnected ? SystemMetricConstants.StatusConnected : SystemMetricConstants.StatusDisconnected,
                LastUpdated = now
            },
            new()
            {
                Name = SystemMetricConstants.DatabaseConnection,
                Value = dbConnected ? 1 : 0,
                Unit = string.Empty,
                Status = dbConnected ? SystemMetricConstants.StatusConnected : SystemMetricConstants.StatusDisconnected,
                LastUpdated = now
            },
            new()
            {
                Name = SystemMetricConstants.ApiResponseTime,
                Value = watch.Elapsed.TotalMilliseconds,
                Unit = SystemMetricConstants.UnitMilliseconds,
                Status = SystemMetricConstants.StatusOk,
                LastUpdated = now
            }
        };

        return metrics;
    }
}
