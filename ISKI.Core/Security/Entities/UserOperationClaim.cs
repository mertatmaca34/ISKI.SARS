using ISKI.Core.Domain;

namespace ISKI.Core.Security.Entities;

public class UserOperationClaim : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    // Navigation
    public User User { get; set; }
    public OperationClaim OperationClaim { get; set; }
}
