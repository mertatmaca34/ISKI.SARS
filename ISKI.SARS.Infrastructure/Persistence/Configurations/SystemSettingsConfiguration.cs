using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class SystemSettingsConfiguration : BaseEntityConfiguration<SystemSettings, Guid>
{
    public override void Configure(EntityTypeBuilder<SystemSettings> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.OpcServerUrl).IsRequired();
        builder.Property(x => x.SessionTimeout).IsRequired();
        builder.Property(x => x.LogLevel).IsRequired();
    }
}
