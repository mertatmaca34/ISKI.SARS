namespace ISKI.Core.Security.Entities;

public class OperationClaim
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    // Navigation
    public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
}
