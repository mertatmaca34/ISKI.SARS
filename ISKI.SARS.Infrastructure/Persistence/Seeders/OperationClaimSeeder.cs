using ISKI.Core.Security.Constants;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;

namespace ISKI.SARS.Infrastructure.Persistence.Seeders;

public static class OperationClaimSeeder
{
    public static async Task SeedAsync(IOperationClaimRepository repository)
    {
        var existingClaims = await repository.GetAllAsync(1, 100);
        var existingNames = existingClaims.Items.Select(c => c.Name).ToHashSet();

        var defaultClaims = new List<string>
        {
            GeneralOperationClaims.Admin,
            GeneralOperationClaims.Operator,
            GeneralOperationClaims.PendingUser
        };

        foreach (var claim in defaultClaims)
        {
            if (!existingNames.Contains(claim))
            {
                await repository.AddAsync(new OperationClaim { Name = claim });
            }
        }
    }
}
