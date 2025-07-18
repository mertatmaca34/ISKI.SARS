using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplateTagConfiguration : BaseEntityConfiguration<ReportTemplateTag, int>
{
    public override void Configure(EntityTypeBuilder<ReportTemplateTag> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ReportTemplateId).IsRequired();
        builder.Property(x => x.TagName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.TagNodeId).IsRequired().HasMaxLength(300);

        builder.HasIndex(x => x.ReportTemplateId);

        builder
            .HasOne(x => x.ReportTemplate)
            .WithMany()
            .HasForeignKey(x => x.ReportTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
