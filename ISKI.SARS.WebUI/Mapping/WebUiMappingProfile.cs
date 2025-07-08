using AutoMapper;
using ISKI.SARS.WebUI.DTOs.Tags;
using ISKI.SARS.WebUI.ViewModels.Tags;

namespace ISKI.SARS.WebUI.Mapping;

public class WebUiMappingProfile : Profile
{
    public WebUiMappingProfile()
    {
        CreateMap<TagDto, TagVm>().ReverseMap();
    }
}
