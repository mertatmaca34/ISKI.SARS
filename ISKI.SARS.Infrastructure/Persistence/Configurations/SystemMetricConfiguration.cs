using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class SystemMetricConfiguration : BaseEntityConfiguration<SystemMetric, int>
{
    public override void Configure(EntityTypeBuilder<SystemMetric> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Value).IsRequired();
        builder.Property(x => x.Unit).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastUpdated).IsRequired();
    }
}
