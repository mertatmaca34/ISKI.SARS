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
        builder.Property(x => x.OpcEndpoint).IsRequired().HasMaxLength(300);
        builder.Property(x => x.PullInterval).IsRequired();
        builder.Property(x => x.IsActive).IsRequired();
    }
}
