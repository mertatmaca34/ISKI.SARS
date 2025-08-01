using Microsoft.Extensions.DependencyInjection;
using ISKI.SARS.Application.Features.InstantValues.Profiles;
using ISKI.SARS.Application.Features.InstantValues.Rules;
using ISKI.SARS.Application.Features.Auths.Rules;
using ISKI.SARS.Application.Features.OperationClaims.Rules;
using ISKI.SARS.Application.Features.UserOperationClaims.Rules;
using ISKI.SARS.Application.Features.Users.Rules;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Application.Features.ReportTemplateTags.Rules;
using ISKI.SARS.Application.Features.ArchiveTags.Rules;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Rules;

namespace ISKI.SARS.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(InstantValueMappingProfile).Assembly);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

        services.AddScoped<AuthBusinessRules>();
        services.AddScoped<OperationClaimBusinessRules>();
        services.AddScoped<UserOperationClaimBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<InstantValueBusinessRules>();
        services.AddScoped<ReportTemplateBusinessRules>();
        services.AddScoped<ReportTemplateTagBusinessRules>();
        services.AddScoped<ArchiveTagBusinessRules>();
        services.AddScoped<ReportTemplateArchiveTagBusinessRules>();

        return services;
    }
}
