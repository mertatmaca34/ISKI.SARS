using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class InstantValueConfiguration : BaseEntityConfiguration<InstantValue, DateTime>
{
    public override void Configure(EntityTypeBuilder<InstantValue> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ArchiveTagId).IsRequired();
        builder.Property(x => x.Value).IsRequired().HasMaxLength(500); // Opsiyonel: 500 fazla bile olabilir
        builder.Property(x => x.Status).IsRequired();

        // Index önerileri
        builder.HasIndex(x => x.ArchiveTagId);
        builder.HasIndex(x => x.Id); // Id = Timestamp, sorgularda BETWEEN vs. yapılacağı için mantıklı

        // Navigation (isteğe bağlı, eğer InstantValue içinde tanımlandıysa)
        builder
            .HasOne(x => x.ArchiveTag)
            .WithMany()
            .HasForeignKey(x => x.ArchiveTagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
