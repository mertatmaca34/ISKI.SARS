using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimResponse>
{
    public int Id { get; set; }
}