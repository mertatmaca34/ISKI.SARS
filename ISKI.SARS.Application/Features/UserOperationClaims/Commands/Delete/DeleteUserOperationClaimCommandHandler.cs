using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.UserOperationClaims.Constants;
using MediatR;

namespace ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;

public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimResponse>
{
    private readonly IUserOperationClaimRepository _repository;
    private readonly IMapper _mapper;

    public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeletedUserOperationClaimResponse> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetAsync(x => x.Id == request.Id);
        if (entity == null)
            throw new BusinessException(UserOperationClaimMessages.NotFound);

        var deleted = await _repository.DeleteAsync(entity);
        return _mapper.Map<DeletedUserOperationClaimResponse>(deleted);
    }
}
