using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimResponse>
{
    public Guid UserId { get; set; }
    public int OperationClaimId { get; set; }
}
