using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.OperationClaims.Queries.GetList;

public class GetOperationClaimListQueryHandler : IRequestHandler<GetOperationClaimListQuery, PaginatedList<OperationClaimDto>>
{
    private readonly IOperationClaimRepository _repository;
    private readonly IMapper _mapper;

    public GetOperationClaimListQueryHandler(IOperationClaimRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<OperationClaimDto>> Handle(GetOperationClaimListQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetAllAsync(request.PageNumber, request.PageSize);
        return _mapper.Map<PaginatedList<OperationClaimDto>>(result);
    }
}
