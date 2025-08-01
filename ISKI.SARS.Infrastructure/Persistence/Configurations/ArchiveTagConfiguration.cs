using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ArchiveTagConfiguration : BaseEntityConfiguration<ArchiveTag, int>
{
    public override void Configure(EntityTypeBuilder<ArchiveTag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.TagName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.TagNodeId).IsRequired().HasMaxLength(300);
        builder.Property(x => x.Description).HasMaxLength(500);
        builder.Property(x => x.IsActive).IsRequired();
    }
}
