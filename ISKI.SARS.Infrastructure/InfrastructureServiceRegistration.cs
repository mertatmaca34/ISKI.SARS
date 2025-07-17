using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISKI.SARS.Domain.Services;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.SARS.Infrastructure.Persistence.Repositories;

namespace ISKI.SARS.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SarsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<ISystemSettingsRepository, SystemSettingsRepository>();

        return services;
    }
}
