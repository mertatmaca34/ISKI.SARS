using ISKI.SARS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Application.Services.HealthCheckService;

public class HealthCheckManager(SarsDbContext context) : IHealthCheckService
{
    public async Task<bool> CanConnectToDatabaseAsync()
    {
        try
        {
            return await context.Database.CanConnectAsync();
        }
        catch
        {
            return false;
        }
    }
}
