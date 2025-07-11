using AutoMapper;
using ISKI.SARS.Application.Features.SystemMetrics.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.SystemMetrics.Queries.GetSystemMetrics;

public class GetSystemMetricsQueryHandler(
    ISystemMetricRepository repository,
    IMapper mapper)
    : IRequestHandler<GetSystemMetricsQuery, List<SystemMetricDto>>
{
    public async Task<List<SystemMetricDto>> Handle(GetSystemMetricsQuery request, CancellationToken cancellationToken)
    {
        var list = await repository.GetAllAsync(x => true);
        return mapper.Map<List<SystemMetricDto>>(list);
    }
}
