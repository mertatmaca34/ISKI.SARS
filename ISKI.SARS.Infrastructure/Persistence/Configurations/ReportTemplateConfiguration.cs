using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplateConfiguration : BaseEntityConfiguration<ReportTemplate, int>
{
    public override void Configure(EntityTypeBuilder<ReportTemplate> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
        builder.Property(x => x.CreatedByUserId).IsRequired();

        builder
            .HasMany(x => x.ReportTemplateUsers)
            .WithOne(x => x.ReportTemplate)
            .HasForeignKey(x => x.ReportTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
