using AutoMapper;
using ISKI.Core.Security.Entities;
using ISKI.Core.Security.Hashing;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Rules;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(IUserRepository repository, IMapper mapper, UserBusinessRules rules) : IRequestHandler<CreateUserCommand, CreatedUserResponse>
{
    public async Task<CreatedUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await rules.UserEmailMustBeUnique(request.Email);

        HashingHelper.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);

        var user = mapper.Map<User>(request);
        user.PasswordHash = hash;
        user.PasswordSalt = salt;
        user.Status = true;

        var created = await repository.AddAsync(user);
        return mapper.Map<CreatedUserResponse>(created);
    }
}