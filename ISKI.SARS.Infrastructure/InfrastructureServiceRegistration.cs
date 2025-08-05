using ISKI.Core.Security.JWT;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Domain.Services;
using ISKI.SARS.Infrastructure.Persistence.Repositories;
using ISKI.SARS.Infrastructure.Persistence;
using ISKI.SARS.Infrastructure.Persistence.Seeders;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ISKI.SARS.Infrastructure;
public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<SarsDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<JwtHelper>();

        services.AddScoped<IInstantValueRepository, InstantValueRepository>();
        services.AddScoped<IReportTemplateRepository, ReportTemplateRepository>();
        services.AddScoped<IArchiveTagRepository, ArchiveTagRepository>();
        services.AddScoped<IReportTemplateArchiveTagRepository, ReportTemplateArchiveTagRepository>();
        services.AddScoped<IReportTemplateTagRepository, ReportTemplateTagRepository>();
        services.AddScoped<ISystemMetricRepository, SystemMetricRepository>();
        services.AddScoped<ISystemSettingRepository, SystemSettingRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOperationClaimRepository, UserOperationClaimRepository>();
        services.AddScoped<IOperationClaimRepository, OperationClaimRepository>();

        using (var scope = services.BuildServiceProvider().CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<SarsDbContext>();
            dbContext.Database.EnsureCreated(); // Migrationları otomatik uygula

            var opClaimRepo = scope.ServiceProvider.GetRequiredService<IOperationClaimRepository>();
            OperationClaimSeeder.SeedAsync(opClaimRepo).Wait();

            var userRepo = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var userOpClaimRepo = scope.ServiceProvider.GetRequiredService<IUserOperationClaimRepository>();
            UserSeeder.SeedAsync(userRepo, opClaimRepo, userOpClaimRepo).Wait();

            var settingRepo = scope.ServiceProvider.GetRequiredService<ISystemSettingRepository>();
            SystemSettingSeeder.SeedAsync(settingRepo).Wait();
        }

        return services;
    }

    private static void EnsureDatabaseExists(string connectionString)
    {
        var builder = new SqlConnectionStringBuilder(connectionString);
        var databaseName = builder.InitialCatalog;

        // Bağlantı stringini master DB'ye bağlanacak şekilde değiştir
        builder.InitialCatalog = "master";

        using var connection = new SqlConnection(builder.ConnectionString);
        connection.Open();

        using var command = connection.CreateCommand();
        command.CommandText = $"IF DB_ID(N'{databaseName}') IS NULL CREATE DATABASE [{databaseName}];";
        command.ExecuteNonQuery();
    }
}
