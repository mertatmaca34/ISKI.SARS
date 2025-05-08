using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Constants;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ISKI.SARS.Application.Features.Users.Rules;

public class UserBusinessRules(IUserRepository repository, IHttpContextAccessor httpContextAccessor)
{
    public async Task UserEmailMustBeUnique(string email)
    {
        var existing = await repository.GetAsync(x => x.Email == email);
        if (existing != null)
            throw new BusinessException(UserMessages.EmailAlreadyExists);
    }

    public async Task UserMustExist(Guid id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null)
            throw new BusinessException(UserMessages.UserNotFound);
    }

    public void EnsureUserIsSelfOrAdmin(Guid targetUserId)
    {
        var user = httpContextAccessor.HttpContext?.User;
        var currentUserId = user?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var isAdmin = user?.IsInRole("Admin") ?? false;

        if (!isAdmin && currentUserId != targetUserId.ToString())
            throw new BusinessException(UserMessages.UpdateNotAllowed);
    }
}
