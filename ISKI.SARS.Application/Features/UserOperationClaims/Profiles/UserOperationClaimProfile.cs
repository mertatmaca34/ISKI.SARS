using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using ISKI.Core.Persistence.Paging;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Profiles;

public class UserOperationClaimProfile : Profile
{
    public UserOperationClaimProfile()
    {
        CreateMap<CreateUserOperationClaimCommand, UserOperationClaim>();

        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>();

        CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();
        CreateMap<UpdateUserOperationClaimCommand, UserOperationClaim>();

        CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>();

        CreateMap<UserOperationClaim, UserOperationClaimDto>();

        CreateMap<PaginatedList<UserOperationClaim>, PaginatedList<UserOperationClaimDto>>();

    }
}
