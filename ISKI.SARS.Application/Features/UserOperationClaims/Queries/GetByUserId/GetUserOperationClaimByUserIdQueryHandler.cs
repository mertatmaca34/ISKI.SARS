using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;
using ISKI.SARS.Application.Features.UserOperationClaims.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetByUserId;

public class GetUserOperationClaimByUserIdQueryHandler : IRequestHandler<GetUserOperationClaimByUserIdQuery, UserOperationClaimDto>
{
    private readonly IUserOperationClaimRepository _repository;
    private readonly IMapper _mapper;

    public GetUserOperationClaimByUserIdQueryHandler(IUserOperationClaimRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserOperationClaimDto> Handle(GetUserOperationClaimByUserIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByUserIdAsync(request.UserId);
        if (entity == null)
            throw new BusinessException(UserOperationClaimMessages.NotFound);

        return _mapper.Map<UserOperationClaimDto>(entity);
    }
}
