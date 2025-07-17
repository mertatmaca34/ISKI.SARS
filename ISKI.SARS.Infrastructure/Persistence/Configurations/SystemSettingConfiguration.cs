using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class SystemSettingConfiguration : BaseEntityConfiguration<SystemSetting, int>
{
    public override void Configure(EntityTypeBuilder<SystemSetting> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.OpcServerUrl).IsRequired().HasMaxLength(200);
        builder.Property(x => x.SessionTimeout).IsRequired();
        builder.Property(x => x.LogLevel).IsRequired();
    }
}
