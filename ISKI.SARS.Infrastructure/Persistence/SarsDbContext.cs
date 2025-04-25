using System.Collections.Generic;
using System.Reflection.Emit;
using ISKI.SARS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISKI.SARS.Infrastructure.Persistence;

public class SarsDbContext : DbContext
{
    public SarsDbContext(DbContextOptions<SarsDbContext> options) : base(options)
    {
    }

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
