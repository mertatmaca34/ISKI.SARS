using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.Update;

public class UpdateUserCommandHandler(
    IUserRepository repository,
    IMapper mapper,
    UserBusinessRules rules) : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
{
    public async Task<UpdatedUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await rules.UserMustExist(request.Id);
        rules.EnsureUserIsSelfOrAdmin(request.Id);

        var user = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, user);

        var updated = await repository.UpdateAsync(user);
        return mapper.Map<UpdatedUserResponse>(updated);
    }
}