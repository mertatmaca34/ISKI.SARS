using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ISKI.SARS.Infrastructure.Persistence
{
    public class SarsDbContextFactory : IDesignTimeDbContextFactory<SarsDbContext>
    {
        public SarsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SarsDbContext>();

            // BURAYA kendi connection string'ini yaz kankacım
            var connectionString = "Server=10.0.254.193\\WINCC;Database=ISKI_SARS;User ID=sars;Password=1q2w3e;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=True";
            optionsBuilder.UseSqlServer(connectionString);

            return new SarsDbContext(optionsBuilder.Options);
        }
    }
}
