using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions;
using ISKI.Core.Security.Repositories;
using ISKI.SARS.Application.Features.Users.Constants;
using ISKI.SARS.Application.Features.Users.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);
        if (user == null)
            throw new BusinessException(UserMessages.UserNotFound);

        return _mapper.Map<UserDto>(user);
    }
}
