using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Update;

public class UpdateUserOperationClaimCommand : IRequest<UpdatedUserOperationClaimResponse>
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
}