using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ISKI.SARS.Domain.Services;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.SARS.Infrastructure.Persistence.Repositories;
using ISKI.Core.Security.Repositories;
using ISKI.Core.Security.JWT;
using Microsoft.Extensions.Configuration;

namespace ISKI.SARS.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SarsDbContext>(options =>
            options.UseInMemoryDatabase(connectionString));

        services.AddScoped<JwtHelper>();

        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        return services;
    }
}
