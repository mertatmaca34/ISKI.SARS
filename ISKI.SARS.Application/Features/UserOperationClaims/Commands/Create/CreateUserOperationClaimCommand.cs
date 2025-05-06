using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;

public class CreateUserOperationClaimCommand : IRequest<CreatedUserOperationClaimResponse>
{
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}
