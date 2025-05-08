using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Domain.Services;
using ISKI.SARS.Infrastructure.Persistence.Repositories;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.SARS.Infrastructure.Persistence.Seeders;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        if (CanConnect(connectionString))
        {
            services.AddDbContext<SarsDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
        else
        {
            services.AddDbContext<SarsDbContext>(options =>
                options.UseInMemoryDatabase("FakeDB"));
        }

        services.AddScoped<JwtHelper>();

        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var opClaimRepo = scope.ServiceProvider.GetRequiredService<IOperationClaimRepository>();
            OperationClaimSeeder.SeedAsync(opClaimRepo).Wait();

            var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var userOpClaimRepo = scope.ServiceProvider.GetRequiredService<IUserOperationClaimRepository>();
            UserSeeder.SeedAsync(userRepo, opClaimRepo, userOpClaimRepo).Wait();
        }

        return services;
    }

    private static bool CanConnect(string connectionString)
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection.State == ConnectionState.Open;
        }
        catch
        {
            return false;
        }
    }
}
