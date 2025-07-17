using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Enums;
using ISKI.SARS.Domain.Services;

namespace ISKI.SARS.Infrastructure.Persistence.Seeders;

public static class SystemSettingSeeder
{
    public static async Task SeedAsync(ISystemSettingRepository repository)
    {
        var existing = await repository.GetAsync(x => true);
        if (existing != null) return;

        var setting = new SystemSetting
        {
            OpcServerUrl = "opc.tcp://localhost:4840",
            SessionTimeout = 60,
            LogLevel = LogLevel.Info
        };

        await repository.AddAsync(setting);
    }
}
