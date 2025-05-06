using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Queries.GetById;

public class GetOperationClaimByIdQuery : IRequest<OperationClaimDto>
{
    public Guid Id { get; set; }
}