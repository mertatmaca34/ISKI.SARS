using ISKI.SARS.Core.Infrastructure;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ISKI.SARS.Infrastructure.Persistence.Configurations;

public class ReportTemplateUserConfiguration : BaseEntityConfiguration<ReportTemplateUser, int>
{
    public override void Configure(EntityTypeBuilder<ReportTemplateUser> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ReportTemplateId).IsRequired();
        builder.Property(x => x.UserId).IsRequired();

        builder.HasIndex(x => x.ReportTemplateId);
        builder.HasIndex(x => x.UserId);

        builder
            .HasOne(x => x.ReportTemplate)
            .WithMany(x => x.ReportTemplateUsers)
            .HasForeignKey(x => x.ReportTemplateId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

