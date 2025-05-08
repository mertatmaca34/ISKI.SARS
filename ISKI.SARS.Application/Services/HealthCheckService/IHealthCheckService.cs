namespace ISKI.SARS.Application.Services.HealthCheckService;

public interface IHealthCheckService
{
    Task<bool> CanConnectToDatabaseAsync();
}