using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using MediatR;
using System;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetByUserId;

public class GetUserOperationClaimByUserIdQuery : IRequest<UserOperationClaimDto>
{
    public Guid UserId { get; set; }
}
