using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Commands.Create;

public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimResponse>
{
    public string Name { get; set; } = string.Empty;
}