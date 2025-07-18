using AutoMapper;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler(
    IUserRepository repository,
    IMapper mapper,
    UserBusinessRules rules,
    IUserOperationClaimRepository userOperationClaimRepository)
    : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
{
    public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await rules.UserMustExist(request.Id);

        var user = await repository.GetByIdAsync(request.Id);

        var userClaims = await userOperationClaimRepository.GetAllAsync(x => x.UserId == request.Id);
        foreach (var claim in userClaims)
            await userOperationClaimRepository.DeleteAsync(claim);

        var deleted = await repository.DeleteAsync(user);

        return mapper.Map<DeletedUserResponse>(deleted);
    }
}
