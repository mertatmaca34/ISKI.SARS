using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplateArchiveTagConfiguration : BaseEntityConfiguration<ReportTemplateArchiveTag, int>
{
    public override void Configure(EntityTypeBuilder<ReportTemplateArchiveTag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ReportTemplateId).IsRequired();
        builder.Property(x => x.ArchiveTagId).IsRequired();

        builder.HasIndex(x => x.ReportTemplateId);
        builder.HasIndex(x => x.ArchiveTagId);

        builder
            .HasOne<ReportTemplate>()
            .WithMany()
            .HasForeignKey(x => x.ReportTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne<ArchiveTag>()
            .WithMany()
            .HasForeignKey(x => x.ArchiveTagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
