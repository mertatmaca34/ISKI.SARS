using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplatesConfiguration : BaseEntityConfiguration<ReportTemplates, Guid>
{
    public override void Configure(EntityTypeBuilder<ReportTemplates> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(250);
        builder.Property(x => x.Description).HasMaxLength(1000);
    }
}
