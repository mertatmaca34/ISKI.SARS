using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;

public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimResponse>
{
    public Guid Id { get; set; }
}