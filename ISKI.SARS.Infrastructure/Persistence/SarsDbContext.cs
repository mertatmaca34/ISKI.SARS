using System.Collections.Generic;
using System.Reflection.Emit;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using User = ISKI.Core.Security.Entities.User;

namespace ISKI.SARS.Infrastructure.Persistence;

public class SarsDbContext(DbContextOptions<SarsDbContext> options) : DbContext(options)
{
    public DbSet<ReportTemplateTag> ReportTemplateTags  => Set<ReportTemplateTag>();
    public DbSet<ReportTemplate> ReportTemplates => Set<ReportTemplate>();
    public DbSet<InstantValue> InstantValues => Set<InstantValue>();
    public DbSet<User> Users => Set<User>();
    public DbSet<OperationClaim> OperationClaims => Set<OperationClaim>();
    public DbSet<UserOperationClaim> UserOperationClaims => Set<UserOperationClaim>();
    public DbSet<SystemMetric> SystemMetrics => Set<SystemMetric>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SarsDbContext).Assembly);
    }
}
