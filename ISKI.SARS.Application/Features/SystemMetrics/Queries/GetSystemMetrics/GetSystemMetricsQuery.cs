using ISKI.SARS.Application.Features.SystemMetrics.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.SystemMetrics.Queries.GetSystemMetrics;

public class GetSystemMetricsQuery : IRequest<List<SystemMetricDto>>
{
}
