using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplateTagsConfiguration : BaseEntityConfiguration<ReportTemplateTags, Guid>
{
    public override void Configure(EntityTypeBuilder<ReportTemplateTags> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(250);

        builder.HasOne<ReportTemplates>()
            .WithMany()
            .HasForeignKey(x => x.ReportTemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Tags>()
            .WithMany()
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
