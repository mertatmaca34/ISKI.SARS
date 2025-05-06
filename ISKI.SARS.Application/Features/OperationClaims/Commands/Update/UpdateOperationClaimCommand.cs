using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Update;

public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}