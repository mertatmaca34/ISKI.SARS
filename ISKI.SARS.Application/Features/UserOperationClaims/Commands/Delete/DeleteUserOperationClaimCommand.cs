using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimResponse>
{
    public int Id { get; set; }
}