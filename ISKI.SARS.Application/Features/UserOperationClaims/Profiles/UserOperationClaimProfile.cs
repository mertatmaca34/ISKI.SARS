using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Profiles;

public class UserOperationClaimProfile : Profile
{
    public UserOperationClaimProfile()
    {
        CreateMap<CreateUserOperationClaimCommand, UserOperationClaim>();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>();

        // Query
        CreateMap<UserOperationClaim, UserOperationClaimDto>();
    }
}