using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.OperationClaims.Queries.GetList;
using ISKI.SARS.Application.Features.OperationClaims.Queries;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.Core.Persistence.Paging;

namespace ISKI.SARS.Application.Features.OperationClaims.Profiles;

public class OperationClaimProfile : Profile
{
    public OperationClaimProfile()
    {
        // Create
        CreateMap<CreateOperationClaimCommand, OperationClaim>();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>();

        // Update
        CreateMap<UpdateOperationClaimCommand, OperationClaim>();
        CreateMap<OperationClaim, UpdatedOperationClaimResponse>();

        // Delete
        CreateMap<OperationClaim, DeletedOperationClaimResponse>();

        // Query
        CreateMap<OperationClaim, OperationClaimDto>().ReverseMap();

        CreateMap<PaginatedList<OperationClaim>, PaginatedList<OperationClaimDto>>();

    }
}