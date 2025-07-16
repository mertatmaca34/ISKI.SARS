using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Constants;
using ISKI.SARS.Application.Features.Users.Dtos;
using System.Linq;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler(
    IUserRepository repository,
    IUserOperationClaimRepository userOperationClaimRepository,
    IMapper mapper) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null)
            throw new BusinessException(UserMessages.UserNotFound);

        var dto = mapper.Map<UserDto>(user);

        var claims = await userOperationClaimRepository.GetClaims(user);
        var firstClaim = claims.FirstOrDefault();
        if (firstClaim != null)
        {
            dto.OperationClaimId = firstClaim.Id;
            dto.OperationClaimName = firstClaim.Name;
        }

        return dto;
    }
}
