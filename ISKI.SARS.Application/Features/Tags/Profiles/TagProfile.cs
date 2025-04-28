using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Commands.CreateTag;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.Tags.Profiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<Tag, GetTagDto>().ReverseMap();
        CreateMap<Tag, CreateTagCommand>().ReverseMap();
        CreateMap<CreateTagCommand, GetTagDto>();
    }
}
