using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ISKI.SARS.Infrastructure.Persistence.Configurations;
using ISKI.SARS.Core.Infrastructure;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class TagValuesConfiguration : BaseEntityConfiguration<TagValues, Guid>
{
    public override void Configure(EntityTypeBuilder<TagValues> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Value).IsRequired().HasMaxLength(100);
        builder.Property(x => x.RecordDate).IsRequired();
    }
}
