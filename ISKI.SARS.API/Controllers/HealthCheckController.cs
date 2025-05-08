using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ISKI.SARS.Application.Services.HealthCheckService;

namespace ISKI.SARS.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HealthCheckController(IHealthCheckService healthCheckService) : ControllerBase
{
    [HttpGet("app")]
    public IActionResult GetAppHealth()
    {
        return Ok(new { status = "UP", time = DateTime.UtcNow });
    }

    [HttpGet("db")]
    public async Task<IActionResult> GetDatabaseHealth()
    {
        bool canConnect = await healthCheckService.CanConnectToDatabaseAsync();

        if (canConnect)
            return Ok(new { status = "DB OK" });

        return StatusCode(503, new { status = "DB ERROR", message = "Veritabanı bağlantısı kurulamadı." });
    }
}