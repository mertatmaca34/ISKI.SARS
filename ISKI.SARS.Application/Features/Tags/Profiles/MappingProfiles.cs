using AutoMapper;
using ISKI.SARS.Application.Features.Tags.Dtos;
using ISKI.SARS.Domain.Entities;
namespace ISKI.SARS.Application.Features.Tags.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();
        CreateMap<Tag, DeleteTagDto>().ReverseMap();
        CreateMap<Tag, GetTagDto>();
        CreateMap<List<Tag>, TagListDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));
    }
}