using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.Core.Security.Entities;
using ISKI.SARS.Application.Features.Users.Commands.Create;
using ISKI.SARS.Application.Features.Users.Commands.Update;
using ISKI.SARS.Application.Features.Users.Dtos;

namespace ISKI.SARS.Application.Features.Users.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, CreatedUserResponse>();
        CreateMap<User, UpdatedUserResponse>();
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<PaginatedList<User>, PaginatedList<UserDto>>();
    }
}