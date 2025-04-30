using System.Collections.Generic;
using System.Reflection.Emit;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence;

public class SarsDbContext(DbContextOptions<SarsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<OperationClaim> OperationClaims => Set<OperationClaim>();
    public DbSet<UserOperationClaim> UserOperationClaims => Set<UserOperationClaim>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<TagValues> TagValues => Set<TagValues>();
    public DbSet<ReportTemplates> ReportTemplates => Set<ReportTemplates>();
    public DbSet<ReportTemplateTags> ReportTemplateTags => Set<ReportTemplateTags>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SarsDbContext).Assembly);
    }
}
