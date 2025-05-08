using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Profiles;

public class UserOperationClaimProfile : Profile
{
    public UserOperationClaimProfile()
    {
        // Create
        CreateMap<CreateUserOperationClaimCommand, UserOperationClaim>();

        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>();

        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>();

        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>();

        CreateMap<UserOperationClaim, UserOperationClaimDto>();
    }
}
