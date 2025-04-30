using ISKI.Core.Domain;

namespace ISKI.Core.Security.Entities;

public class OperationClaim : BaseEntity<Guid>
{
    public string Name { get; set; } = string.Empty;

    // Navigation
    public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
