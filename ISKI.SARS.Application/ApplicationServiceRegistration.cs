using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Profiles;

namespace ISKI.SARS.Application;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        return services;
    }
}
