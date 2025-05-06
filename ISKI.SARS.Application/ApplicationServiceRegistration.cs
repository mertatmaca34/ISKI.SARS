using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Profiles;
using ISKI.SARS.Application.Features.Tags.Rules;
using ISKI.SARS.Application.Features.Auths.Rules;
using ISKI.SARS.Application.Features.OperationClaims.Rules;

namespace ISKI.SARS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(TagProfile).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        services.AddScoped<TagBusinessRules>();
        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<OperationClaimBusinessRules>();

        return services;
    }
}
