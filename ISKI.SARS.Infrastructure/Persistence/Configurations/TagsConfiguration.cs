using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class TagsConfiguration : BaseEntityConfiguration<Tags, Guid>
{
    public override void Configure(EntityTypeBuilder<Tags> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(250);
        builder.Property(x => x.OpcPath).IsRequired();
        builder.Property(x => x.PullInterval).IsRequired();
    }
}
