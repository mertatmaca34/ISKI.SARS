namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;

public class DeletedUserOperationClaimResponse
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
}