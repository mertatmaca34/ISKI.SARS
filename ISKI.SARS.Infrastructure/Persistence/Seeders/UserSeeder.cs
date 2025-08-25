using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.Repositories;
using ISKI.Core.Security.Constants;

namespace ISKI.SARS.Infrastructure.Persistence.Seeders;

public static class UserSeeder
{
    public static async Task SeedAsync(
        IUserRepository userRepository,
        IOperationClaimRepository operationClaimRepository,
        IUserOperationClaimRepository userOperationClaimRepository)
    {
        var adminClaim = await operationClaimRepository.GetAsync(x => x.Name == GeneralOperationClaims.Admin);
        if (adminClaim == null) return;

        var existingUser = await userRepository.GetAsync(x => x.Email == "admin@gmail.com");
        if (existingUser != null) return;

        HashingHelper.CreatePasswordHash("1Q2w3e", out var hash, out var salt);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = "admin",
            LastName = "root",
            Email = "admin@gmail.com",
            PasswordHash = hash,
            PasswordSalt = salt,
            Status = true
        };

        await userRepository.AddAsync(user);
        await userOperationClaimRepository.AddAsync(new UserOperationClaim
        {
            UserId = user.Id,
            OperationClaimId = adminClaim.Id
        });
    }
}
