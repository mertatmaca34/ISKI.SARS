using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetById;

public class GetUserOperationClaimByIdQueryHandler : IRequestHandler<GetUserOperationClaimByIdQuery, UserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _repository;
    private readonly IMapper _mapper;

    public GetUserOperationClaimByIdQueryHandler(IUserOperationClaimRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserOperationClaimDto> Handle(GetUserOperationClaimByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new BusinessException(UserOperationClaimMessages.NotFound);

        return _mapper.Map<UserOperationClaimDto>(entity);
    }
}
