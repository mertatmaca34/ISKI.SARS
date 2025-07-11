using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Application.Features.SystemMetrics.Dtos;

namespace ISKI.SARS.Application.Features.SystemMetrics.Profiles;

public class SystemMetricProfile : Profile
{
    public SystemMetricProfile()
    {
        CreateMap<SystemMetric, SystemMetricDto>();
        CreateMap<PaginatedList<SystemMetric>, PaginatedList<SystemMetricDto>>();
    }
}
