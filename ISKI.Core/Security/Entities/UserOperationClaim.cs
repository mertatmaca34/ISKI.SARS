namespace ISKI.Core.Security.Entities;

public class UserOperationClaim
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid OperationClaimId { get; set; }

    // Navigation
    public User User { get; set; }
    public OperationClaim OperationClaim { get; set; }
}
