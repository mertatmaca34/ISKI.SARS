using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetById;

public class GetUserOperationClaimByIdQuery : IRequest<UserOperationClaimDto>
{
    public int Id { get; set; }
}