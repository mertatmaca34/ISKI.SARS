using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class LogEntryConfiguration : BaseEntityConfiguration<LogEntry, int>
{
    public override void Configure(EntityTypeBuilder<LogEntry> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.Message).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.Detail).HasMaxLength(2000);
    }
}
